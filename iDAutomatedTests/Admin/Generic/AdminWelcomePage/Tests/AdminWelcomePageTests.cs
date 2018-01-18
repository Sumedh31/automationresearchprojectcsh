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
using Core.Base;
using Core.Wrappers;
using OpenQA.Selenium.Remote;
using iDAutomatedTests.Admin.Generic.AdminWelcomePage.TestEngine;

namespace iDAutomatedTests.Admin.Generic.AdminWelcomePage.Tests
{
    public class AdminWelcomePageTests :AdminWelcomePageClass
    {
  
        [SetUp]
        protected void SetUp()
        {
            AdminLogin();
        }

        [TearDown]
        protected void TearDown()
        {
            SafeTearDown(true);
        }


        [Test]
        public void VerifyThatValidUserCanLoginToiDSuccessfully()
        {
            VerifyThatUserIsOnWelcomePage();
        }

        [Test]
        public void VerifyThatHelpLInkIsPresentOnWelcomePage()
        {
            VerifyThatHelpLink();
        }

        [Test]
        public void VerifyThatTaskListTabIsDisplayedOnWelcomePage()
        {
            VerifyTaskListTab();

         }

        [Test]
        public void VerifyThatUserDetailsTabIsDisplayedOnWelcomePage()
        {
            VerifyUserDetailsTab();
        }

        [Test]
        public void VerifyThatApplicationListIsCollapsedByDefault()
        {
            string applicationName = "Subsite Admin";
            VerifyApplicationListCollapsed(applicationName);
        }

        [Test]
        public void VerifyThatAppicationListIsDisplayedAfterExpandingSubsite()
        {
            string subsiteName = "Home";
            string applicationName = "Subsite Admin";

            VerifyAppicationListDisplayed(subsiteName, applicationName);
        }

       


    }
}
