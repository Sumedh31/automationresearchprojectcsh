using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using OpenQA.Selenium;
using NUnit.Framework;
using iDAutomatedUITests.Helpers;
using iDAutomatedUITests.PageObjects;

namespace iDAutomatedUITests.PageObjects
{
    public class LoginPage
    {
        private static IWebDriver _loginPage;

        // Constructor
        public LoginPage(IWebDriver driver)
        {
            _loginPage = driver;
        }

        // Login to iD - Admin
        public static void LoginToiD(string url, String userName, String password)
        {
            string subsiteName = "Home";
            _loginPage.Open(url);
            _loginPage.WindowMaximize();
            _loginPage.WaitForElementPresent(iDAutomatedUITests.UIElements.LoginPageElements.UserNameTextBox);
            _loginPage.Clear(iDAutomatedUITests.UIElements.LoginPageElements.UserNameTextBox);
            _loginPage.Clear(iDAutomatedUITests.UIElements.LoginPageElements.PasswordTextBox);
            _loginPage.SafeType(iDAutomatedUITests.UIElements.LoginPageElements.UserNameTextBox, userName);
            _loginPage.SafeType(iDAutomatedUITests.UIElements.LoginPageElements.PasswordTextBox, password);
             //LoginButton
            _loginPage.SafeClick(iDAutomatedUITests.UIElements.LoginPageElements.AdminLoginButton);
            Thread.Sleep(2000);
            _loginPage.SwitchTo().DefaultContent();
            _loginPage.SelectFrameById("header");
            _loginPage.WaitForElementPresent(iDAutomatedUITests.UIElements.iDWelcomePageElements.LogoutLink);
             Thread.Sleep(2000);
        }

        // Login to iD - FrontEnd
        public static void LoginToiDFrontEnd(string url, String userName, String password)
        {
            string subsiteName = "Home";
            _loginPage.Open(url);
            _loginPage.WindowMaximize();

            _loginPage.Clear(iDAutomatedUITests.UIElements.LoginPageElements.FrontEndUsernameTextBox);
            _loginPage.Clear(iDAutomatedUITests.UIElements.LoginPageElements.FrontEndPasswordTextBox);

            _loginPage.SafeType(iDAutomatedUITests.UIElements.LoginPageElements.FrontEndUsernameTextBox, userName);
            _loginPage.SafeType(iDAutomatedUITests.UIElements.LoginPageElements.FrontEndPasswordTextBox, password);

            _loginPage.SafeClick(iDAutomatedUITests.UIElements.LoginPageElements.FrontEndLoginButton);
            Thread.Sleep(10000);

            //_loginPage.SwitchTo().DefaultContent();
            //_loginPage.SelectFrameById("header");
            //_loginPage.WaitForElementPresent(iDAutomatedUITests.UIElements.LayoutManagerElements.ManageLayout);
            //Thread.Sleep(5000);
        }

        // Logout
        public static void Logout()
        {
            _loginPage.SafeClick(iDAutomatedUITests.UIElements.iDWelcomePageElements.LogoutLink);
            _loginPage.WaitForElementPresent(iDAutomatedUITests.UIElements.LoginPageElements.AdminLoginButton);
            Thread.Sleep(2000);
            _loginPage.Quit();
        }
    }
}
