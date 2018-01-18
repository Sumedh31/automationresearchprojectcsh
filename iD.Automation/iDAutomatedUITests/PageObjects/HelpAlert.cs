using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

using System.Threading;
using System.Web;
using NUnit.Framework;

using iDAutomatedUITests.PageObjects;
using iDAutomatedUITests.Helpers;


namespace iDAutomatedUITests.PageObjects
{
    public class HelpAlert
    {
        // Web Driver object
        private readonly IWebDriver _alert;


        // Constructor
        public HelpAlert(IWebDriver driver)
        {
            _alert = driver;
        }

        // Click on Alert Help Component
        public void ClickAlert()
        {
            _alert.SafeClick(String.Format(iDAutomatedUITests.UIElements.UIHelpPages.Alert));
            Thread.Sleep(1000);
            Console.WriteLine("Clicked on Alert help Component");
        }

        // Open File error alert
        public void OpenFileErrorAlert()
        {
            _alert.SafeClick(iDAutomatedUITests.UIElements.UIHelpPages.FileError);
            Thread.Sleep(1000);
        }

        // Click on Ok button and close alert box
        public void ClosingAlert()
        {
            _alert.SafeClick(iDAutomatedUITests.UIElements.UIHelpPages.OkButton);
            Thread.Sleep(1000);
        }

        // Verify that Alert has been closed succesfully
        public void VerifyAlert(string expectedText)
        {
            string actualText = _alert.SafeGetText(iDAutomatedUITests.UIElements.UIHelpPages.Alert);
            Assert.AreEqual(expectedText, actualText);
        }
    }
}