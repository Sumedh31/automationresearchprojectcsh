using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Core.Generic.MainFrameSettings;
using Core.Wrappers;
using Core.Base;
using Core.Generic.Locators.Admin;
using System.Threading;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

namespace Core.AppModules.FrontEnd
{
    public class FrontEndCommnUtilities:BaseClass
    {

        public FrontEndCommnUtilities() : base() { }

        //setup
        protected void FrontEndLogin([Optional] string otherUsername, [Optional] string otherPassword)
        {
            
            if (!String.IsNullOrEmpty(otherUsername))
                LoginToiDFrontEnd(ApplicationSettings.FrontEndURL, otherUsername, otherPassword);
            else
            {
                LoginToiDFrontEnd(ApplicationSettings.FrontEndURL, ApplicationSettings.FrontEndUsername, ApplicationSettings.FrontEndPassword);
            }
        }

        // Login to iD - FrontEnd
        public void LoginToiDFrontEnd(string url, String userName, String password)
        {
            string subsiteName = "Home";
            Selenium.Open(url);
            Selenium.WindowMaximize();

            Selenium.Clear(LoginPageElements.FrontEndUsernameTextBox);
            Selenium.Clear(LoginPageElements.FrontEndPasswordTextBox);

            Selenium.SafeType(LoginPageElements.FrontEndUsernameTextBox, userName);
            Selenium.SafeType(LoginPageElements.FrontEndPasswordTextBox, password);

            Selenium.SafeClick(LoginPageElements.FrontEndLoginButton);
            Thread.Sleep(10000);

            Selenium.SwitchTo().DefaultContent();
            //webdriver.SelectFrameById("header");
            //webdriver.WaitForElementPresent(LayoutManagerElements.ManageLayout);

            Thread.Sleep(5000);
        }

        protected virtual void SafeFETearDown(bool adminSide)
        {
            if (adminSide)
            {
                Selenium.SwitchTo().DefaultContent();
                Selenium.SelectFrameById("header");

                Selenium.SafeClick(iDWelcomePageElements.LogoutLink);

                IAlert javascriptAlert = Selenium.SwitchTo().Alert();

                // Click on OK button
                javascriptAlert.Accept();

                //commenting out following switch and sleep calls to check if we can do even without them
                //Thread.Sleep(5000);

                //Selenium.SwitchTo().DefaultContent();

                // Wait for Username text field to be displayed
                Selenium.WaitForElementPresent(LoginPageElements.UserNameTextBox);

                //Thread.Sleep(3000);
                Selenium.Quit();
            }
            else
            {
                Thread.Sleep(3000);
                Selenium.Quit();
            }

        }

    }
}
