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

namespace iDAutomatedUITests.PageObjects.CMS.Pages
{
    public class Pages
    {
         // Web Driver object
        private  readonly IWebDriver _pages;

        // Constructor
        public Pages(IWebDriver driver)
        {
            _pages = driver;
        }
 

        // Verify that the QuickStartData for iD CMS pages is present in iD CMS folder.
        public void PageQuickStartData(string page1, string page2, string page3)
        {
            string PageTitle1 =
                 _pages.SafeGetText(iDAutomatedUITests.UIElements.CMS.Pages.Pages.Page1);
            string PageTitle2 =
                 _pages.SafeGetText(iDAutomatedUITests.UIElements.CMS.Pages.Pages.Page2);
            string PageTitle3 =
                _pages.SafeGetText(iDAutomatedUITests.UIElements.CMS.Pages.Pages.Page3);

            Assert.AreEqual(page1, PageTitle1);
            Assert.AreEqual(page2, PageTitle2);
            Assert.AreEqual(page3, PageTitle3);
        }
    }
}
