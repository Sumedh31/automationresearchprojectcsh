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
using iDAutomatedUITests.PageObjects.CMS;
using iDAutomatedUITests.Settings;

using NUnit.Core;

using log4net;

namespace iDAutomatedUITests.Tests.CMS.Pages
{
    class PagesQuickStartData : BaseTestClass
    {
        [SetUp]
        protected void SetUp()
        {
            SafeSetUp(false);

        }

        [TearDown]
        protected void TearDown()
        {   
            SafeTearDown(false);
        }

        // Checking for iD CMS QuickStartData Pages. 
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("TestAppender");

        [Test]
        public void CmsPagesQuickStartData()
        {

            const string URL = "http://idfe/home/sitecontent.aspx";
            const string page1 = "#Channel Directory";
            const string page2 = "Company History";
            const string page3 = "Social Intranet Policy";
            

            //Navigating to iD CMS folder in the FE
            log.Info("Giving URL ");

            common.URL(URL);
            Thread.Sleep(5000);

            Folders.ClickFolder();
            Thread.Sleep(5000);

            // Testing Actual vs expetced default QuickStartData for iD CMS Pages
            Pages.PageQuickStartData(page1, page2, page3);
            
        }
    }
}
