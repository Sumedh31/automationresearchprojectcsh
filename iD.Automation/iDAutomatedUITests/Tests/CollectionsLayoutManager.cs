using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    public class CollectionsLayoutManager : BaseTestClass
    {
        //[SetUp]
        //protected void SetUp()
        //{
        //    SafeSetUp(false);
        //}
        
        public void InitializeTest(bool admin, [Optional]string otherUsername, [Optional] string otherPassword)
        {
            SafeSetUp(admin, otherUsername, otherPassword);
        }

        [TearDown]
        protected void TearDown()
        {
            SafeTearDown(false);
        }

        [Test]
        public void VerifyFullControlUserCanViewEditOption()
        {
            InitializeTest(false);
            LayoutManager.VerifyAllTheLayoutOptions();
        }

        [Test]
        public void VerfiyOptionsFromEditDropDownList()
        {
            InitializeTest(false);
            LayoutManager.VerifyEditDropDownList();
        }

        [Test]
        public void VerifyThatEditDropDownListDisappearsAfterClickingAgain()
        {
            InitializeTest(false);
            LayoutManager.VerifyEditDropDownListDisappears();
        }

        [Test]
        public void VerifyCreatorCannotSeeEditLayoutOption()
        {
            InitializeTest(false, "creator", "creator");
            LayoutManager.VerifyCreatorCannotViewEditOption();
        }

        [Test]
        public void VerifyContributorCanSeeEditLayoutOption()
        {
            InitializeTest(false, "contributor", "contributor");
            LayoutManager.VerifyContributorCanViewEditOption();
        }

        [Test]
        public void VerifyAddDropDownListOnManageLayout()
        {
            string newLayout = "New Layout";
            string newSubsiteTemplate = "New Subsite Template";

            InitializeTest(false);

            // Manage Layout
            LayoutManager.NavigateToManageLayout();

            // Verify Add + drop down list
            LayoutManager.VerifyAddPlusDropDownList(newLayout, newSubsiteTemplate);

        }

        [Test]
        public void VerifyActionsDropDownListOnManageLayout()
        {
            string editProperties = "Edit Properties";
            string recycleBin = "Recycle Bin";
            
            InitializeTest(false);

            // Manage Layout
            LayoutManager.NavigateToManageLayout();

            // Verify Actions drop down list
            LayoutManager.VerifyActionsDropDownList(editProperties, recycleBin);

        }

        [Test]
        public void CreateNewTemplate()
        {
            string templateName="AutomationSubsiteTemplate", description="sample description", entity="Template";
            int rows = 2, applicationArea= 0;

            InitializeTest(false);

            // Navigate to Manage Layout
            LayoutManager.NavigateToManageLayout();

            // Add New Subsite Template
            LayoutManager.AddNewSubsiteTemplate(templateName,null,rows, applicationArea);

            // Edit Template
            LayoutManager.EditSubsiteTemplate(templateName);
            
            // Add Footer Component
            LayoutManager.AddFooterComponent(rows,entity);

            // Verify that Template is created successfully
            LayoutManager.VerifySubsiteTemplate(templateName);

            // Delete created Template
            LayoutManager.DeleteSubsiteTemplate(templateName);

            // Verfiy that Template no longer exists
            LayoutManager.VerifySubsiteTemplateDeleted(templateName);
        }

        [Test]
        public void VerifyEditBarForEditLayout()
        {
            InitializeTest(false);

            // Edit Layout
            LayoutManager.EditLayoutLive();

            // Verify that Manage Layout option exists
            LayoutManager.VerifyManageLayoutForEditLayout();
        }

        [Test]
        public void VerifySaveDropDownListForEditLayout()
        {
            InitializeTest(false);

            // Edit Live Layout
            LayoutManager.EditLayoutLive();

            // Verify Save drop down list
            LayoutManager.VerifySaveDropDownListEditLayout();
        }

        [Test]
        public void VerifyEditDropDownListForEditLayout()
        {
            InitializeTest(false);

            // Edit Layout
            LayoutManager.EditLayoutLive();

            // Verify Edit drop down list
            LayoutManager.VerifyEditDropDownListOptionsForEditLayout();
        }

        [Test]
        public void VerifyActionsDropDownListForEditLayout()
        {
            InitializeTest(false);

            // Edit Layout
            LayoutManager.EditLayoutLive();

            // Verify Actions Drop Down List
            LayoutManager.VerifyActionsDropDownListOptionsEditLayot();
        }

        [Test]
        public void AddNewLayout()
        {
            string templateName = "AutomationSubsiteTemplate", templateDescription = "sample subsite template description";
            string layoutName = "AutomationSubsiteLayout", layoutDescription = "sample layout description", entityTemplate="Template", entityLayout="Layout";
            int templateRows = 2, templateApplicationArea = 0, layoutRows = 4, layoutApplicationArea = 4;
            
            // Login to Front End
            InitializeTest(false);

            // Navigate to Manage Layout
            LayoutManager.NavigateToManageLayout();

            // Add New Subsite Template
            LayoutManager.AddNewSubsiteTemplate(templateName, templateDescription, templateRows, templateApplicationArea);

            // Make Template Default
            LayoutManager.MakeSubsiteTemplateDefault(templateName);

            // Edit Template
            LayoutManager.EditSubsiteTemplate(templateName);

            // Add Header Component
            LayoutManager.AddHeaderComponent(templateRows, entityTemplate);
            
            // Add New Layout
            LayoutManager.AddNewSubsiteLayout(layoutName,layoutDescription,layoutRows,layoutApplicationArea);

            // Edit New Layout
            LayoutManager.EditSubsiteLayout(layoutName);

            // Add Footer Component
            LayoutManager.AddFooterComponent(templateRows + 1, entityLayout);

            // Apply Layout
            LayoutManager.ApplyLayout(layoutName);

            // Navigate to Home Subsite
            LayoutManager.NavigateToHomeSubsite();

            // Verify that Layout is displayed on Home page
            
            
            // Delete Template
            //LayoutManager.DeleteSubsiteTemplate(templateName);

            // Delete Layout

        }

        [Test]
        public void VerifyEditLayout()
        {
            string templateName = "AutomationSubsiteTemplate", entity="Template";
            int rows = 2, applicationArea = 0;

            InitializeTest(false);

            // Navigate to Manage Layout
            LayoutManager.NavigateToManageLayout();

            // Add New Subsite Template
            LayoutManager.AddNewSubsiteTemplate(templateName, null, rows, applicationArea);

            // Edit Subsite Template
            LayoutManager.EditSubsiteTemplate(templateName);

            // Add Header Component
            LayoutManager.AddHeaderComponent(rows, entity);


        }
    }
}
