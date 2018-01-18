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

using iDAutomatedUITests.PageObjects;
using iDAutomatedUITests.Settings;
using iDAutomatedUITests.Helpers;


namespace iDAutomatedUITests.Tests
{
    public class LayoutManagerTestCases : BaseTestClass
    {
        
        [SetUp]
        protected void Setup()
        {
            SafeSetUp(false);
        }

        [TearDown]
        protected void TearDown()
        {
            SafeTearDown(false);
        }

        [Test]
        public void VerifyThatFullControlUseCanSeeAllTheLayoutOptionsAfterLogin()
        {
            LayoutManager.VerifyAllTheLayoutOptions();
        }

        [Test]
        public void AddNewLayout()
        {
            string title = "AutomationLayout";
            string lastName = "guest", addFrom = "iD Database", saveDescription="Created new Layout";

            // Add Layout
            LayoutManager.AddLayout(title, null,lastName,null,null,addFrom, saveDescription);

            // Verify that Layout is added
            
        }


    }
}
