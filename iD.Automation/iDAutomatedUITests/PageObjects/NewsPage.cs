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
    public class NewsPage
    {
        private static IWebDriver _newsPage;
        private static WelcomePage _welcomePage;

        // Constructor
        public NewsPage(IWebDriver driver)
        {
            _newsPage = driver;
        }

        // Navigate to News
        public static void AddNews(string applicationName)
        {
            _welcomePage.ExpandSubsite(applicationName);
            _newsPage.WaitForElementPresent(iDAutomatedUITests.UIElements.NewsPageElements.MainMenuAddNewsLink);

            // Click on Add News
            _newsPage.SafeClick(iDAutomatedUITests.UIElements.NewsPageElements.MainMenuAddNewsLink);
            _newsPage.WaitForElementPresent(iDAutomatedUITests.UIElements.NewsPageElements.NewsTitleTextBox);
        }


    }
}
