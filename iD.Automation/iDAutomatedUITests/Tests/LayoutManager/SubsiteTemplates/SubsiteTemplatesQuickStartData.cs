using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

using iDAutomatedUITests.Helpers;
using iDAutomatedUITests.PageObjects;
using iDAutomatedUITests.Settings;

using NUnit.Core;

using log4net;

namespace iDAutomatedUITests.Tests.LayoutManager.SubsiteTemplates
{
    class SubsiteTemplatesQuickStartData : BaseTestClass
    {
        [SetUp]
        protected void SetUp()
        {
            SafeSetUp(false);

        }

        [TearDown]
        protected void TearDown()
        {
            //Template.CloseFE();     
            SafeTearDown(false);
        }

        // Checking for QuickStartData in the Subsite templates tab. 
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("TestAppender");

        [Test]
        public void SubsiteTempQuickStartData()
        {

            const string URL = "http://idfe/home/layoutmanager/";
            const string title1 = "Complex Grid - LComplex Grid - L&R Columns";
            const string title2 = "Grid Main Area - Left Column";
            const string title3 = "Grid Main Area - LGrid Main Area - L&R Columns";
            const string title4 = "Grid Main Area - Right Column";
            const string title5 = "Three Panel Main Area";

            //Navigating to Layout Manager in the FE
            log.Info("Giving URL ");
            common.URL(URL);
            Thread.Sleep(5000);

            //Clicking on Subsite Templates tab
            SubsiteTemplates.ClickSubsiteTemplatesTab();
            Thread.Sleep(5000);

            // Testing Actual vs expetced default data in the Subsite Templates tab
            SubsiteTemplates.SubsiteTemplatesQuickStartData(title1, title2, title3, title4, title5);


        }

    }
}
