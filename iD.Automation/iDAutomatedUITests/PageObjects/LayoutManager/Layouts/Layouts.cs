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

namespace iDAutomatedUITests.PageObjects.Layout.Layouts
{
    public class Layouts
    {
        // Web Driver object
        private  readonly IWebDriver _layouts;

        // Constructor
        public Layouts(IWebDriver driver)
        {
            _layouts = driver;
        }

        // Verify that the Quick Start data is present for Layouts.
        public void LayoutQuickStartData(string layout1)
        {
            string LayoutTitle1 =
                 _layouts.SafeGetText(iDAutomatedUITests.UIElements.LayoutManager.Layouts.Layouts.Layout1);

            Assert.AreEqual(layout1, LayoutTitle1);
        }
    }
}
