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
using Core.Base;
using OpenQA.Selenium.Remote;
using iDAutomatedTests.Admin.Apps.CleverTool.TestEngine;

namespace iDAutomatedTests.Admin.Apps.CleverTool.Tests
{
    public class CleverToolsTestCases:CleverToolsPage
    {
        [SetUp]
        protected void SetUp()
        {
            AdminLogin();
           
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
            NavigateToCleverTools(subsiteName, applicationName);

            // Verify the menu options
            VerifySubMenuOptions(expectedAddTool, expectedEditTools, expectedEditIcons);

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
            NavigateToCleverTools(subsiteName, applicationName);

            // Add Clever Tool as List Item
            AddCleverTool(applicationNames, location, numberOfApps);

            // Verify that Clever Tool is added in the List
            VerifyCleverToolAdded(applicationNames, location, numberOfApps);

            // Delete
            DeleteCleverToolFromDropDownList(applicationNames,location,numberOfApps);
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
            NavigateToCleverTools(subsiteName, applicationName);

            // Add Clever Tool as Drop Down Item
            AddCleverTool(applicationNames, location, numberOfApps);

            // Verify that Clever Tool is added in Drop Down Items
            VerifyCleverToolAdded(applicationNames, location, numberOfApps);

            // Delete
            DeleteCleverToolFromDropDownList(applicationNames,location,numberOfApps);
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
            NavigateToCleverTools(subsiteName, application);

            // Add Clever Tool
            AddCleverTool(applicationNames, location, numberOfApps);

            // Delete Clever Tool
            DeleteCleverToolFromList(applicationNames, location, numberOfApps);

            // Verify that Clever Tool is Deleted
            VerifyCleverToolDeleted(applicationNames, location, numberOfApps);
        }

        //Test:Verify that default value of 'Show Icons On Front End' checbox is not checked.

        [Test]
        public void EditIconsShowIconsOnFrontEndCheckboxDefaultValueTest()
        {
            const string application = "Clever Tools";
            const string subsiteName = "Home";

            // Navigate to Clever Tools
            NavigateToCleverTools(subsiteName, application);

            //Make sure that by default 'Show Icons On front end checkbox is not checked'

            VerifyEditIconsShowIconsFrontEndCheckboxIsNotChecked();
        }

        //Test: Verify that Show icons on front end checkbox retains it's value
        [Test]
        public void EditIconsShowIconsOnFrontEndCheckboxRetainsCheckedValueTest()
        {
            const string application = "Clever Tools";
            const string subsiteName = "Home";

            // Navigate to Clever Tools
            NavigateToCleverTools(subsiteName, application);

            //Check Show Icons on front end checkbox and verify it is checked
            EditIconsShowIconsOnFrontEndRetainsChekedValue();

            //Uncheck prviously checked checkbox
            UncheckEditIconsShowIconsOnFrontEndCheckbox();
        }

        //Test: Verify that Move functionality for Edit Tools--> ToolsList is working fine
        [Test]
        public void moveAppForInCleverTools()
        {
            const string location = "List Item";
            const string subsiteName = "Home";
            const string applicationName = "Clever Tools";
            int numberOfApps = 3;
            string[] applicationNames = { "Acronym Manager", "Company Calendar", "Contact Manager" };
            int positionOfAppToMoveUp = 3;
            int appPositionMoveTo = 2;
            string nameOfAppToMove = applicationNames[positionOfAppToMoveUp-1];

            // Navigate to Clever Tools
            NavigateToCleverTools(subsiteName, applicationName);

            //Add application from array
            AddCleverTool(applicationNames, location, numberOfApps);
            
            //we will move the app which is at position 'positionOfAppToMoveUp' to the position given as 'appPositionMoveTo'.
         
            moveUpApplication(applicationNames,location,nameOfAppToMove,positionOfAppToMoveUp,appPositionMoveTo);

            //Verify that Move is done scuccefully.
            verifyMoveIsSuccess(applicationNames,location,nameOfAppToMove,appPositionMoveTo);

            //Delete Test Data
            DeleteCleverToolFromDropDownList(applicationNames,location,numberOfApps);

            //Verify that the test data is deleted
            VerifyCleverToolDeleted(applicationNames, location, numberOfApps);
                             
        }
    }
}