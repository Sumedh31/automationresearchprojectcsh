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

using iDAutomatedUITests.PageObjects;
using iDAutomatedUITests.Helpers;
using OpenQA.Selenium.Interactions;

namespace iDAutomatedUITests.PageObjects
{
    public class LayoutManager
    {
        // Webdriver object
        private readonly IWebDriver _layoutManager;

        // Constructor
        public LayoutManager(IWebDriver driver)
        {
            _layoutManager = driver;
        }

        // Manage Layout
        public void ManageLayout()
        {
            _layoutManager.SafeClick(UIElements.LayoutManagerElements.ManageLayout);
            _layoutManager.WaitForElementPresent(UIElements.LayoutManagerElements.LayoutsTab);
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
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.LayoutManagerElements.ManageLayout));
        }

        // Verify Edit Layout option is present
        public void VerifyEditLayoutOption()
        {
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.LayoutManagerElements.EditLayoutOption));
        }

        // Verify Help option
        public void VerifyHelpOption()
        {
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.LayoutManagerElements.Help));
        }

        // Collections - Verify the Edit Drop Down List
        public void VerifyEditDropDownList()
        {
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsLayoutManagerElements.EditLayout));

            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.EditLayout);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.EditLayoutDraft);
            Thread.Sleep(2000);

            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsLayoutManagerElements.EditLayoutDraft));
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsLayoutManagerElements.EditLayoutStaging));
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsLayoutManagerElements.EditLayoutLive));
        }

        // Collections - Verify that Edit Drop Down List disappears after clicking on Edit again
        public void VerifyEditDropDownListDisappears()
        {
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsLayoutManagerElements.EditLayout));

            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.EditLayout);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.EditLayoutDraft);
            Thread.Sleep(2000);

            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.EditLayoutDropDownList);
            Thread.Sleep(3000);

            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsLayoutManagerElements.EditLayout));
        }

        // Collections - Verify that creator cannot view the Edit drop down list
        public void VerifyCreatorCannotViewEditOption()
        {
            Assert.IsTrue(_layoutManager.IsElementNotPresent(UIElements.CollectionsLayoutManagerElements.EditLayout));
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsLayoutManagerElements.ManagerLayout));
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsLayoutManagerElements.LayoutHelp));
        }

        // Collections - Verify that Contributor can view the Edit Layout drop down list
        public void VerifyContributorCanViewEditOption()
        {
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsLayoutManagerElements.EditLayout));
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsLayoutManagerElements.ManagerLayout));
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsLayoutManagerElements.LayoutHelp));
        }

        // Collections - Verify that Read Only User cannot view Edit Layout drop down list
        public void VerifyReadOnlyCannotViewEditOption()
        {
            Assert.IsTrue(_layoutManager.IsElementNotPresent(UIElements.CollectionsLayoutManagerElements.EditLayout));
            Assert.IsTrue(_layoutManager.IsElementNotPresent(UIElements.CollectionsLayoutManagerElements.ManagerLayout));
            Assert.IsTrue(_layoutManager.IsElementNotPresent(UIElements.CollectionsLayoutManagerElements.LayoutHelp));
        }

        // Collections - Navigate to Manage Layout page
        public void NavigateToManageLayout()
        {
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManagerLayout);
            Thread.Sleep(2000);

            _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.AddOptionOff);
            
        }

        // Collections - Navigate to Home Subsite
        public void NavigateToHomeSubsite()
        {
            Thread.Sleep(2000);
            _layoutManager.Open(ApplicationSettings.ApplicationSettings.HomeSubsiteURL);
            Thread.Sleep(4000);
        }

        // Collections - Verify Add + drop down list
        public void VerifyAddPlusDropDownList(string newLayout, string newSubsiteTemplate)
        {
            string actualLayoutText, actualSubsiteTemplateText;
            
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.AddOptionOff);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.AddOptionOn);

            // Verify New Layout Option
            actualLayoutText= _layoutManager.SafeGetText(UIElements.CollectionsLayoutManagerElements.stewart);
            Assert.AreEqual(newLayout,actualLayoutText);

            // Verify New Subsite Template
            actualSubsiteTemplateText =
                _layoutManager.SafeGetText(UIElements.CollectionsLayoutManagerElements.AddNewSubsiteTemplate);
            Assert.AreEqual(newSubsiteTemplate, actualSubsiteTemplateText);

        }

        // Collections - Verify Actiosn drop down list on Manage Layout
        public void VerifyActionsDropDownList(string editProperties, string recycleBin)
        {
            string actualEditPropertiesText, actualRecycleBinText;

            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutActionsOff);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.ManageLayoutActionsOn);

            // verify edit properties
            actualEditPropertiesText =
                _layoutManager.SafeGetText(UIElements.CollectionsLayoutManagerElements.ManageLayoutActionsEditProperties);
            Assert.AreEqual(editProperties,actualEditPropertiesText);

            // verify recycle bin
            actualRecycleBinText =
                _layoutManager.SafeGetText(UIElements.CollectionsLayoutManagerElements.ManageLayoutActionsRecycleBin);
            Assert.AreEqual(recycleBin, actualRecycleBinText);
        }

        // Collections - Create New Subsite Template
        public void AddNewSubsiteTemplate(string templateName, [Optional] string description, [Optional] int rows, int applicationArea)
        {
            // Click on New Subsite Template
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.AddOptionOff);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.AddNewSubsiteTemplate);
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.AddNewSubsiteTemplate);
            Thread.Sleep(4000);
            _layoutManager.SelectFrameById("newTemplateModal");

            // Enter Name
            _layoutManager.SafeType(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateNameTextfield, templateName);

            // Enter Description
            if (description != null)
            {
                _layoutManager.SafeType(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateDescriptionTextarea, description);
            }

            _layoutManager.SwitchTo().DefaultContent();

            // Move to Subsite step
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateNextButton);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateBackButton);

            // Move to Finish step
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateNextButton);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateFinishButton);

            // Click on Finish
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateFinishButton);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateSaveButton);

            // Insert rows
            if (rows > 0)
            {
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateStructureInsert);
                Thread.Sleep(2000);

                for (int i = 1; i <= rows; i++)
                {
                    _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.NewSubisteTemplateInsertRowBelowCell);
                    _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubisteTemplateInsertRowBelowCell);
                    Thread.Sleep(2000);
                }
             }

            // Select Application Area
            SelectApplicationArea(applicationArea);
            
           // Save
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateSaveButton);
            Thread.Sleep(2000);

            _layoutManager.SwitchTo().DefaultContent();

            _layoutManager.SafeType(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateExitDescriptionTextArea,"save subsite template");
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateExitOkButton);
            Thread.Sleep(2000);


        }
        
        // Collections - Edit Subiste Template
        public void EditSubsiteTemplate(string templateName)
        {
            // Navigate to Subsite Template tab
            if (_layoutManager.IsElementPresent(UIElements.CollectionsLayoutManagerElements.ManageLayoutLayoutsTab))
            {
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutLayoutsTab);
                Thread.Sleep(2000);
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
                Thread.Sleep(2000);
            }
            else
            {
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
                Thread.Sleep(2000);
            }

            // Edit the created template
            _layoutManager.SafeClick(string.Format(UIElements.CollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTemplateLocator, templateName));
            _layoutManager.WaitForElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutSaveEditing);
            Thread.Sleep(2000);

           }

        // Collections - Make Template as Default
        public void MakeSubsiteTemplateDefault(string templateName)
        {
            // Navigate to Subsite Template tab
            if (_layoutManager.IsElementPresent(UIElements.CollectionsLayoutManagerElements.ManageLayoutLayoutsTab))
            {
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutLayoutsTab);
                Thread.Sleep(2000);
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
                Thread.Sleep(2000);
            }
            else
            {
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
                Thread.Sleep(2000);
            }

            // Make Template Default
            _layoutManager.SafeClick(string.Format(UIElements.CollectionsLayoutManagerElements.ManageLayoutDefaultRadioOptionLocator, templateName));
            Thread.Sleep(2000);
        }

        // Collections - Add New Subsite Layout
        public void AddNewSubsiteLayout(string layoutName, [Optional] string layoutDescription, [Optional] int layoutRows, int layoutApplicationArea)
        {
            // Click on New Layout
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.AddOptionOff);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.stewart);
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.stewart);
            Thread.Sleep(4000);

            // Select New Layout Wizard
            _layoutManager.SelectFrameById("newPageWizard");

            // Enter Title
            _layoutManager.SafeType(UIElements.CollectionsAddNewLayoutElements.AddNewLayoutTitleTextBox, layoutName);

            // Enter Description
            if (layoutDescription != null)
            {
                _layoutManager.SafeType(UIElements.CollectionsAddNewLayoutElements.AddNewLayoutDescriptionTextBox, layoutDescription);
            }

            _layoutManager.SwitchTo().DefaultContent();

            // Move to Owner steps
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateNextButton);
            Thread.Sleep(2000);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateBackButton);

            // Move to Templates step
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateNextButton);
            Thread.Sleep(2000);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateBackButton);
            
            // Move to Finish step
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateNextButton);
            Thread.Sleep(2000);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateFinishButton);
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateFinishButton);
            Thread.Sleep(4000);

            // Save and Publish to Live
            _layoutManager.WaitForElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutSaveOption);
            _layoutManager.SafeClick(UIElements.CollectionsEditLayoutElements.EditLayoutSaveOption);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutPublishLiveExit);
            _layoutManager.SafeClick(UIElements.CollectionsEditLayoutElements.EditLayoutPublishLiveExit);
            Thread.Sleep(4000);

            _layoutManager.SwitchTo().DefaultContent();

            // Save Layout with comments
            _layoutManager.SafeType(UIElements.CollectionsEditLayoutElements.EditLayoutSaveDescriptionTextArea, "saving subsite layout");
            _layoutManager.SafeClick(UIElements.CollectionsEditLayoutElements.EditLayoutSaveButtonSavePopup);
            Thread.Sleep(4000);


        }

        // Collections - Edit Subiste Template
        public void EditSubsiteLayout(string layoutName)
        {
            // Navigate to Subsite Layouts tab
            if (_layoutManager.IsElementPresent(UIElements.CollectionsLayoutManagerElements.ManageLayoutLayoutsTab))
            {
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
                Thread.Sleep(2000);
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutLayoutsTab);
                Thread.Sleep(2000);
            }
            else
            {
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutLayoutsTab);
                Thread.Sleep(2000);
            }

            // Edit the created Layout
            _layoutManager.SafeClick(string.Format(UIElements.CollectionsLayoutManagerElements.ManageLayoutEditLayoutLocator, layoutName));
            _layoutManager.WaitForElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutSaveOption);
            Thread.Sleep(2000);

        }

        // Collections - Apply Layout
        public void ApplyLayout(string layoutName)
        {
            // Navigate to Subsite Layouts tab
            if (_layoutManager.IsElementPresent(UIElements.CollectionsLayoutManagerElements.ManageLayoutLayoutsTab))
            {
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
                Thread.Sleep(2000);
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutLayoutsTab);
                Thread.Sleep(2000);
            }
            else
            {
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutLayoutsTab);
                Thread.Sleep(2000);
            }

            // Apply Layout
            _layoutManager.SafeClick(string.Format(UIElements.CollectionsLayoutManagerElements.ManageLayoutAppliedRadioOptionLocator, layoutName));
            Thread.Sleep(2000);
        }

        // Collections - Select Application Area
        public void SelectApplicationArea(int applicationAreaRow)
        {
            if (applicationAreaRow >= 0)
            {
                _layoutManager.SafeClick(String.Format(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateRowSelector, applicationAreaRow));
                _layoutManager.SafeClick(String.Format(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateCellApplicationAreaSelector, applicationAreaRow));
                Thread.Sleep(2000);
            }
           }

        // Collections - Add Footer Component
        public void AddFooterComponent(int rownumber, string entity )
        {
            if (entity == "Template")
            {
             _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateComponentsTab);
             _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateComponentsTab);
             _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateComponentsSiteFramework);
            }
            else
            {
               _layoutManager.WaitForElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutComponentsTab); 
               _layoutManager.SafeClick(UIElements.CollectionsEditLayoutElements.EditLayoutComponentsTab);
               _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateComponentsSiteFramework);
            }
            
            _layoutManager.SwitchTo().DefaultContent();
            
            string droppableLocator =
                    String.Format(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateComponentsRowSelector, rownumber);

            Thread.Sleep(2000);

            _layoutManager.SafeDragAndDrop(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateComponentsFrameworkSiteFooter,droppableLocator);

            Thread.Sleep(2000);
                
            _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateComponentsSiteFramework);

            // Save Template/Layout
            if (entity == "Template")
            {
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateSaveButton);
                Thread.Sleep(2000);
                _layoutManager.SwitchTo().DefaultContent();

                _layoutManager.SafeType(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateExitDescriptionTextArea, "added Footer component in the subsite template");
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateExitOkButton);
                Thread.Sleep(2000);
            }
            else
            {
                _layoutManager.SafeClick(UIElements.CollectionsEditLayoutElements.EditLayoutSaveOption);
                Thread.Sleep(4000);
                _layoutManager.WaitForElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutPublishLiveExit);
                _layoutManager.SafeClick(UIElements.CollectionsEditLayoutElements.EditLayoutPublishLiveExit);
                Thread.Sleep(2000);
                _layoutManager.SwitchTo().DefaultContent();
                _layoutManager.SafeType(UIElements.CollectionsEditLayoutElements.EditLayoutSaveDescriptionTextArea, "added Footer component in the subsite layout");
                _layoutManager.SafeClick(UIElements.CollectionsEditLayoutElements.EditLayoutSaveButtonSavePopup);
                Thread.Sleep(4000);
            }
            

            
        }

        // Collections - Add Header Component
        public void AddHeaderComponent(int rownumber, string entity)
        {
            if (entity == "Template")
            {
                _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateComponentsTab);
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateComponentsTab);
                _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateComponentsSiteFramework);
            }
            else
            {
                _layoutManager.WaitForElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutComponentsTab);
                _layoutManager.SafeClick(UIElements.CollectionsEditLayoutElements.EditLayoutComponentsTab);
                _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateComponentsSiteFramework);
            }
            
            _layoutManager.SwitchTo().DefaultContent();

            string droppableLocator =
                String.Format(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateComponentsRowSelector, rownumber);

            Thread.Sleep(2000);

            _layoutManager.SafeDragAndDrop(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateComponentsFrameworkSiteHeader, droppableLocator);

            Thread.Sleep(2000);

            _layoutManager.WaitForElementPresent(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateComponentsSiteFramework);

            // Save Template/Layout
            if (entity == "Template")
            {
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateSaveButton);
                Thread.Sleep(2000);
                _layoutManager.SwitchTo().DefaultContent();

                _layoutManager.SafeType(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateExitDescriptionTextArea, "added Footer component in the subsite template");
                _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.NewSubsiteTemplateExitOkButton);
                Thread.Sleep(2000);
            }
            else
            {
                _layoutManager.SafeClick(UIElements.CollectionsEditLayoutElements.EditLayoutSaveOption);
                Thread.Sleep(4000);
                _layoutManager.WaitForElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutPublishLiveExit);
                _layoutManager.SafeClick(UIElements.CollectionsEditLayoutElements.EditLayoutPublishLiveExit);
                Thread.Sleep(2000);
                _layoutManager.SwitchTo().DefaultContent();
                _layoutManager.SafeType(UIElements.CollectionsEditLayoutElements.EditLayoutSaveDescriptionTextArea, "added Footer component in the subsite layout");
                _layoutManager.SafeClick(UIElements.CollectionsEditLayoutElements.EditLayoutSaveButtonSavePopup);
                Thread.Sleep(4000);
            }
        }

        // Collections - Verify that Template is created successfully
        public void VerifySubsiteTemplate(string templateName)
        {
            // Cick on Subsite Template tab
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
            Thread.Sleep(2000);

            // verify that template exists
            _layoutManager.IsElementPresent(
                String.Format(UIElements.CollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTemplateLocator, templateName));
        }

        // Collections - Delete Subsite Template
        public void DeleteSubsiteTemplate(string templateName)
        {
            // Cick on Subsite Template tab
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
            Thread.Sleep(2000);

            // Select Template check box
            _layoutManager.SafeClick(String.Format(UIElements.CollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTemplateCheckBox,templateName));

            // Select Delete Option
            _layoutManager.SafeSelect(UIElements.CollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesActionsDropDownList, "Delete");
            Thread.Sleep(2000);

            _layoutManager.SwitchTo().DefaultContent();

            // Click on OK
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesDeletePopupOkButton);
            Thread.Sleep(4000);
        }

        // Collections - Verify that Template is deleted successfully
        public void VerifySubsiteTemplateDeleted(string templateName)
        {
            // Cick on Subsite Template tab
            _layoutManager.SafeClick(UIElements.CollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTab);
            Thread.Sleep(2000);

            // verify that template exists
            _layoutManager.IsElementNotPresent(
                String.Format(UIElements.CollectionsLayoutManagerElements.ManageLayoutSubsiteTemplatesTemplateLocator, templateName));
        }

        // Collections - Verify Manage Layout on Edit Layout
        public void VerifyManageLayoutForEditLayout()
        {
            _layoutManager.IsElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutManageLayout);
            Thread.Sleep(2000);
        }

        // Collections - Edit Layout Live version
        public void EditLayoutLive()
        {
            // Edit Live version
            _layoutManager.SafeClick(UIElements.CollectionsEditLayoutElements.EditLayoutEditOption);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutEditDropDownList);
            _layoutManager.SafeClick(UIElements.CollectionsEditLayoutElements.EditLayoutEditLive);
            Thread.Sleep(3000);
        }

        // Collections - Verify Save Drop Down List for Edit Layout
        public void VerifySaveDropDownListEditLayout()
        {
            _layoutManager.IsElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutSaveOption);
            _layoutManager.SafeClick(UIElements.CollectionsEditLayoutElements.EditLayoutSaveOption);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutSaveDropDownList);

            // Verify 'Save a Draft & Continue Editing' option
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutSaveDraftContinueEditing));

            // Verify 'Save a Draft & Exit' option
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutSaveDraftExit));

            // Verify 'Publish to Staging & Exit' option
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutPublishStagingExit));

            // Verify 'Publish to Live & Exit' option
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutPublishLiveExit));
        }

        // Collections - Verify Edit drop down list options for Edit Layout
        public void VerifyEditDropDownListOptionsForEditLayout()
        {
            _layoutManager.IsElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutEditOption);
            _layoutManager.SafeClick(UIElements.CollectionsEditLayoutElements.EditLayoutEditOption);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutEditDropDownList);

            // Verify 'Draft' option
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutEditDraft));

            // Verify 'Staging' option
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutEditStaging));

            // Verify 'Live' option
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutEditLive));
            }

        // Collections - Verify Actions Drop Down List Options for Edit Layout
        public void VerifyActionsDropDownListOptionsEditLayot()
        {
            _layoutManager.IsElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutActionOption);
            _layoutManager.SafeClick(UIElements.CollectionsEditLayoutElements.EditLayoutActionOption);
            _layoutManager.WaitForElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutActionsDropDownList);

            // Verify 'Edit Properties' option
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutActionsEditProperties));

            // Verify 'Move Layout' option
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutActionsEditProperties));
           
            // Verify 'Delete Layout' option
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutActionsDeleteLayout));

            // Verify 'Revert Layout' option
            Assert.IsTrue(_layoutManager.IsElementPresent(UIElements.CollectionsEditLayoutElements.EditLayoutActionsRevertLayout));
        }

        // Add Users as Layout Owners from wizard
        public void AddUsersAsLayoutOwner([Optional] string lastName,[Optional] string givenName,[Optional] string email,[Optional] string addFrom)
        {
            // select New Layout pop up
            _layoutManager.SelectFrameById("newPageWizard");
            
            // click on Add User/s button
            _layoutManager.SafeClick(UIElements.LayoutManagerElements.NewLayoutOwnerTabAddUsersButton);
            _layoutManager.WaitForElementPresent(UIElements.LayoutManagerElements.NewLayoutOwnerTabFindUserGivenNameTextBox);

            // enter Last Name
            if (lastName != null)
                _layoutManager.SafeType(UIElements.LayoutManagerElements.NewLayoutOwnerTabFindUserLastNameTextBox,
                    lastName);
            
            // enter Given Name
            if (givenName != null)
                _layoutManager.SafeType(UIElements.LayoutManagerElements.NewLayoutOwnerTabFindUserGivenNameTextBox,
                    givenName);
            
            // enter Email
            if (email != null)
                _layoutManager.SafeType(UIElements.LayoutManagerElements.NewLayoutOwnerTabFindUserEmailTextBox,email);
            
            // select AddFrom
            if (addFrom != null)
                _layoutManager.SafeSelect(UIElements.LayoutManagerElements.NewLayoutOwnerTabFindUserAddFromDropDownList, addFrom);

            // Search
            _layoutManager.SafeClick(UIElements.LayoutManagerElements.NewLayoutOwnerTabFindUserSearchButton);
            _layoutManager.WaitForElementPresent(UIElements.LayoutManagerElements.NewLayoutOwnerTabFindUserGuestCheckBox);

            // Select any user 

            // Select guest user
            _layoutManager.SafeClick(UIElements.LayoutManagerElements.NewLayoutOwnerTabFindUserGuestCheckBox);
            _layoutManager.WaitForElementPresent(UIElements.LayoutManagerElements.NewLayoutOwnerTabFindUserOkButton);

            // Click on OK
            _layoutManager.SafeClick(UIElements.LayoutManagerElements.NewLayoutOwnerTabFindUserOkButton);
            _layoutManager.WaitForElementNotPresent(UIElements.LayoutManagerElements.NewLayoutOwnerTabFindUserOkButton);
            Thread.Sleep(2000);

   }

        // Navigate to Applicatiosn sub tab - under Components


        // Add New Layout
        public void AddLayout(string title, [Optional] string description, [Optional] string lastName,
            [Optional] string givenName, [Optional] string email, [Optional] string addFrom, string saveDescription)
        {
            // click on Manage Layout
            _layoutManager.SafeClick(UIElements.LayoutManagerElements.ManageLayout);
            _layoutManager.WaitForElementPresent(UIElements.LayoutManagerElements.LayoutsTab);

            // click on new layout
            _layoutManager.SafeClick(UIElements.LayoutManagerElements.NewLayout);
            Thread.Sleep(4000);
            //_layoutManager.WaitForElementPresent(UIElements.LayoutManagerElements.NewLayoutTitleTextBox);

            // select New Layout pop up
            _layoutManager.SelectFrameById("newPageWizard");

            // enter title
            _layoutManager.SafeType(UIElements.LayoutManagerElements.NewLayoutTitleTextBox, title);

            // enter description
            if (description != null)
            {
                _layoutManager.SafeType(UIElements.LayoutManagerElements.NewLayoutDescriptionTextArea, description);
            }

            _layoutManager.SwitchTo().DefaultContent();

            // click on Next button
            _layoutManager.SafeClick(UIElements.LayoutManagerElements.NewLayoutNextButton);
            Thread.Sleep(2000);
 
            // Add User
            AddUsersAsLayoutOwner(lastName, givenName, email, addFrom);

            _layoutManager.SwitchTo().DefaultContent();

            // Next
            _layoutManager.SafeClick(UIElements.LayoutManagerElements.NewLayoutNextButton);

            // Select Template

            _layoutManager.SwitchTo().DefaultContent();

            // Next
            _layoutManager.SafeClick(UIElements.LayoutManagerElements.NewLayoutNextButton);
            _layoutManager.WaitForElementPresent(UIElements.LayoutManagerElements.NewLayoutFinishButton);

            _layoutManager.SwitchTo().DefaultContent();

            // Finish
            _layoutManager.SafeClick(UIElements.LayoutManagerElements.NewLayoutFinishButton);
            _layoutManager.WaitForElementPresent(UIElements.LayoutManagerElements.Properties);
            
            // Save
            _layoutManager.SafeClick(UIElements.LayoutManagerElements.NewLayoutSaveOption);
            _layoutManager.WaitForElementPresent(UIElements.LayoutManagerElements.NewLayoutPublishLiveOption);
            _layoutManager.SafeClick(UIElements.LayoutManagerElements.NewLayoutPublishLiveOption);
            _layoutManager.WaitForElementPresent(UIElements.LayoutManagerElements.NewLayoutSavePopupDescriptionTextArea);

            _layoutManager.SwitchTo().DefaultContent();
                   
            // enter description
           _layoutManager.SafeType(UIElements.LayoutManagerElements.NewLayoutSavePopupDescriptionTextArea, saveDescription);

            // save
            _layoutManager.SafeClick(UIElements.LayoutManagerElements.NewLayoutSavePopupSaveButton);
            _layoutManager.WaitForElementPresent(UIElements.LayoutManagerElements.SubsiteTemplatesTab);


        }

        // Verify that Layout gets added
        public void VerifyLayout(string title)
        {
            // navigate to Edit Layout page


        }

    }

    }
