using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Web;
using NUnit.Framework;
using OpenQA.Selenium;

using iDAutomatedUITests.PageObjects;
using iDAutomatedUITests.Helpers;

namespace iDAutomatedUITests.PageObjects
{
    public class WelcomePage
    {
        // Web Driver Object
        private readonly IWebDriver _welcomePage;

        // Constructor
        public WelcomePage(IWebDriver driver)
        {
            _welcomePage = driver;
        }

        // Verify that User is on Welcome Page
        public void VerifyThatUserIsOnWelcomePage()
        {
            _welcomePage.SwitchTo().DefaultContent();
            _welcomePage.SelectFrameById("header");
            _welcomePage.WaitForElementPresent(iDAutomatedUITests.UIElements.iDWelcomePageElements.LogoutLink);
            Assert.IsTrue(_welcomePage.IsElementPresent(iDAutomatedUITests.UIElements.iDWelcomePageElements.LogoutLink));
        }

        // Verify that Help link is present on the Welcome Page
        public void VerifyThatHelpLink()
        {
            _welcomePage.SwitchTo().DefaultContent();
            _welcomePage.SelectFrameById("header");
            _welcomePage.WaitForElementPresent(iDAutomatedUITests.UIElements.iDWelcomePageElements.LogoutLink);
            _welcomePage.SwitchTo().DefaultContent();
            _welcomePage.SelectFrameById("main");
            Assert.IsTrue(_welcomePage.IsElementPresent(iDAutomatedUITests.UIElements.iDWelcomePageElements.HelpLink));
        }

        // Verify UserDetails tab
        public void VerifyUserDetailsTab()
        {
            _welcomePage.SwitchTo().DefaultContent();
            _welcomePage.SelectFrameById("header");
            _welcomePage.WaitForElementPresent(iDAutomatedUITests.UIElements.iDWelcomePageElements.LogoutLink);
            _welcomePage.SwitchTo().DefaultContent();
            _welcomePage.SelectFrameById("main");
            Assert.IsTrue(_welcomePage.IsElementPresent(iDAutomatedUITests.UIElements.iDWelcomePageElements.UserDetailsTab));
        }

        // Verify Task List tab
        public void VerifyTaskListTab()
        {
            _welcomePage.SwitchTo().DefaultContent();
            _welcomePage.SelectFrameById("header");
            _welcomePage.WaitForElementPresent(iDAutomatedUITests.UIElements.iDWelcomePageElements.LogoutLink);
            _welcomePage.SwitchTo().DefaultContent();
            _welcomePage.SelectFrameById("main");
            Assert.IsTrue(_welcomePage.IsElementPresent(iDAutomatedUITests.UIElements.iDWelcomePageElements.TaskListTab));
        }

        // Navigate to Home Subsite
        public void NavigateToHome()
        {
            _welcomePage.SwitchTo().DefaultContent();
            _welcomePage.SelectFrameById("header");
            _welcomePage.WaitForElementPresent(iDAutomatedUITests.UIElements.iDWelcomePageElements.LogoutLink);
            _welcomePage.SwitchTo().DefaultContent();
            _welcomePage.SelectFrameById("menu");
            //Assert.IsTrue(_welcomePage.IsElementPresent(iDAutomatedUITests.UIElements.iDWelcomePageElements.AdminApplicationLocator));
        }

        // Expand Subsite
        public void ExpandSubsite(string subsiteName)
        {
            _welcomePage.SwitchTo().DefaultContent();
            _welcomePage.SelectFrameById("menu");
            //_welcomePage.SafeClick(String.Format(iDAutomatedUITests.UIElements.iDWelcomePageElements.SubsiteExpand,subsiteName,subsiteName));
            _welcomePage.SafeClick(iDAutomatedUITests.UIElements.iDWelcomePageElements.HomeExpand);
            Thread.Sleep(2000);
        }

        // Verify Application is Collapsed by-default
        public void VerifyApplicationListCollapsed(string applicationName)
        {
            _welcomePage.SwitchTo().DefaultContent();
            _welcomePage.SelectFrameById("menu");
            Assert.IsTrue(_welcomePage.IsElementNotPresent(String.Format(iDAutomatedUITests.UIElements.iDWelcomePageElements.AdminApplicationLocator,applicationName)));
        }

        // Verify Application list is displayed after expanding the Subsite
        public void VerifyAppicationListDisplayed(string subsiteName, string applicationName)
        {
            ExpandSubsite(subsiteName);
            _welcomePage.WaitForElementPresent(String.Format(iDAutomatedUITests.UIElements.iDWelcomePageElements.AdminApplicationLocator,applicationName));
            Assert.IsTrue(_welcomePage.IsElementPresent(String.Format(iDAutomatedUITests.UIElements.iDWelcomePageElements.AdminApplicationLocator,applicationName)));
        }

    }
}
