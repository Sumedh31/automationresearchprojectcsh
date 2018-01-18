using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

using System.Threading;
using System.Web;
using NUnit.Framework;

using iDAutomatedUITests.PageObjects;
using iDAutomatedUITests.Helpers;

namespace iDAutomatedUITests.PageObjects
{
    public class CleverToolsPage
    {
        // Web Driver object
        private readonly IWebDriver _cleverTools;
        
        

        // Constructor
        public CleverToolsPage(IWebDriver driver)
        {
            _cleverTools = driver;
        }

        // Expand Clever Tools
        public void ExpandCleverTools(string subsiteName)
        {
            _cleverTools.SwitchTo().DefaultContent();
            _cleverTools.SelectFrameById("menu");
            _cleverTools.SafeClick(String.Format(iDAutomatedUITests.UIElements.iDWelcomePageElements.SubsiteExpand, subsiteName, subsiteName));
            Thread.Sleep(2000);
        }

        // Expand Subsite
        public void ExpandSubsite(string subsiteName)
        {
            _cleverTools.SwitchTo().DefaultContent();
            _cleverTools.SelectFrameById("menu");
            //_cleverTools.SafeClick(String.Format(iDAutomatedUITests.UIElements.iDWelcomePageElements.HomeExpand, subsiteName));
            _cleverTools.SafeClick(iDAutomatedUITests.UIElements.iDWelcomePageElements.HomeExpand);
            
            Thread.Sleep(2000);
        }

        // Navigate to Clever Tools
        public void NavigateToCleverTools(string subsiteName, string applicationName)
        {
            ExpandSubsite(subsiteName);
            ExpandCleverTools(applicationName);
        }

        //Swicth to Clever tool submenu otion Edit Icons --> Show Icons On Front End Check box

        public void switchToClevertoolsubmenuEditIconsShowIconsOnFECheckbox()
        {
            _cleverTools.SwitchTo().DefaultContent();
            _cleverTools.SelectFrameById("menu");

            _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditIconsSubMenuOption);
            _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditIconsSubMenuOption);

            _cleverTools.SwitchTo().DefaultContent();
            _cleverTools.SelectFrameById("main");

            _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditIconsShowIconsOnFrontEnd);
            _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditIconsShowIconsOnFrontEnd);
        }

        public void switchToClverToolEditTools()
        {
            _cleverTools.SwitchTo().DefaultContent();
            _cleverTools.SelectFrameById("menu");

            _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolSubMenuOption);
            _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolSubMenuOption);

            _cleverTools.SwitchTo().DefaultContent();
            _cleverTools.SelectFrameById("main");

            _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolsNameColumnHeader);
        }

        // Verify Sub menu options
        public void VerifySubMenuOptions(string expectedAddTool, string expectedEditTools, string expectedEditIcons)
        {
            string actualAddTool =_cleverTools.SafeGetText(iDAutomatedUITests.UIElements.CleverToolsPageElements.AddToolSubMenuOption);
            string actualEditTools =
                _cleverTools.SafeGetText(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolSubMenuOption);
            string actualEditIcons =
                _cleverTools.SafeGetText(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditIconsSubMenuOption);

            Assert.AreEqual(expectedAddTool,actualAddTool);
            Assert.AreEqual(expectedEditTools, actualEditTools);
            Assert.AreEqual(expectedEditIcons, actualEditIcons);
        }

        // Add applications in Clever Tool
        public void AddCleverTool(string[] applicationList, string location, int numberOfApps)
        {
            for (int count = 0; count < numberOfApps; count++)
            {
                _cleverTools.SwitchTo().DefaultContent();
                _cleverTools.SelectFrameById("menu");

                _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.AddToolSubMenuOption);
                _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.AddToolSubMenuOption);

                _cleverTools.SwitchTo().DefaultContent();
                _cleverTools.SelectFrameById("main");

                _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.AddToolApplicationDropDownList);

                // select Appication
                _cleverTools.SafeSelect(iDAutomatedUITests.UIElements.CleverToolsPageElements.AddToolApplicationDropDownList, applicationList[count]);
                Thread.Sleep(2000);

                // select Location
                if (location == "List Item")
                {
                    _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.AddToolLocationListItem);
                    Thread.Sleep(2000);
                }
                else
                {
                    _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.AddToolLocationDropDownItem);
                    Thread.Sleep(2000);
                }

                // click on OK
                _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.AddToolOKButton);
                _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolsNameColumnHeader);
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
                    _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolListItemsTab);
                    Thread.Sleep(2000);
                    _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolsNameColumnHeader);
                }
                else
                {
                    _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolDropDownItemsTab);
                    Thread.Sleep(2000);
                    _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolsNameColumnHeader);
                }

                // verify
                Assert.IsTrue(_cleverTools.IsElementPresent(String.Format(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolsApplicationName, applicatioList[count])));
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
                    _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolListItemsTab);
                    Thread.Sleep(2000);
                    _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolsNameColumnHeader);
                }
                else
                {
                    _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolDropDownItemsTab);
                    Thread.Sleep(2000);
                    _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolsNameColumnHeader);
                }

                // delete
                _cleverTools.SafeClick(String.Format(iDAutomatedUITests.UIElements.CleverToolsPageElements.RemoveCleverToolButton, applicationList[count]));

                IAlert javascriptAlert = _cleverTools.SwitchTo().Alert();

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
                    _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolListItemsTab);
                    Thread.Sleep(2000);
                    _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolsNameColumnHeader);
                    // delete
                    _cleverTools.SafeClick(String.Format(iDAutomatedUITests.UIElements.CleverToolsPageElements.RemoveCleverToolButton, applicationList[count]));
                }
                else
                {
                    _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolDropDownItemsTab);
                    Thread.Sleep(2000);
                    _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolsNameColumnHeader);
                    // delete 
                    _cleverTools.SafeClick(String.Format(iDAutomatedUITests.UIElements.CleverToolsPageElements.RemoveCleverToolButtonDropDownList, applicationList[count]));
                }

               

                IAlert javascriptAlert = _cleverTools.SwitchTo().Alert();

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
                    _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolListItemsTab);
                    Thread.Sleep(2000);
                    _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolsNameColumnHeader);
                }
                else
                {
                    _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolDropDownItemsTab);
                    Thread.Sleep(2000);
                    _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolsNameColumnHeader);
                }

                // verify
                Assert.IsTrue(_cleverTools.IsElementNotPresent(String.Format(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolsApplicationName, applicationList[count])));
            }
        }

         // Verify that Show Icons on front end checkbox is checked.
        public bool VerifyEditIconShowIconsOnFrontEndChecked(string locator)
        {
            switchToClevertoolsubmenuEditIconsShowIconsOnFECheckbox();
            
            bool IsChecked=_cleverTools.IsChecked(locator);

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
            
            Assert.AreEqual(true, VerifyEditIconShowIconsOnFrontEndChecked(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditIconsShowIconsOnFrontEnd));
        }

        //Uncheck Show Icons on front end checkbox
        public void UncheckEditIconsShowIconsOnFrontEndCheckbox()
        {

            if (VerifyEditIconShowIconsOnFrontEndChecked(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditIconsShowIconsOnFrontEnd))
            {
                switchToClevertoolsubmenuEditIconsShowIconsOnFECheckbox();

                //Click on OK

                _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditIconsOKButton);
            }
           
        }

        //Check Show Icons on front end checkbox
        public void CheckEditIconsShowIconsOnFrontEndCheckbox()
        {

            if (!VerifyEditIconShowIconsOnFrontEndChecked(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditIconsShowIconsOnFrontEnd))
            {

                switchToClevertoolsubmenuEditIconsShowIconsOnFECheckbox();
                //Click on OK

                _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditIconsOKButton);
            }
        }

        //Verify that Show Icons on front end checkbox is not checked by default.

        public void VerifyEditIconsShowIconsFrontEndCheckboxIsNotChecked()
        {
            switchToClevertoolsubmenuEditIconsShowIconsOnFECheckbox();
            
            //verify checkbox is not checked

            try
            {
                Assert.AreEqual(false, VerifyEditIconShowIconsOnFrontEndChecked(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditIconsShowIconsOnFrontEnd));
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
                _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolListItemsTab);
                Thread.Sleep(2000);
                _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolsNameColumnHeader);

                //Check if position to be moved is indeed up and currently we are limiting the check so that Move is tested only in first page with maximum 10 apps
                if ((positionOfAppToMoveUp - whereToMovePosition) > 0 && positionOfAppToMoveUp <= 10)
                {
                    //Run the counter and click Move UP button depending on the position given.
                    for (int count = 0; count < (positionOfAppToMoveUp - whereToMovePosition); count++)
                    {
                        _cleverTools.SafeClick(String.Format(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolMoveUpButtonInListItems, nameOfAppToMove));
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
                _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolDropDownItemsTab);
                Thread.Sleep(2000);
                _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolsNameColumnHeader);

                if ((positionOfAppToMoveUp - whereToMovePosition) > 0 && positionOfAppToMoveUp<= 10)
                {
                    for (int count = 0; count < (positionOfAppToMoveUp - whereToMovePosition); count++)
                    {
                        _cleverTools.SafeClick(String.Format(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolMoveUpButtonInDropDownItems, nameOfAppToMove));
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
                _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolListItemsTab);
                Thread.Sleep(2000);
                _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolsNameColumnHeader);

                //Verify that clever tool is moved to position 'whereToMovePostion' in List Items
                Assert.IsTrue(_cleverTools.IsElementPresent(String.Format(iDAutomatedUITests.UIElements.CleverToolsPageElements.TableForAppsInListItems, (whereToMovePosition + 1), nameOfAppToMove)));
            }
            else
            {
                _cleverTools.SafeClick(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolDropDownItemsTab);
                Thread.Sleep(2000);
                _cleverTools.WaitForElementPresent(iDAutomatedUITests.UIElements.CleverToolsPageElements.EditToolsNameColumnHeader);

                //Verify that clever tool is moved to position 'whereToMovePostion' in Drop Down Items
                Assert.IsTrue(_cleverTools.IsElementPresent(String.Format(iDAutomatedUITests.UIElements.CleverToolsPageElements.TableForAppsInDropDownItems, (whereToMovePosition + 1), nameOfAppToMove)));
            }
        }
    }
}
