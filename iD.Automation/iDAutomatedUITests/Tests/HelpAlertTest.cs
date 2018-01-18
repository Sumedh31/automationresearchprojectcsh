using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;

using iDAutomatedUITests.Helpers;
using iDAutomatedUITests.PageObjects;
using iDAutomatedUITests.Settings;

using OpenQA.Selenium.Remote;

namespace iDAutomatedUITests.Tests
{
    public class HelpAlert : BaseTestClass
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

        //Test: 

        [Test]
        public void AlertClosing()
        {
            const string expectedText = "Alert";

            // Navigate to FE alert help components 
            HelpAlert.ClickAlert();
            HelpAlert.OpenFileErrorAlert();
            HelpAlert.ClosingAlert();
            //Verify that FE alert component has closed succesfully
            HelpAlert.VerifyAlert(expectedText);




        }


    }

}