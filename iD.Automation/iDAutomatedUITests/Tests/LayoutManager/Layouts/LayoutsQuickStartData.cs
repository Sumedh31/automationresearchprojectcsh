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

namespace iDAutomatedUITests.Tests.LayoutManager.Layouts
{
    class LayoutsQuickStartData : BaseTestClass
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
        public void SubsiteLayoutsQuickStartData()
        {

            const string URL = "http://idfe/home/layoutmanager/";
            const string layout1 = "EXAMPLE - Grid Main Area";

            //Navigating to Layout Manager in the FE
            log.Info("Giving URL ");
            common.URL(URL);
            Thread.Sleep(5000);

            // Testing Actual vs expetced default data for Layouts.
            Layouts.LayoutQuickStartData(layout1);
        }
    }
}
