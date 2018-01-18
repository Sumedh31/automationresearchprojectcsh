using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Web;
using System.Threading;
using iDAutomatedTests.FrontEnd.Apps.OldLayoutManager.Locators;
using Core.Wrappers;
using Core.Base;
using Core.Generic.MainFrameSettings;
using Core.AppModules.FrontEnd;
using OpenQA.Selenium.Interactions;

namespace iDAutomatedTests.FrontEnd.Apps.OldLayoutManager.TestEngine
{
    public class LayoutManager:FrontEndCommnUtilities
    {
        
        // Constructor
        public LayoutManager():base(){}
        
        // Manage Layout
        public void ManageLayout()
        {
            Selenium.SafeClick(OldLayoutManagerElements.ManageLayout);
            Selenium.WaitForElementPresent(OldLayoutManagerElements.LayoutsTab);
            Thread.Sleep(2000);
        }

        // Verify Layout Options
        public void VerifyAllTheLayoutOptions()
        {
           VerifyManageLayout();
           VerifyEditLayoutOption();
           VerifyHelpOption();
        }

        // Verify Manage Layout option
        public void VerifyManageLayout()
        {
            Assert.IsTrue(Selenium.IsElementPresent(OldLayoutManagerElements.ManageLayout));
        }

        // Verify Edit Layout option is present
        public void VerifyEditLayoutOption()
        {
            Assert.IsTrue(Selenium.IsElementPresent(OldLayoutManagerElements.EditLayoutOption));
        }

        // Verify Help option
        public void VerifyHelpOption()
        {
            Assert.IsTrue(Selenium.IsElementPresent(OldLayoutManagerElements.Help));
        }

        // Collections - Verify the Edit Drop Down List
        public void VerifyEditDropDownList()
        {
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsLayoutManagerElements.EditLayout));

            Selenium.SafeClick(OldCollectionsLayoutManagerElements.EditLayout);
            Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.EditLayoutDraft);
            Thread.Sleep(2000);

            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsLayoutManagerElements.EditLayoutDraft));
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsLayoutManagerElements.EditLayoutStaging));
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsLayoutManagerElements.EditLayoutLive));
        }

        // Collections - Verify that Edit Drop Down List disappears after clicking on Edit again
        public void VerifyEditDropDownListDisappears()
        {
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsLayoutManagerElements.EditLayout));

            Selenium.SafeClick(OldCollectionsLayoutManagerElements.EditLayout);
            Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.EditLayoutDraft);
            Thread.Sleep(2000);

            Selenium.SafeClick(OldCollectionsLayoutManagerElements.EditLayoutDropDownList);
            Thread.Sleep(3000);

            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsLayoutManagerElements.EditLayout));
        }

        // Collections - Verify that creator cannot view the Edit drop down list
        public void VerifyCreatorCannotViewEditOption()
        {
            Assert.IsTrue(Selenium.IsElementNotPresent(OldCollectionsLayoutManagerElements.EditLayout));
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsLayoutManagerElements.ManagerLayout));
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsLayoutManagerElements.LayoutHelp));
        }

        // Collections - Verify that Contributor can view the Edit Layout drop down list
        public void VerifyContributorCanViewEditOption()
        {
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsLayoutManagerElements.EditLayout));
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsLayoutManagerElements.ManagerLayout));
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsLayoutManagerElements.LayoutHelp));
        }

        // Collections - Verify that Read Only User cannot view Edit Layout drop down list
        public void VerifyReadOnlyCannotViewEditOption()
        {
            Assert.IsTrue(Selenium.IsElementNotPresent(OldCollectionsLayoutManagerElements.EditLayout));
            Assert.IsTrue(Selenium.IsElementNotPresent(OldCollectionsLayoutManagerElements.ManagerLayout));
            Assert.IsTrue(Selenium.IsElementNotPresent(OldCollectionsLayoutManagerElements.LayoutHelp));
        }

        // Collections - Navigate to Manage Layout page
        public void NavigateToManageLayout()
        {
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManagerLayout);
            Thread.Sleep(2000);

            Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.AddOptionOff);
            
        }

        // Collections - Navigate to Home Subsite
        public void NavigateToHomeSubsite()
        {
            Thread.Sleep(2000);
            //This needs to be handled in more genericway (Generic resource file accessing). 
            Selenium.Open("http://id/home");
            Thread.Sleep(4000);
        }

        // Collections - Verify Add + drop down list
        public void VerifyAddPlusDropDownList(string newLayout, string newSubsiteTemplate)
        {
            string actualLayoutText, actualSubsiteTemplateText;
            
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.AddOptionOff);
            Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.AddOptionOn);

            // Verify New Layout Option Please verify this function's intention with parag. Sumedh have changed it a bit hence it needs confirmation from Parag. Earlier instead of AddNewLayout it had something else.
            actualLayoutText= Selenium.SafeGetText(OldCollectionsLayoutManagerElements.AddNewLayout);
            Assert.AreEqual(newLayout,actualLayoutText);

            // Verify New Subsite Template
            actualSubsiteTemplateText =
                Selenium.SafeGetText(OldCollectionsLayoutManagerElements.AddNewSubsiteTemplate);
            Assert.AreEqual(newSubsiteTemplate, actualSubsiteTemplateText);

        }

        // Collections - Verify Actiosn drop down list on Manage Layout
        public void VerifyActionsDropDownList(string editProperties, string recycleBin)
        {
            string actualEditPropertiesText, actualRecycleBinText;

            Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutActionsOff);
            Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.ManageLayoutActionsOn);

            // verify edit properties
            actualEditPropertiesText =
                Selenium.SafeGetText(OldCollectionsLayoutManagerElements.ManageLayoutActionsEditProperties);
            Assert.AreEqual(editProperties,actualEditPropertiesText);

            // verify recycle bin
            actualRecycleBinText =
                Selenium.SafeGetText(OldCollectionsLayoutManagerElements.ManageLayoutActionsRecycleBin);
            Assert.AreEqual(recycleBin, actualRecycleBinText);
        }

        // Collections - Create New Subsite Template
        public void AddNewSubsiteTemplate(string templateName, [Optional] string description, [Optional] int rows, int applicationArea)
        {
            // Click on New Subsite Template
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.AddOptionOff);
            Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.AddNewSubsiteTemplate);
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.AddNewSubsiteTemplate);
            Thread.Sleep(4000);
            Selenium.SelectFrameById("newTemplateModal");

            // Enter Name
            Selenium.SafeType(OldCollectionsLayoutManagerElements.NewSubsiteTemplateNameTextfield, templateName);

            // Enter Description
            if (description != null)
            {
                Selenium.SafeType(OldCollectionsLayoutManagerElements.NewSubsiteTemplateDescriptionTextarea, description);
            }

            Selenium.SwitchTo().DefaultContent();

            // Move to Subsite step
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubsiteTemplateNextButton);
            Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.NewSubsiteTemplateBackButton);

            // Move to Finish step
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubsiteTemplateNextButton);
            Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.NewSubsiteTemplateFinishButton);

            // Click on Finish
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubsiteTemplateFinishButton);
            Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.NewSubsiteTemplateSaveButton);

            // Insert rows
            if (rows > 0)
            {
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubsiteTemplateStructureInsert);
                Thread.Sleep(2000);

                for (int i = 1; i <= rows; i++)
                {
                    Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.NewSubisteTemplateInsertRowBelowCell);
                    Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubisteTemplateInsertRowBelowCell);
                    Thread.Sleep(2000);
                }
             }

            // Select Application Area
            SelectApplicationArea(applicationArea);
            
           // Save
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubsiteTemplateSaveButton);
            Thread.Sleep(2000);

            Selenium.SwitchTo().DefaultContent();

            Selenium.SafeType(OldCollectionsLayoutManagerElements.NewSubsiteTemplateExitDescriptionTextArea,"save subsite template");
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubsiteTemplateExitOkButton);
            Thread.Sleep(2000);


        }
        
        // Collections - Edit Subiste Template
        public void EditSubsiteTemplate(string templateName)
        {
            // Navigate to Subsite Template tab
            if (Selenium.IsElementPresent(OldCollectionsLayoutManagerElements.ManageLayoutLayoutsTab))
            {
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutLayoutsTab);
                Thread.Sleep(2000);
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
                Thread.Sleep(2000);
            }
            else
            {
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
                Thread.Sleep(2000);
            }

            // Edit the created template
            Selenium.SafeClick(string.Format(OldCollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTemplateLocator, templateName));
            Selenium.WaitForElementPresent(OldCollectionsEditLayoutElements.EditLayoutSaveEditing);
            Thread.Sleep(2000);

           }

        // Collections - Make Template as Default
        public void MakeSubsiteTemplateDefault(string templateName)
        {
            // Navigate to Subsite Template tab
            if (Selenium.IsElementPresent(OldCollectionsLayoutManagerElements.ManageLayoutLayoutsTab))
            {
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutLayoutsTab);
                Thread.Sleep(2000);
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
                Thread.Sleep(2000);
            }
            else
            {
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
                Thread.Sleep(2000);
            }

            // Make Template Default
            Selenium.SafeClick(string.Format(OldCollectionsLayoutManagerElements.ManageLayoutDefaultRadioOptionLocator, templateName));
            Thread.Sleep(2000);
        }

        // Collections - Add New Subsite Layout
        public void AddNewSubsiteLayout(string layoutName, [Optional] string layoutDescription, [Optional] int layoutRows, int layoutApplicationArea)
        {
            // Click on New Layout
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.AddOptionOff);
            //Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.stewart);
            //Selenium.SafeClick(OldCollectionsLayoutManagerElements.stewart);
            Thread.Sleep(4000);

            // Select New Layout Wizard
            Selenium.SelectFrameById("newPageWizard");

            // Enter Title
            Selenium.SafeType(OldCollectionsAddNewLayoutElements.AddNewLayoutTitleTextBox, layoutName);

            // Enter Description
            if (layoutDescription != null)
            {
                Selenium.SafeType(OldCollectionsAddNewLayoutElements.AddNewLayoutDescriptionTextBox, layoutDescription);
            }

            Selenium.SwitchTo().DefaultContent();

            // Move to Owner steps
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubsiteTemplateNextButton);
            Thread.Sleep(2000);
            Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.NewSubsiteTemplateBackButton);

            // Move to Templates step
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubsiteTemplateNextButton);
            Thread.Sleep(2000);
            Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.NewSubsiteTemplateBackButton);
            
            // Move to Finish step
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubsiteTemplateNextButton);
            Thread.Sleep(2000);
            Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.NewSubsiteTemplateFinishButton);
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubsiteTemplateFinishButton);
            Thread.Sleep(4000);

            // Save and Publish to Live
            Selenium.WaitForElementPresent(OldCollectionsEditLayoutElements.EditLayoutSaveOption);
            Selenium.SafeClick(OldCollectionsEditLayoutElements.EditLayoutSaveOption);
            Selenium.WaitForElementPresent(OldCollectionsEditLayoutElements.EditLayoutPublishLiveExit);
            Selenium.SafeClick(OldCollectionsEditLayoutElements.EditLayoutPublishLiveExit);
            Thread.Sleep(4000);

            Selenium.SwitchTo().DefaultContent();

            // Save Layout with comments
            Selenium.SafeType(OldCollectionsEditLayoutElements.EditLayoutSaveDescriptionTextArea, "saving subsite layout");
            Selenium.SafeClick(OldCollectionsEditLayoutElements.EditLayoutSaveButtonSavePopup);
            Thread.Sleep(4000);


        }

        // Collections - Edit Subiste Template
        public void EditSubsiteLayout(string layoutName)
        {
            // Navigate to Subsite Layouts tab
            if (Selenium.IsElementPresent(OldCollectionsLayoutManagerElements.ManageLayoutLayoutsTab))
            {
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
                Thread.Sleep(2000);
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutLayoutsTab);
                Thread.Sleep(2000);
            }
            else
            {
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutLayoutsTab);
                Thread.Sleep(2000);
            }

            // Edit the created Layout
            Selenium.SafeClick(string.Format(OldCollectionsLayoutManagerElements.ManageLayoutEditLayoutLocator, layoutName));
            Selenium.WaitForElementPresent(OldCollectionsEditLayoutElements.EditLayoutSaveOption);
            Thread.Sleep(2000);

        }

        // Collections - Apply Layout
        public void ApplyLayout(string layoutName)
        {
            // Navigate to Subsite Layouts tab
            if (Selenium.IsElementPresent(OldCollectionsLayoutManagerElements.ManageLayoutLayoutsTab))
            {
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
                Thread.Sleep(2000);
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutLayoutsTab);
                Thread.Sleep(2000);
            }
            else
            {
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutLayoutsTab);
                Thread.Sleep(2000);
            }

            // Apply Layout
            Selenium.SafeClick(string.Format(OldCollectionsLayoutManagerElements.ManageLayoutAppliedRadioOptionLocator, layoutName));
            Thread.Sleep(2000);
        }

        // Collections - Select Application Area
        public void SelectApplicationArea(int applicationAreaRow)
        {
            if (applicationAreaRow >= 0)
            {
                Selenium.SafeClick(String.Format(OldCollectionsLayoutManagerElements.NewSubsiteTemplateRowSelector, applicationAreaRow));
                Selenium.SafeClick(String.Format(OldCollectionsLayoutManagerElements.NewSubsiteTemplateCellApplicationAreaSelector, applicationAreaRow));
                Thread.Sleep(2000);
            }
           }

        // Collections - Add Footer Component
        public void AddFooterComponent(int rownumber, string entity )
        {
            if (entity == "Template")
            {
             Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.NewSubsiteTemplateComponentsTab);
             Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubsiteTemplateComponentsTab);
             Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.NewSubsiteTemplateComponentsSiteFramework);
            }
            else
            {
               Selenium.WaitForElementPresent(OldCollectionsEditLayoutElements.EditLayoutComponentsTab); 
               Selenium.SafeClick(OldCollectionsEditLayoutElements.EditLayoutComponentsTab);
               Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.NewSubsiteTemplateComponentsSiteFramework);
            }
            
            Selenium.SwitchTo().DefaultContent();
            
            string droppableLocator =
                    String.Format(OldCollectionsLayoutManagerElements.NewSubsiteTemplateComponentsRowSelector, rownumber);

            Thread.Sleep(2000);

            Selenium.SafeDragAndDrop(OldCollectionsLayoutManagerElements.NewSubsiteTemplateComponentsFrameworkSiteFooter,droppableLocator);

            Thread.Sleep(2000);
                
            Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.NewSubsiteTemplateComponentsSiteFramework);

            // Save Template/Layout
            if (entity == "Template")
            {
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubsiteTemplateSaveButton);
                Thread.Sleep(2000);
                Selenium.SwitchTo().DefaultContent();

                Selenium.SafeType(OldCollectionsLayoutManagerElements.NewSubsiteTemplateExitDescriptionTextArea, "added Footer component in the subsite template");
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubsiteTemplateExitOkButton);
                Thread.Sleep(2000);
            }
            else
            {
                Selenium.SafeClick(OldCollectionsEditLayoutElements.EditLayoutSaveOption);
                Thread.Sleep(4000);
                Selenium.WaitForElementPresent(OldCollectionsEditLayoutElements.EditLayoutPublishLiveExit);
                Selenium.SafeClick(OldCollectionsEditLayoutElements.EditLayoutPublishLiveExit);
                Thread.Sleep(2000);
                Selenium.SwitchTo().DefaultContent();
                Selenium.SafeType(OldCollectionsEditLayoutElements.EditLayoutSaveDescriptionTextArea, "added Footer component in the subsite layout");
                Selenium.SafeClick(OldCollectionsEditLayoutElements.EditLayoutSaveButtonSavePopup);
                Thread.Sleep(4000);
            }
            

            
        }

        // Collections - Add Header Component
        public void AddHeaderComponent(int rownumber, string entity)
        {
            if (entity == "Template")
            {
                Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.NewSubsiteTemplateComponentsTab);
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubsiteTemplateComponentsTab);
                Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.NewSubsiteTemplateComponentsSiteFramework);
            }
            else
            {
                Selenium.WaitForElementPresent(OldCollectionsEditLayoutElements.EditLayoutComponentsTab);
                Selenium.SafeClick(OldCollectionsEditLayoutElements.EditLayoutComponentsTab);
                Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.NewSubsiteTemplateComponentsSiteFramework);
            }
            
            Selenium.SwitchTo().DefaultContent();

            string droppableLocator =
                String.Format(OldCollectionsLayoutManagerElements.NewSubsiteTemplateComponentsRowSelector, rownumber);

            Thread.Sleep(2000);

            Selenium.SafeDragAndDrop(OldCollectionsLayoutManagerElements.NewSubsiteTemplateComponentsFrameworkSiteHeader, droppableLocator);

            Thread.Sleep(2000);

            Selenium.WaitForElementPresent(OldCollectionsLayoutManagerElements.NewSubsiteTemplateComponentsSiteFramework);

            // Save Template/Layout
            if (entity == "Template")
            {
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubsiteTemplateSaveButton);
                Thread.Sleep(2000);
                Selenium.SwitchTo().DefaultContent();

                Selenium.SafeType(OldCollectionsLayoutManagerElements.NewSubsiteTemplateExitDescriptionTextArea, "added Footer component in the subsite template");
                Selenium.SafeClick(OldCollectionsLayoutManagerElements.NewSubsiteTemplateExitOkButton);
                Thread.Sleep(2000);
            }
            else
            {
                Selenium.SafeClick(OldCollectionsEditLayoutElements.EditLayoutSaveOption);
                Thread.Sleep(4000);
                Selenium.WaitForElementPresent(OldCollectionsEditLayoutElements.EditLayoutPublishLiveExit);
                Selenium.SafeClick(OldCollectionsEditLayoutElements.EditLayoutPublishLiveExit);
                Thread.Sleep(2000);
                Selenium.SwitchTo().DefaultContent();
                Selenium.SafeType(OldCollectionsEditLayoutElements.EditLayoutSaveDescriptionTextArea, "added Footer component in the subsite layout");
                Selenium.SafeClick(OldCollectionsEditLayoutElements.EditLayoutSaveButtonSavePopup);
                Thread.Sleep(4000);
            }
        }

        // Collections - Verify that Template is created successfully
        public void VerifySubsiteTemplate(string templateName)
        {
            // Cick on Subsite Template tab
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
            Thread.Sleep(2000);

            // verify that template exists
            Selenium.IsElementPresent(
                String.Format(OldCollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTemplateLocator, templateName));
        }

        // Collections - Delete Subsite Template
        public void DeleteSubsiteTemplate(string templateName)
        {
            // Cick on Subsite Template tab
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
            Thread.Sleep(2000);

            // Select Template check box
            Selenium.SafeClick(String.Format(OldCollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTemplateCheckBox,templateName));

            // Select Delete Option
            Selenium.SafeSelect(OldCollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesActionsDropDownList, "Delete");
            Thread.Sleep(2000);

            Selenium.SwitchTo().DefaultContent();

            // Click on OK
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesDeletePopupOkButton);
            Thread.Sleep(4000);
        }

        // Collections - Verify that Template is deleted successfully
        public void VerifySubsiteTemplateDeleted(string templateName)
        {
            // Cick on Subsite Template tab
            Selenium.SafeClick(OldCollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
            Thread.Sleep(2000);

            // verify that template exists
            Selenium.IsElementNotPresent(
                String.Format(OldCollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTemplateLocator, templateName));
        }

        // Collections - Verify Manage Layout on Edit Layout
        public void VerifyManageLayoutForEditLayout()
        {
            Selenium.IsElementPresent(OldCollectionsEditLayoutElements.EditLayoutManageLayout);
            Thread.Sleep(2000);
        }

        // Collections - Edit Layout Live version
        public void EditLayoutLive()
        {
            // Edit Live version
            Selenium.SafeClick(OldCollectionsEditLayoutElements.EditLayoutEditOption);
            Selenium.WaitForElementPresent(OldCollectionsEditLayoutElements.EditLayoutEditDropDownList);
            Selenium.SafeClick(OldCollectionsEditLayoutElements.EditLayoutEditLive);
            Thread.Sleep(3000);
        }

        // Collections - Verify Save Drop Down List for Edit Layout
        public void VerifySaveDropDownListEditLayout()
        {
            Selenium.IsElementPresent(OldCollectionsEditLayoutElements.EditLayoutSaveOption);
            Selenium.SafeClick(OldCollectionsEditLayoutElements.EditLayoutSaveOption);
            Selenium.WaitForElementPresent(OldCollectionsEditLayoutElements.EditLayoutSaveDropDownList);

            // Verify 'Save a Draft & Continue Editing' option
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsEditLayoutElements.EditLayoutSaveDraftContinueEditing));

            // Verify 'Save a Draft & Exit' option
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsEditLayoutElements.EditLayoutSaveDraftExit));

            // Verify 'Publish to Staging & Exit' option
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsEditLayoutElements.EditLayoutPublishStagingExit));

            // Verify 'Publish to Live & Exit' option
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsEditLayoutElements.EditLayoutPublishLiveExit));
        }

        // Collections - Verify Edit drop down list options for Edit Layout
        public void VerifyEditDropDownListOptionsForEditLayout()
        {
            Selenium.IsElementPresent(OldCollectionsEditLayoutElements.EditLayoutEditOption);
            Selenium.SafeClick(OldCollectionsEditLayoutElements.EditLayoutEditOption);
            Selenium.WaitForElementPresent(OldCollectionsEditLayoutElements.EditLayoutEditDropDownList);

            // Verify 'Draft' option
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsEditLayoutElements.EditLayoutEditDraft));

            // Verify 'Staging' option
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsEditLayoutElements.EditLayoutEditStaging));

            // Verify 'Live' option
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsEditLayoutElements.EditLayoutEditLive));
            }

        // Collections - Verify Actions Drop Down List Options for Edit Layout
        public void VerifyActionsDropDownListOptionsEditLayot()
        {
            Selenium.IsElementPresent(OldCollectionsEditLayoutElements.EditLayoutActionOption);
            Selenium.SafeClick(OldCollectionsEditLayoutElements.EditLayoutActionOption);
            Selenium.WaitForElementPresent(OldCollectionsEditLayoutElements.EditLayoutActionsDropDownList);

            // Verify 'Edit Properties' option
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsEditLayoutElements.EditLayoutActionsEditProperties));

            // Verify 'Move Layout' option
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsEditLayoutElements.EditLayoutActionsEditProperties));
           
            // Verify 'Delete Layout' option
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsEditLayoutElements.EditLayoutActionsDeleteLayout));

            // Verify 'Revert Layout' option
            Assert.IsTrue(Selenium.IsElementPresent(OldCollectionsEditLayoutElements.EditLayoutActionsRevertLayout));
        }

        // Add Users as Layout Owners from wizard
        public void AddUsersAsLayoutOwner([Optional] string lastName,[Optional] string givenName,[Optional] string email,[Optional] string addFrom)
        {
            // select New Layout pop up
            Selenium.SelectFrameById("newPageWizard");
            
            // click on Add User/s button
            Selenium.SafeClick(OldLayoutManagerElements.NewLayoutOwnerTabAddUsersButton);
            Selenium.WaitForElementPresent(OldLayoutManagerElements.NewLayoutOwnerTabFindUserGivenNameTextBox);

            // enter Last Name
            if (lastName != null)
                Selenium.SafeType(OldLayoutManagerElements.NewLayoutOwnerTabFindUserLastNameTextBox,
                    lastName);
            
            // enter Given Name
            if (givenName != null)
                Selenium.SafeType(OldLayoutManagerElements.NewLayoutOwnerTabFindUserGivenNameTextBox,
                    givenName);
            
            // enter Email
            if (email != null)
                Selenium.SafeType(OldLayoutManagerElements.NewLayoutOwnerTabFindUserEmailTextBox,email);
            
            // select AddFrom
            if (addFrom != null)
                Selenium.SafeSelect(OldLayoutManagerElements.NewLayoutOwnerTabFindUserAddFromDropDownList, addFrom);

            // Search
            Selenium.SafeClick(OldLayoutManagerElements.NewLayoutOwnerTabFindUserSearchButton);
            Selenium.WaitForElementPresent(OldLayoutManagerElements.NewLayoutOwnerTabFindUserGuestCheckBox);

            // Select any user 

            // Select guest user
            Selenium.SafeClick(OldLayoutManagerElements.NewLayoutOwnerTabFindUserGuestCheckBox);
            Selenium.WaitForElementPresent(OldLayoutManagerElements.NewLayoutOwnerTabFindUserOkButton);

            // Click on OK
            Selenium.SafeClick(OldLayoutManagerElements.NewLayoutOwnerTabFindUserOkButton);
            Selenium.WaitForElementNotPresent(OldLayoutManagerElements.NewLayoutOwnerTabFindUserOkButton);
            Thread.Sleep(2000);

   }

        // Navigate to Applicatiosn sub tab - under Components


        // Add New Layout
        public void AddLayout(string title, [Optional] string description, [Optional] string lastName,
            [Optional] string givenName, [Optional] string email, [Optional] string addFrom, string saveDescription)
        {
            // click on Manage Layout
            Selenium.SafeClick(OldLayoutManagerElements.ManageLayout);
            Selenium.WaitForElementPresent(OldLayoutManagerElements.LayoutsTab);

            // click on new layout
            Selenium.SafeClick(OldLayoutManagerElements.NewLayout);
            Thread.Sleep(4000);
            //Selenium.WaitForElementPresent(UIElements.OldLayoutManagerElements.NewLayoutTitleTextBox);

            // select New Layout pop up
            Selenium.SelectFrameById("newPageWizard");

            // enter title
            Selenium.SafeType(OldLayoutManagerElements.NewLayoutTitleTextBox, title);

            // enter description
            if (description != null)
            {
                Selenium.SafeType(OldLayoutManagerElements.NewLayoutDescriptionTextArea, description);
            }

            Selenium.SwitchTo().DefaultContent();

            // click on Next button
            Selenium.SafeClick(OldLayoutManagerElements.NewLayoutNextButton);
            Thread.Sleep(2000);
 
            // Add User
            AddUsersAsLayoutOwner(lastName, givenName, email, addFrom);

            Selenium.SwitchTo().DefaultContent();

            // Next
            Selenium.SafeClick(OldLayoutManagerElements.NewLayoutNextButton);

            // Select Template

            Selenium.SwitchTo().DefaultContent();

            // Next
            Selenium.SafeClick(OldLayoutManagerElements.NewLayoutNextButton);
            Selenium.WaitForElementPresent(OldLayoutManagerElements.NewLayoutFinishButton);

            Selenium.SwitchTo().DefaultContent();

            // Finish
            Selenium.SafeClick(OldLayoutManagerElements.NewLayoutFinishButton);
            Selenium.WaitForElementPresent(OldLayoutManagerElements.Properties);
            
            // Save
            Selenium.SafeClick(OldLayoutManagerElements.NewLayoutSaveOption);
            Selenium.WaitForElementPresent(OldLayoutManagerElements.NewLayoutPublishLiveOption);
            Selenium.SafeClick(OldLayoutManagerElements.NewLayoutPublishLiveOption);
            Selenium.WaitForElementPresent(OldLayoutManagerElements.NewLayoutSavePopupDescriptionTextArea);

            Selenium.SwitchTo().DefaultContent();
                   
            // enter description
           Selenium.SafeType(OldLayoutManagerElements.NewLayoutSavePopupDescriptionTextArea, saveDescription);

            // save
            Selenium.SafeClick(OldLayoutManagerElements.NewLayoutSavePopupSaveButton);
            Selenium.WaitForElementPresent(OldLayoutManagerElements.SubsiteTemplatesTab);


        }

        // Verify that Layout gets added
        public void VerifyLayout(string title)
        {
            // navigate to Edit Layout page


        }

    }

    }
