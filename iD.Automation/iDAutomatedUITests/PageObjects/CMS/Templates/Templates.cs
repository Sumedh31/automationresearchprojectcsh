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

namespace iDAutomatedUITests.PageObjects.CMS.Templates
{
    public class Templates
    {
        // Web Driver object
        private  readonly IWebDriver _templates;

        // Constructor
        public Templates(IWebDriver driver)
        {
            _templates = driver;
        }

        // Clicking on iD CMS 'Templates' tab
        public void ClickTemplateTab()
        {
            _templates.WaitForElementPresent(iDAutomatedUITests.UIElements.CMS.Templates.Templates.TemplatesTab);
            _templates.SafeClick(iDAutomatedUITests.UIElements.CMS.Templates.Templates.TemplatesTab);
            Thread.Sleep(5000);
        }

        // Verify that the default data is present in iD CMS templates tab, Testing Actual vs expetced default data.
        public void TemplatesQuickStartData(string title1, string title2, string title3, string title4, string title5)
        {
             string templateTitle1 =
                  _templates.SafeGetText(iDAutomatedUITests.UIElements.CMS.Templates.Templates.Template1);
             string templateTitle2 =
                  _templates.SafeGetText(iDAutomatedUITests.UIElements.CMS.Templates.Templates.Template2);
             string templateTitle3 =
                  _templates.SafeGetText(iDAutomatedUITests.UIElements.CMS.Templates.Templates.Template3);
             string templateTitle4 =
                  _templates.SafeGetText(iDAutomatedUITests.UIElements.CMS.Templates.Templates.Template4);
            string templateTitle5 =
                  _templates.SafeGetText(iDAutomatedUITests.UIElements.CMS.Templates.Templates.Template5);
           
             Assert.AreEqual(title1, templateTitle1);
             Assert.AreEqual(title2, templateTitle2);
             Assert.AreEqual(title3, templateTitle3);
             Assert.AreEqual(title4, templateTitle4);
             Assert.AreEqual(title5, templateTitle5);
        }

        // Close Browser
       /* public void CloseFE()
        {
            _template.Close();
        }*/
    }
}
