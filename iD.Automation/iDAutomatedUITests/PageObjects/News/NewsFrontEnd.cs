using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using System.Web;
using NUnit.Framework;
using iDAutomatedUITests.PageObjects;
using iDAutomatedUITests.Helpers;



namespace iDAutomatedUITests.PageObjects
{
    public class NewsFrontend
    {
        // Web Driver object
        private readonly IWebDriver _newsfe;



        // Constructor
        public NewsFrontend(IWebDriver driver)
        {
            _newsfe = driver;
        }


        // Navigate to News Category submit article 
        public void NavigateTOURL(string URL)
        {
            _newsfe.Navigate().GoToUrl(URL);
            Thread.Sleep(1000);
        }

        // Filling News Aticle , Summary and Body
        public void NewsArticleFE(string Title,string Summary,string Body)
        {
            _newsfe.SafeType(iDAutomatedUITests.UIElements.News.NewsFrontEnd.Title,Title);
            Thread.Sleep(1000);
            _newsfe.SafeType(iDAutomatedUITests.UIElements.News.NewsFrontEnd.Summary, Summary);
            Thread.Sleep(1000);
            _newsfe.SafeType(iDAutomatedUITests.UIElements.News.NewsFrontEnd.Body, Body);
            Thread.Sleep(3000);
        }

        // Clicking Sybmit Button
        public void ClickSubmitButton()
        {
            _newsfe.SafeClick(iDAutomatedUITests.UIElements.News.NewsFrontEnd.SubmitButton);
            Thread.Sleep(3000);
        }

        //Click on Newly Created News Link On FE
        public void NewsLinkClick()
        {
            _newsfe.SafeLinkClick(iDAutomatedUITests.UIElements.News.NewsFrontEnd.NewsTitleLink); 
            //_newsfe.SafeClick(iDAutomatedUITests.UIElements.News.NewsFrontEnd.NewsTitleLink);
            Thread.Sleep(2000);
        }

        // Verify that News Title , News Summary and News Body is visible on FE
        public void NewsAddedFEConfirm(string Title,string Summary,string Body)
        {
            string actualTitle = _newsfe.SafeGetText(iDAutomatedUITests.UIElements.News.NewsFrontEnd.NewsTitle);
            string actualSummary = _newsfe.SafeGetText(iDAutomatedUITests.UIElements.News.NewsFrontEnd.NewsSummary);
            string actualBody = _newsfe.SafeGetText(iDAutomatedUITests.UIElements.News.NewsFrontEnd.NewsBody);

            Assert.AreEqual(Title, actualTitle);
            Assert.AreEqual(Summary, actualSummary);
            Assert.AreEqual(Body, actualBody);
        }
    }
}