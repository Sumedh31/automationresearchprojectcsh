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
using Core.Base;
using iDAutomatedTests.FrontEnd.Apps.OldLayoutManager.TestEngine;

using OpenQA.Selenium.Remote;

namespace iDAutomatedTests.FrontEnd.Apps.OldLayoutManager.Tests
{
    public class CollectionsLayoutManager:LayoutManager
    {
        //[SetUp]
        //protected void SetUp()
        //{
        //    SafeSetUp(false);
        //}
                
        [SetUp]
        public void InitializeTest([Optional]string otherUsername, [Optional] string otherPassword)
        {
            FrontEndLogin(otherUsername, otherPassword);
           
        }

        [TearDown]
        protected void TearDown()
        {
            SafeFETearDown(false);
        }

        [Test]
        public void VerifyFullControlUserCanViewEditOption()
        {
            InitializeTest();
            VerifyAllTheLayoutOptions();
        }

        [Test]
        public void VerfiyOptionsFromEditDropDownList()
        {
            InitializeTest();
            VerifyEditDropDownList();
        }

        [Test]
        public void VerifyThatEditDropDownListDisappearsAfterClickingAgain()
        {
            InitializeTest();
            VerifyEditDropDownListDisappears();
        }

        [Test]
        public void VerifyCreatorCannotSeeEditLayoutOption()
        {
            InitializeTest("creator", "creator");
            VerifyCreatorCannotViewEditOption();
        }

        [Test]
        public void VerifyContributorCanSeeEditLayoutOption()
        {
            InitializeTest("contributor", "contributor");
            VerifyContributorCanViewEditOption();
        }

        [Test]
        public void VerifyAddDropDownListOnManageLayout()
        {
            string newLayout = "New Layout";
            string newSubsiteTemplate = "New Subsite Template";

            InitializeTest();

            // Manage Layout
            NavigateToManageLayout();

            // Verify Add + drop down list
            VerifyAddPlusDropDownList(newLayout, newSubsiteTemplate);

        }

        [Test]
        public void VerifyActionsDropDownListOnManageLayout()
        {
            string editProperties = "Edit Properties";
            string recycleBin = "Recycle Bin";
            
            InitializeTest();

            // Manage Layout
            NavigateToManageLayout();

            // Verify Actions drop down list
            VerifyActionsDropDownList(editProperties, recycleBin);

        }

        [Test]
        public void CreateNewTemplate()
        {
            string templateName="AutomationSubsiteTemplate", description="sample description", entity="Template";
            int rows = 2, applicationArea= 0;

            InitializeTest();

            // Navigate to Manage Layout
            NavigateToManageLayout();

            // Add New Subsite Template
            AddNewSubsiteTemplate(templateName,null,rows, applicationArea);

            // Edit Template
            EditSubsiteTemplate(templateName);
            
            // Add Footer Component
            AddFooterComponent(rows,entity);

            // Verify that Template is created successfully
            VerifySubsiteTemplate(templateName);

            // Delete created Template
            DeleteSubsiteTemplate(templateName);

            // Verfiy that Template no longer exists
            VerifySubsiteTemplateDeleted(templateName);
        }

        [Test]
        public void VerifyEditBarForEditLayout()
        {
            InitializeTest();

            // Edit Layout
            EditLayoutLive();

            // Verify that Manage Layout option exists
            VerifyManageLayoutForEditLayout();
        }

        [Test]
        public void VerifySaveDropDownListForEditLayout()
        {
            InitializeTest();

            // Edit Live Layout
            EditLayoutLive();

            // Verify Save drop down list
            VerifySaveDropDownListEditLayout();
        }

        [Test]
        public void VerifyEditDropDownListForEditLayout()
        {
            InitializeTest();

            // Edit Layout
            EditLayoutLive();

            // Verify Edit drop down list
            VerifyEditDropDownListOptionsForEditLayout();
        }

        [Test]
        public void VerifyActionsDropDownListForEditLayout()
        {
            InitializeTest();

            // Edit Layout
            EditLayoutLive();

            // Verify Actions Drop Down List
            VerifyActionsDropDownListOptionsEditLayot();
        }

        [Test]
        public void AddNewLayout()
        {
            string templateName = "AutomationSubsiteTemplate", templateDescription = "sample subsite template description";
            string layoutName = "AutomationSubsiteLayout", layoutDescription = "sample layout description", entityTemplate="Template", entityLayout="Layout";
            int templateRows = 2, templateApplicationArea = 0, layoutRows = 4, layoutApplicationArea = 4;
            
            // Login to Front End
            InitializeTest();

            // Navigate to Manage Layout
            NavigateToManageLayout();

            // Add New Subsite Template
            AddNewSubsiteTemplate(templateName, templateDescription, templateRows, templateApplicationArea);

            // Make Template Default
            MakeSubsiteTemplateDefault(templateName);

            // Edit Template
            EditSubsiteTemplate(templateName);

            // Add Header Component
            AddHeaderComponent(templateRows, entityTemplate);
            
            // Add New Layout
            AddNewSubsiteLayout(layoutName,layoutDescription,layoutRows,layoutApplicationArea);

            // Edit New Layout
            EditSubsiteLayout(layoutName);

            // Add Footer Component
            AddFooterComponent(templateRows + 1, entityLayout);

            // Apply Layout
            ApplyLayout(layoutName);

            // Navigate to Home Subsite
            NavigateToHomeSubsite();

            // Verify that Layout is displayed on Home page
            
            
            // Delete Template
            //DeleteSubsiteTemplate(templateName);

            // Delete Layout

        }

        [Test]
        public void VerifyEditLayout()
        {
            string templateName = "AutomationSubsiteTemplate", entity="Template";
            int rows = 2, applicationArea = 0;

            InitializeTest();

            // Navigate to Manage Layout
            NavigateToManageLayout();

            // Add New Subsite Template
            AddNewSubsiteTemplate(templateName, null, rows, applicationArea);

            // Edit Subsite Template
            EditSubsiteTemplate(templateName);

            // Add Header Component
            AddHeaderComponent(rows, entity);


        }
    }
}
