using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Web;
using NUnit.Framework;
using OpenQA.Selenium;
using Core.Base;
using Core.Wrappers;
using iDAutomatedTests.Admin.Generic.Locators;
using Core.AppModules.Admin;

namespace iDAutomatedTests.Admin.Generic.AdminWelcomePage.TestEngine
{
    public class AdminWelcomePageClass:AdminCommonUtilities
    {
        // Constructor
        public AdminWelcomePageClass(): base()
        {            
        }
        
        // Verify that User is on Welcome Page
        public void VerifyThatUserIsOnWelcomePage()
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("header");
            Selenium.WaitForElementPresent(iDWelcomePageElements.LogoutLink);
            Assert.IsTrue(Selenium.IsElementPresent(iDWelcomePageElements.LogoutLink));
        }

        // Verify that Help link is present on the Welcome Page
        public void VerifyThatHelpLink()
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("header");
            Selenium.WaitForElementPresent(iDWelcomePageElements.LogoutLink);
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("main");
            Assert.IsTrue(Selenium.IsElementPresent(iDWelcomePageElements.HelpLink));
        }

        // Verify UserDetails tab
        public void VerifyUserDetailsTab()
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("header");
            Selenium.WaitForElementPresent(iDWelcomePageElements.LogoutLink);
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("main");
            Assert.IsTrue(Selenium.IsElementPresent(iDWelcomePageElements.UserDetailsTab));
        }

        // Verify Task List tab
        public void VerifyTaskListTab()
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("header");
            Selenium.WaitForElementPresent(iDWelcomePageElements.LogoutLink);
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("main");
            Assert.IsTrue(Selenium.IsElementPresent(iDWelcomePageElements.TaskListTab));
        }

        // Navigate to Home Subsite
        public void NavigateToHome()
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("header");
            Selenium.WaitForElementPresent(iDWelcomePageElements.LogoutLink);
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("menu");
            //Assert.IsTrue(Selenium.IsElementPresent(iDWelcomePageElements.AdminApplicationLocator));
        }

        // Expand Subsite
        public void ExpandSubsite(string subsiteName)
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("menu");
            //Selenium.SafeClick(String.Format(iDWelcomePageElements.SubsiteExpand,subsiteName,subsiteName));
            Selenium.SafeClick(iDWelcomePageElements.HomeExpand);
            Thread.Sleep(2000);
        }

        // Verify Application is Collapsed by-default
        public void VerifyApplicationListCollapsed(string applicationName)
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("menu");
            Assert.IsTrue(Selenium.IsElementNotPresent(String.Format(iDWelcomePageElements.AdminApplicationLocator,applicationName)));
        }

        // Verify Application list is displayed after expanding the Subsite
        public void VerifyAppicationListDisplayed(string subsiteName, string applicationName)
        {
            ExpandSubsite(subsiteName);
            Selenium.WaitForElementPresent(String.Format(iDWelcomePageElements.AdminApplicationLocator,applicationName));
            Assert.IsTrue(Selenium.IsElementPresent(String.Format(iDWelcomePageElements.AdminApplicationLocator,applicationName)));
        }

    }
}
