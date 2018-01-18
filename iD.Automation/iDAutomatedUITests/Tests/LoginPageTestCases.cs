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
    public class LoginPageTestCases : BaseTestClass
    {

      

        [SetUp]
        protected void SetUp()
        {
            SafeSetUp(true);
        }

        [TearDown]
        protected void TearDown()
        {
            SafeTearDown(true);
        }


        [Test]
        public void VerifyThatValidUserCanLoginToiDSuccessfully()
        {
            WelcomePage.VerifyThatUserIsOnWelcomePage();
        }

        [Test]
        public void VerifyThatHelpLInkIsPresentOnWelcomePage()
        {
            WelcomePage.VerifyThatHelpLink();
        }

        [Test]
        public void VerifyThatTaskListTabIsDisplayedOnWelcomePage()
        {
           WelcomePage.VerifyTaskListTab();

         }

        [Test]
        public void VerifyThatUserDetailsTabIsDisplayedOnWelcomePage()
        {
            WelcomePage.VerifyUserDetailsTab();
        }

        [Test]
        public void VerifyThatApplicationListIsCollapsedByDefault()
        {
            string applicationName = "Subsite Admin";
            WelcomePage.VerifyApplicationListCollapsed(applicationName);
        }

        [Test]
        public void VerifyThatAppicationListIsDisplayedAfterExpandingSubsite()
        {
            string subsiteName = "Home";
            string applicationName = "Subsite Admin";

            WelcomePage.VerifyAppicationListDisplayed(subsiteName,applicationName);
        }

       


    }
}
