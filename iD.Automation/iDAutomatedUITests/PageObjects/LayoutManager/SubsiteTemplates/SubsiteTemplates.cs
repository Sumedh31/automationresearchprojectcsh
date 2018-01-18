using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using System.Web;
using NUnit.Framework;
using iDAutomatedUITests.PageObjects;
using iDAutomatedUITests.PageObjects.Common;
using iDAutomatedUITests.Helpers;
using System.Runtime.InteropServices;
using iDAutomatedUITests.UIElements;
using NUnit.Core;

namespace iDAutomatedUITests.PageObjects.Layout.SubsiteTemplates
{
    public class SubsiteTemplates
    {
        // Web Driver object
        private readonly IWebDriver _subsiteTemplates;

        // Constructor
        public SubsiteTemplates(IWebDriver driver)
        {
            _subsiteTemplates = driver;
        }
        
        // Clicking on 'Subsite Templates' tab
        public void ClickSubsiteTemplatesTab()
        {
            _subsiteTemplates.WaitForElementPresent(iDAutomatedUITests.UIElements.LayoutManager.SubsiteTemplates.SubsiteTemplates.SubsiteTemplatesTab);
            _subsiteTemplates.SafeClick(iDAutomatedUITests.UIElements.LayoutManager.SubsiteTemplates.SubsiteTemplates.SubsiteTemplatesTab);
            Thread.Sleep(5000);
        }

        // Verify that the default data is present in Layout Manager 'Subsite templates' tab.
        public void SubsiteTemplatesQuickStartData(string title1, string title2, string title3, string title4, string title5)
        {
            string subsiteTemplateTitle1 =
                 _subsiteTemplates.SafeGetText(iDAutomatedUITests.UIElements.LayoutManager.SubsiteTemplates.SubsiteTemplates.SubsiteTemplate1);
            string subsiteTemplateTitle2 =
                 _subsiteTemplates.SafeGetText(iDAutomatedUITests.UIElements.LayoutManager.SubsiteTemplates.SubsiteTemplates.SubsiteTemplate2);
            string subsiteTemplateTitle3 =
                 _subsiteTemplates.SafeGetText(iDAutomatedUITests.UIElements.LayoutManager.SubsiteTemplates.SubsiteTemplates.SubsiteTemplate3);
            string subsiteTemplateTitle4 =
                 _subsiteTemplates.SafeGetText(iDAutomatedUITests.UIElements.LayoutManager.SubsiteTemplates.SubsiteTemplates.SubsiteTemplate4);
            string subsiteTemplateTitle5 =
                  _subsiteTemplates.SafeGetText(iDAutomatedUITests.UIElements.LayoutManager.SubsiteTemplates.SubsiteTemplates.SubsiteTemplate5);

            Assert.AreEqual(title1, subsiteTemplateTitle1);
            Assert.AreEqual(title2, subsiteTemplateTitle2);
            Assert.AreEqual(title3, subsiteTemplateTitle3);
            Assert.AreEqual(title4, subsiteTemplateTitle4);
            Assert.AreEqual(title5, subsiteTemplateTitle5);
        }
    }
}
