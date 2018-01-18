using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using Core.Wrappers;
using System.Runtime.InteropServices;
using Core.Generic.Locators.Admin;
using System.Threading;
using Core.Generic.MainFrameSettings;

namespace Core.Base
{
    [TestFixture]
    public class BaseClass
    {
           
        public FirefoxProfile Ffp;
        // Ffp.native_events_enabled = "True";

        protected IWebDriver Selenium;
        public IWebDriver webdriver;
        private RemoteWebDriver _remoteDriver;
        private DesiredCapabilities _desiredCapabilities;
       

        public BaseClass()
        {
            Selenium = StartBrowser();
        }

        
        // Get Browsers Name
        public string GetBrowserName()
        {
            return ApplicationSettings.Browser;
        }

        // Get Initial URI
        public string GetInitialUri()
        {
            return ApplicationSettings.RemoteURI;
        }

        // Start Browser
        public IWebDriver StartBrowser()
        {
            String runRemotely = ApplicationSettings.RunRemote;
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
                }

                _desiredCapabilities.IsJavaScriptEnabled = true;
                //webdriverobject = new ScreenShotRemoteWebDriver(remoteAddress, _desiredCapabilities);
            }
            else
            {
                switch (webBrowser)
                {
                    case "Firefox":
                       
                        //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
                        //service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                        Ffp = new FirefoxProfile { AcceptUntrustedCertificates = true };
                        Selenium = new FirefoxDriver(Ffp);
                        break;
                    case "IE":
                        Selenium = new InternetExplorerDriver();
                        break;
                    case "Chrome":
                        Selenium = new ChromeDriver();
                        break;
                }
            }
            return Selenium;
        }

    }
}


