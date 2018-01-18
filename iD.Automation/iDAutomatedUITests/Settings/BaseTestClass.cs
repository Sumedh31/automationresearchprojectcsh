using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using ExtentReportsDemo;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

using iDAutomatedUITests.Helpers;
using iDAutomatedUITests.UIElements;
using iDAutomatedUITests.PageObjects;
using System.Net;
using System.Net.Mail;
using iDAutomatedUITests.PageObjects.Common;
using iDAutomatedUITests.PageObjects.CMS.Folders;
using iDAutomatedUITests.PageObjects.CMS.Templates;
using iDAutomatedUITests.PageObjects.CMS.Pages;
using iDAutomatedUITests.PageObjects.Layout.SubsiteTemplates;
using iDAutomatedUITests.PageObjects.Layout.Layouts;

namespace iDAutomatedUITests.Settings
{
    [TestFixture]

    public abstract class BaseTestClass : Base
    {
        public FirefoxProfile Ffp;
        // Ffp.native_events_enabled = "True";
        protected IWebDriver Selenium;
        private IWebDriver _driver;
        private RemoteWebDriver _remoteDriver;
        private DesiredCapabilities _desiredCapabilities;
        protected LoginPage LoginPage;
        protected WelcomePage WelcomePage;
        protected CleverToolsPage CleverToolsPage;
        protected LayoutManager LayoutManager;
        protected QuickPollPage QuickPoll;
        protected NavEditor NavEditor;
        protected HelpAlert HelpAlert;
        protected Common common;
        protected NewsFrontend NewsFrontend;
        protected NewsAdmin NewsAdmin;
        protected Folders Folders;
        protected Templates Templates;
        protected Pages Pages;
        protected Layouts Layouts;
        protected SubsiteTemplates SubsiteTemplates;


        // SetUp
        protected void SafeSetUp(bool adminSide, [Optional] string otherUsername, [Optional] string otherPassword)
        {
            Selenium = StartBrowser();
            LoginPage = new LoginPage(Selenium);
            WelcomePage = new WelcomePage(Selenium);
            CleverToolsPage = new CleverToolsPage(Selenium);
            LayoutManager = new LayoutManager(Selenium);
            QuickPoll = new QuickPollPage(Selenium);
            NavEditor = new NavEditor(Selenium);
            HelpAlert = new HelpAlert(Selenium);
            common = new Common(Selenium);
            NewsFrontend = new NewsFrontend(Selenium);
            NewsAdmin = new NewsAdmin(Selenium);
            Folders = new Folders(Selenium);
            Templates = new Templates(Selenium);
            Pages = new Pages(Selenium);
            SubsiteTemplates = new SubsiteTemplates(Selenium);
            Layouts = new Layouts(Selenium);


            if (adminSide)
                LoginPage.LoginToiD(ApplicationSettings.ApplicationSettings.URL, ApplicationSettings.ApplicationSettings.Username, ApplicationSettings.ApplicationSettings.Password);
            else
                if (!String.IsNullOrEmpty(otherUsername))
                    LoginPage.LoginToiDFrontEnd(ApplicationSettings.ApplicationSettings.FrontEndURL, otherUsername, otherPassword);
                else
                {
                    LoginPage.LoginToiDFrontEnd(ApplicationSettings.ApplicationSettings.FrontEndURL, ApplicationSettings.ApplicationSettings.FrontEndUsername, ApplicationSettings.ApplicationSettings.FrontEndPassword);
                }
        }

        // TearDown

        protected virtual void SafeTearDown(bool adminSide)
        {


            if (adminSide)
            {
                Selenium.SwitchTo().DefaultContent();
                Selenium.SelectFrameById("header");

                Selenium.SafeClick(iDAutomatedUITests.UIElements.iDWelcomePageElements.LogoutLink);                
                IAlert javascriptAlert = Selenium.SwitchTo().Alert();

                //Click on OK button
                javascriptAlert.Accept();
                Thread.Sleep(5000);
                
                if (String.Equals(GetBrowserName(), "IE"))
                {
                    javascriptAlert.Accept();
                }
                else
                {
                    Selenium.SwitchTo().DefaultContent();

                    // Wait for Username text field to be displayed
                    Selenium.WaitForElementPresent(iDAutomatedUITests.UIElements.LoginPageElements.UserNameTextBox);

                    Thread.Sleep(3000);
                    Selenium.Quit();
                }
            }
            else
            {
                Thread.Sleep(3000);
                Selenium.Quit();
            }

        }

        // Get Browsers Name
        public string GetBrowserName()
        {
            return ApplicationSettings.ApplicationSettings.Browser;
        }

        // Get Initial URI
        public string GetInitialUri()
        {
            return ApplicationSettings.ApplicationSettings.RemoteURI;
        }

        // Start Browser
        public IWebDriver StartBrowser()
        {
            String runRemotely = ApplicationSettings.ApplicationSettings.RunRemote;
            String webBrowser = GetBrowserName();
            var remoteAddress = new Uri(GetInitialUri());

            if (runRemotely.Equals("True"))
            {
                switch (webBrowser)
                {
                    case "Firefox":
                        _desiredCapabilities = DesiredCapabilities.Firefox();
                        break;
                    case "IE":
                        _desiredCapabilities = DesiredCapabilities.InternetExplorer();
                        break;
                    case "Chrome":
                        _desiredCapabilities = DesiredCapabilities.Chrome();
                        break;
                    case "Edge":
                        _desiredCapabilities = DesiredCapabilities.Edge();
                        break;
                }

                _desiredCapabilities.IsJavaScriptEnabled = true;
                _driver = new ScreenShotRemoteWebDriver(remoteAddress, _desiredCapabilities);
            }
            else
            {
                switch (webBrowser)
                {
                    case "Firefox":

                        //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
                        //service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                        Ffp = new FirefoxProfile { AcceptUntrustedCertificates = true };
                        _driver = new FirefoxDriver(Ffp);
                        break;
                    case "IE":
                        _driver = new InternetExplorerDriver();
                        break;
                    case "Chrome":
                        _driver = new ChromeDriver();
                        break;
                    case "Edge":
                        _driver = new EdgeDriver();
                        break;
                }
            }
            return _driver;
        }



    }
}
