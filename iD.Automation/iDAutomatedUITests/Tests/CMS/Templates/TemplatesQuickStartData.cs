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
using iDAutomatedUITests.PageObjects.CMS.Folders;
using iDAutomatedUITests.Settings;

using NUnit.Core;

using log4net;

namespace iDAutomatedUITests.Tests.CMS.Templates
{
    class TemplatesQuickStartData : BaseTestClass
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

        // Checking for QuickStartData in the template tab. 
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("TestAppender"); 

        [Test]
        public void TempQuickStartData()
        {
                       
            const string URL = "http://idfe/home/sitecontent.aspx";
            const string title1 = "Announcement Template";
            const string title2 = "Document Index Template";
            const string title3 = "Extensive Text Template";
            const string title4 = "Image Grid Template";
            const string title5 = "Text Video Images Template";

            //Navigating to iD CMS folder in the FE
            log.Info("Giving URL ");
            common.URL(URL);
            Thread.Sleep(5000);

            //Clicking on iD CMS Folder
            Folders.ClickFolder();
            Thread.Sleep(5000);

            //Clicking on iD CMS Templates tab
            Templates.ClickTemplateTab();
            Thread.Sleep(2000);

            // Testing Actual vs expetced default data in the iD CMS Templates tab
            Templates.TemplatesQuickStartData(title1, title2, title3, title4, title5);
            

        }
    }
}
