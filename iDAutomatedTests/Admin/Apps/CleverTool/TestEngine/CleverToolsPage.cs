using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using System.Web;
using NUnit.Framework;
using iDAutomatedTests.Admin.Apps.CleverTool.TestEngine;
using Core.Base;
using Core.Wrappers;
using Core.Generic.Locators;
using Core.AppModules.Admin;
using iDAutomatedTests.Admin.Apps.CleverTool.Locators;

namespace iDAutomatedTests.Admin.Apps.CleverTool.TestEngine
{
    public class CleverToolsPage:AdminCommonUtilities
    {
        // Constructor
        public CleverToolsPage():base()
        {
        }
        // Expand Clever Tools
            
        // Navigate to Clever Tools
        public void NavigateToCleverTools(string subsiteName, string applicationName)
        {
            Expandsubsite(subsiteName);
            ExpandApplication(applicationName);
        }

        //Swicth to Clever tool submenu otion Edit Icons --> Show Icons On Front End Check box

        public void switchToClevertoolsubmenuEditIconsShowIconsOnFECheckbox()
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("menu");

            Selenium.WaitForElementPresent(CleverToolsPageElements.EditIconsSubMenuOption);
            Selenium.SafeClick(CleverToolsPageElements.EditIconsSubMenuOption);

            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("main");

            Selenium.WaitForElementPresent(CleverToolsPageElements.EditIconsShowIconsOnFrontEnd);
            Selenium.SafeClick(CleverToolsPageElements.EditIconsShowIconsOnFrontEnd);
        }

        public void switchToClverToolEditTools()
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("menu");

            Selenium.WaitForElementPresent(CleverToolsPageElements.EditToolSubMenuOption);
            Selenium.SafeClick(CleverToolsPageElements.EditToolSubMenuOption);

            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("main");

            Selenium.WaitForElementPresent(CleverToolsPageElements.EditToolsNameColumnHeader);
        }

        // Verify Sub menu options
        public void VerifySubMenuOptions(string expectedAddTool, string expectedEditTools, string expectedEditIcons)
        {
            string actualAddTool = Selenium.SafeGetText(CleverToolsPageElements.AddToolSubMenuOption);
            string actualEditTools =
                Selenium.SafeGetText(CleverToolsPageElements.EditToolSubMenuOption);
            string actualEditIcons =
                Selenium.SafeGetText(CleverToolsPageElements.EditIconsSubMenuOption);

            Assert.AreEqual(expectedAddTool,actualAddTool);
            Assert.AreEqual(expectedEditTools, actualEditTools);
            Assert.AreEqual(expectedEditIcons, actualEditIcons);
        }

        // Add applications in Clever Tool
        public void AddCleverTool(string[] applicationList, string location, int numberOfApps)
        {
            for (int count = 0; count < numberOfApps; count++)
            {
                Selenium.SwitchTo().DefaultContent();
                Selenium.SelectFrameById("menu");

                Selenium.WaitForElementPresent(CleverToolsPageElements.AddToolSubMenuOption);
                Selenium.SafeClick(CleverToolsPageElements.AddToolSubMenuOption);

                Selenium.SwitchTo().DefaultContent();
                Selenium.SelectFrameById("main");

                Selenium.WaitForElementPresent(CleverToolsPageElements.AddToolApplicationDropDownList);

                // select Appication
                Selenium.SafeSelect(CleverToolsPageElements.AddToolApplicationDropDownList, applicationList[count]);
                Thread.Sleep(2000);

                // select Location
                if (location == "List Item")
                {
                    Selenium.SafeClick(CleverToolsPageElements.AddToolLocationListItem);
                    Thread.Sleep(2000);
                }
                else
                {
                    Selenium.SafeClick(CleverToolsPageElements.AddToolLocationDropDownItem);
                    Thread.Sleep(2000);
                }

                // click on OK
                Selenium.SafeClick(CleverToolsPageElements.AddToolOKButton);
                Selenium.WaitForElementPresent(CleverToolsPageElements.EditToolsNameColumnHeader);
            }
        }

        // Verify Clever Tool added
        public void VerifyCleverToolAdded(string[] applicatioList, string location, int numberOfAppsAdded)
        {
            for (int count = 0; count < numberOfAppsAdded; count++)
            {
                switchToClverToolEditTools();
                // select Location tab
                if (location == "List Item")
                {
                    Selenium.SafeClick(CleverToolsPageElements.EditToolListItemsTab);
                    Thread.Sleep(2000);
                    Selenium.WaitForElementPresent(CleverToolsPageElements.EditToolsNameColumnHeader);
                }
                else
                {
                    Selenium.SafeClick(CleverToolsPageElements.EditToolDropDownItemsTab);
                    Thread.Sleep(2000);
                    Selenium.WaitForElementPresent(CleverToolsPageElements.EditToolsNameColumnHeader);
                }

                // verify
                Assert.IsTrue(Selenium.IsElementPresent(String.Format(CleverToolsPageElements.EditToolsApplicationName, applicatioList[count])));
            }
        }

        // Delete Clever Tool
        public void DeleteCleverToolFromList(string[] applicationList, string location, int numberOfApps)
        {
            for (int count = 0; count < numberOfApps; count++)
            {
                switchToClverToolEditTools();

                // select Location tab
                if (location == "List Item")
                {
                    Selenium.SafeClick(CleverToolsPageElements.EditToolListItemsTab);
                    Thread.Sleep(2000);
                    Selenium.WaitForElementPresent(CleverToolsPageElements.EditToolsNameColumnHeader);
                }
                else
                {
                    Selenium.SafeClick(CleverToolsPageElements.EditToolDropDownItemsTab);
                    Thread.Sleep(2000);
                    Selenium.WaitForElementPresent(CleverToolsPageElements.EditToolsNameColumnHeader);
                }

                // delete
                Selenium.SafeClick(String.Format(CleverToolsPageElements.RemoveCleverToolButton, applicationList[count]));

                IAlert javascriptAlert = Selenium.SwitchTo().Alert();

                // Click on OK button
                javascriptAlert.Accept();

                Thread.Sleep(3000);

            }
        }

        // Delete Clever Tool from drop down
        public void DeleteCleverToolFromDropDownList(string[] applicationList, string location, int numberOfApps)
        {
            for (int count = 0; count < numberOfApps; count++)
            {
                switchToClverToolEditTools();

                // select Location tab
                if (location == "List Item")
                {
                    Selenium.SafeClick(CleverToolsPageElements.EditToolListItemsTab);
                    Thread.Sleep(2000);
                    Selenium.WaitForElementPresent(CleverToolsPageElements.EditToolsNameColumnHeader);
                    // delete
                    Selenium.SafeClick(String.Format(CleverToolsPageElements.RemoveCleverToolButton, applicationList[count]));
                }
                else
                {
                    Selenium.SafeClick(CleverToolsPageElements.EditToolDropDownItemsTab);
                    Thread.Sleep(2000);
                    Selenium.WaitForElementPresent(CleverToolsPageElements.EditToolsNameColumnHeader);
                    // delete 
                    Selenium.SafeClick(String.Format(CleverToolsPageElements.RemoveCleverToolButtonDropDownList, applicationList[count]));
                }

               

                IAlert javascriptAlert = Selenium.SwitchTo().Alert();

                // Click on OK button
                javascriptAlert.Accept();

                Thread.Sleep(3000);

            }
        }

        // Verify Clever Tool Deleted
        public void VerifyCleverToolDeleted(string[] applicationList, string location, int numberOfApps)
        {
            for (int count = 0; count < numberOfApps; count++)
            {
                switchToClverToolEditTools();
                // select Location tab
                if (location == "List Item")
                {
                    Selenium.SafeClick(CleverToolsPageElements.EditToolListItemsTab);
                    Thread.Sleep(2000);
                    Selenium.WaitForElementPresent(CleverToolsPageElements.EditToolsNameColumnHeader);
                }
                else
                {
                    Selenium.SafeClick(CleverToolsPageElements.EditToolDropDownItemsTab);
                    Thread.Sleep(2000);
                    Selenium.WaitForElementPresent(CleverToolsPageElements.EditToolsNameColumnHeader);
                }

                // verify
                Assert.IsTrue(Selenium.IsElementNotPresent(String.Format(CleverToolsPageElements.EditToolsApplicationName, applicationList[count])));
            }
        }

         // Verify that Show Icons on front end checkbox is checked.
        public bool VerifyEditIconShowIconsOnFrontEndChecked(string locator)
        {
            switchToClevertoolsubmenuEditIconsShowIconsOnFECheckbox();
            
            bool IsChecked=Selenium.IsChecked(locator);

            if(IsChecked)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        // Check that Edit icons in clever tool is checked and retains it's value
        public void EditIconsShowIconsOnFrontEndRetainsChekedValue()
        {

            CheckEditIconsShowIconsOnFrontEndCheckbox();

            Assert.AreEqual(true, VerifyEditIconShowIconsOnFrontEndChecked(CleverToolsPageElements.EditIconsShowIconsOnFrontEnd));
        }

        //Uncheck Show Icons on front end checkbox
        public void UncheckEditIconsShowIconsOnFrontEndCheckbox()
        {

            if (VerifyEditIconShowIconsOnFrontEndChecked(CleverToolsPageElements.EditIconsShowIconsOnFrontEnd))
            {
                switchToClevertoolsubmenuEditIconsShowIconsOnFECheckbox();

                //Click on OK

                Selenium.SafeClick(CleverToolsPageElements.EditIconsOKButton);
            }
           
        }

        //Check Show Icons on front end checkbox
        public void CheckEditIconsShowIconsOnFrontEndCheckbox()
        {

            if (!VerifyEditIconShowIconsOnFrontEndChecked(CleverToolsPageElements.EditIconsShowIconsOnFrontEnd))
            {

                switchToClevertoolsubmenuEditIconsShowIconsOnFECheckbox();
                //Click on OK

                Selenium.SafeClick(CleverToolsPageElements.EditIconsOKButton);
            }
        }

        //Verify that Show Icons on front end checkbox is not checked by default.

        public void VerifyEditIconsShowIconsFrontEndCheckboxIsNotChecked()
        {
            switchToClevertoolsubmenuEditIconsShowIconsOnFECheckbox();
            
            //verify checkbox is not checked

            try
            {
                Assert.AreEqual(false, VerifyEditIconShowIconsOnFrontEndChecked(CleverToolsPageElements.EditIconsShowIconsOnFrontEnd));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Move Up the appliocation
        public void moveUpApplication(string [] applicationList,string location,string nameOfAppToMove,int positionOfAppToMoveUp,int whereToMovePosition)
        {
            switchToClverToolEditTools();

            // select Location tab
            if (location == "List Item")
            {
                Selenium.SafeClick(CleverToolsPageElements.EditToolListItemsTab);
                Thread.Sleep(2000);
                Selenium.WaitForElementPresent(CleverToolsPageElements.EditToolsNameColumnHeader);

                //Check if position to be moved is indeed up and currently we are limiting the check so that Move is tested only in first page with maximum 10 apps
                if ((positionOfAppToMoveUp - whereToMovePosition) > 0 && positionOfAppToMoveUp <= 10)
                {
                    //Run the counter and click Move UP button depending on the position given.
                    for (int count = 0; count < (positionOfAppToMoveUp - whereToMovePosition); count++)
                    {
                        Selenium.SafeClick(String.Format(CleverToolsPageElements.EditToolMoveUpButtonInListItems, nameOfAppToMove));
                    }
                }
                else
                {
                    Assert.Fail("Wrong test data inserted hence move up can not be done: Please review the test data");
                }
            }
            else
            {
                //Move up in drop down
                Selenium.SafeClick(CleverToolsPageElements.EditToolDropDownItemsTab);
                Thread.Sleep(2000);
                Selenium.WaitForElementPresent(CleverToolsPageElements.EditToolsNameColumnHeader);

                if ((positionOfAppToMoveUp - whereToMovePosition) > 0 && positionOfAppToMoveUp<= 10)
                {
                    for (int count = 0; count < (positionOfAppToMoveUp - whereToMovePosition); count++)
                    {
                        Selenium.SafeClick(String.Format(CleverToolsPageElements.EditToolMoveUpButtonInDropDownItems, nameOfAppToMove));
                    }
                }
                else
                {
                    Assert.Fail("Wrong test data inserted hence move up can not be done: Please review the test data");
                }
            }
            
        }

        //Verify Move
        public void verifyMoveIsSuccess(string []applicationList,string location,string nameOfAppToMove,int whereToMovePosition)
        {
            switchToClverToolEditTools();
            if (location == "List Item")
            {
                Selenium.SafeClick(CleverToolsPageElements.EditToolListItemsTab);
                Thread.Sleep(2000);
                Selenium.WaitForElementPresent(CleverToolsPageElements.EditToolsNameColumnHeader);

                //Verify that clever tool is moved to position 'whereToMovePostion' in List Items
                Assert.IsTrue(Selenium.IsElementPresent(String.Format(CleverToolsPageElements.TableForAppsInListItems, (whereToMovePosition + 1), nameOfAppToMove)));
            }
            else
            {
                Selenium.SafeClick(CleverToolsPageElements.EditToolDropDownItemsTab);
                Thread.Sleep(2000);
                Selenium.WaitForElementPresent(CleverToolsPageElements.EditToolsNameColumnHeader);

                //Verify that clever tool is moved to position 'whereToMovePostion' in Drop Down Items
                Assert.IsTrue(Selenium.IsElementPresent(String.Format(CleverToolsPageElements.TableForAppsInDropDownItems, (whereToMovePosition + 1), nameOfAppToMove)));
            }
        }
    }
}
