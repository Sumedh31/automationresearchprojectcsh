using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using System.Web;
using NUnit.Framework;
using iDAutomatedUITests.PageObjects.Common;
using iDAutomatedUITests.Helpers;

namespace iDAutomatedUITests.PageObjects.Common
{
    public class Common
    {
        // Web Driver object
        private readonly IWebDriver _common;

         // Constructor
        public Common(IWebDriver driver)
        {
            _common = driver;
        }

        public void ExpandSubsite()
        {
            _common.SwitchTo().DefaultContent();
            _common.SelectFrameById("menu");
            _common.SafeClick(iDAutomatedUITests.UIElements.NavEditor.NavEditor.Home);
            Thread.Sleep(2000);
        }

        // Navigate to URL
        public void URL(string URL)
        {
            _common.Navigate().GoToUrl(URL);
            Thread.Sleep(3000);
        }

        public void WindowMaximize()
        {
            _common.WindowMaximize();
        }
    }
}
