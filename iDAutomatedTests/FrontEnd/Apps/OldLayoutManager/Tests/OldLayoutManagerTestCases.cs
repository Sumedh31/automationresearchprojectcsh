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
using iDAutomatedTests.FrontEnd.Apps.OldLayoutManager.TestEngine;


namespace iDAutomatedTests.FrontEnd.Apps.OldLayoutManager.Tests
{
    public class LayoutManagerTestCases :LayoutManager
    {
        
        [SetUp]
        protected void Setup()
        {
            FrontEndLogin();
        }

        [TearDown]
        protected void TearDown()
        {
            SafeFETearDown(false);
        }

        [Test]
        public void VerifyThatFullControlUseCanSeeAllTheLayoutOptionsAfterLogin()
        {
            VerifyAllTheLayoutOptions();
        }

        [Test]
        public void AddNewLayout()
        {
            string title = "AutomationLayout";
            string lastName = "guest", addFrom = "iD Database", saveDescription="Created new Layout";

            // Add Layout
            AddLayout(title, null, lastName, null, null, addFrom, saveDescription);

            // Verify that Layout is added
            
        }


    }
}
