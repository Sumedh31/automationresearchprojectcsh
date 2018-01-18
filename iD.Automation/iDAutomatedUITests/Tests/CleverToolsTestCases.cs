using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;

using iDAutomatedUITests.Helpers;
using iDAutomatedUITests.PageObjects;
using iDAutomatedUITests.Settings;

using OpenQA.Selenium.Remote;

namespace iDAutomatedUITests.Tests
{
    public class CleverToolsTestCases : BaseTestClass
    {
        [SetUp]
        protected void SetUp()
        {
            SafeSetUp(true);
        }

        [TearDown]
        protected void TearDown()
        {
            SafeTearDown(true);
        }

        //Test: Verify that all the submenu options from clever tool app are present.

        [Test]
        public void VerifySubMenuForCleverTools()
        {
            const string subsiteName = "Home";
            const string applicationName = "Clever Tools";
            const string expectedAddTool = "Add Tool";
            const string expectedEditTools = "Edit Tools";
            const string expectedEditIcons = "Edit Icons";

            // Navigate to Clever Tools
            CleverToolsPage.NavigateToCleverTools(subsiteName, applicationName);

            // Verify the menu options
            CleverToolsPage.VerifySubMenuOptions(expectedAddTool, expectedEditTools, expectedEditIcons);

        }

        //Test: Add clever tools in List and verufy that they're added succesfully and then delete the test data.

        [Test]
        public void AddCleverToolAsListItem()
        {
            string[] applicationNames = { "Acronym Manager" };
            int numberOfApps = 1;
            const string location = "List Item";
            const string subsiteName = "Home";
            const string applicationName = "Clever Tools";

            // Navigate to Clever Tools
            CleverToolsPage.NavigateToCleverTools(subsiteName, applicationName);

            // Add Clever Tool as List Item
            CleverToolsPage.AddCleverTool(applicationNames, location, numberOfApps);

            // Verify that Clever Tool is added in the List
            CleverToolsPage.VerifyCleverToolAdded(applicationNames, location, numberOfApps);

            // Delete
            CleverToolsPage.DeleteCleverToolFromDropDownList(applicationNames,location,numberOfApps);
        }

        //Test: Verify that clever tools are added as drop down succesfully and then delete the test data.

        [Test]
        public void AddCleverToolAsDropDownItem()
        {
            string[] applicationNames = { "Acronym Manager" };
            int numberOfApps = 1;
            const string location = "Drop Down Item";
            const string subsiteName = "Home";
            const string applicationName = "Clever Tools";

            // Navigate to Clever Tools
            CleverToolsPage.NavigateToCleverTools(subsiteName, applicationName);

            // Add Clever Tool as Drop Down Item
            CleverToolsPage.AddCleverTool(applicationNames, location, numberOfApps);

            // Verify that Clever Tool is added in Drop Down Items
            CleverToolsPage.VerifyCleverToolAdded(applicationNames, location, numberOfApps);

            // Delete
            CleverToolsPage.DeleteCleverToolFromDropDownList(applicationNames,location,numberOfApps);
        }

        //Test: Add clever tool and make sure they're getting deleted succesfully.

        [Test]
        public void DeleteCleverTool()
        {
            const string application = "Clever Tools";
            string[] applicationNames = { "Acronym Manager" };
            int numberOfApps = 1;
            const string location = "List Item";
            const string subsiteName = "Home";

            // Navigate to Clever Tools
            CleverToolsPage.NavigateToCleverTools(subsiteName, application);

            // Add Clever Tool
            CleverToolsPage.AddCleverTool(applicationNames, location, numberOfApps);

            // Delete Clever Tool
            CleverToolsPage.DeleteCleverToolFromList(applicationNames, location, numberOfApps);

            // Verify that Clever Tool is Deleted
            CleverToolsPage.VerifyCleverToolDeleted(applicationNames, location, numberOfApps);
        }

        //Test:Verify that default value of 'Show Icons On Front End' checbox is not checked.

        [Test]
        public void EditIconsShowIconsOnFrontEndCheckboxDefaultValueTest()
        {
            const string application = "Clever Tools";
            const string subsiteName = "Home";

            // Navigate to Clever Tools
            CleverToolsPage.NavigateToCleverTools(subsiteName, application);

            //Make sure that by default 'Show Icons On front end checkbox is not checked'

            CleverToolsPage.VerifyEditIconsShowIconsFrontEndCheckboxIsNotChecked();
        }

        //Test: Verify that Show icons on front end checkbox retains it's value
        [Test]
        public void EditIconsShowIconsOnFrontEndCheckboxRetainsCheckedValueTest()
        {
            const string application = "Clever Tools";
            const string subsiteName = "Home";

            // Navigate to Clever Tools
            CleverToolsPage.NavigateToCleverTools(subsiteName, application);

            //Check Show Icons on front end checkbox and verify it is checked
            CleverToolsPage.EditIconsShowIconsOnFrontEndRetainsChekedValue();

            //Uncheck prviously checked checkbox
            CleverToolsPage.UncheckEditIconsShowIconsOnFrontEndCheckbox();
        }

        //Test: Verify that Move functionality for Edit Tools--> ToolsList is working fine
        [Test]
        public void moveAppForInCleverTools()
        {
            const string location = "List Item";
            const string subsiteName = "Home";
            const string applicationName = "Clever Tools";
            int numberOfApps = 4;
            string[] applicationNames = { "Acronym Manager", "Brand Manager", "Company Calendar", "Contact Manager" };
            int positionOfAppToMoveUp = 4;
            int appPositionMoveTo = 3;
            string nameOfAppToMove = applicationNames[positionOfAppToMoveUp-1];

            // Navigate to Clever Tools
            CleverToolsPage.NavigateToCleverTools(subsiteName, applicationName);

            //Add application from array
            CleverToolsPage.AddCleverTool(applicationNames, location, numberOfApps);
            
            //we will move the app which is at position 'positionOfAppToMoveUp' to the position given as 'appPositionMoveTo'.
         
            CleverToolsPage.moveUpApplication(applicationNames,location,nameOfAppToMove,positionOfAppToMoveUp,appPositionMoveTo);

            //Verify that Move is done scuccefully.
            CleverToolsPage.verifyMoveIsSuccess(applicationNames,location,nameOfAppToMove,appPositionMoveTo);

            //Delete Test Data
            CleverToolsPage.DeleteCleverToolFromDropDownList(applicationNames,location,numberOfApps);

            //Verify that the test data is deleted
            CleverToolsPage.VerifyCleverToolDeleted(applicationNames, location, numberOfApps);
                             
        }
    }
}