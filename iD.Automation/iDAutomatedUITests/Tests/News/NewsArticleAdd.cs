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
using ExtentReportsDemo;
using log4net;


namespace iDAutomatedUITests.Tests
{
    public class NewsArticleAdd : BaseTestClass
    {


      

        [SetUp]
        protected void SetUp()
        {
            SafeSetUp(false);
        }

        [TearDown]
        protected void TearDown()
        {
            SafeTearDown(false);
        }

        //Testing that news article submitted from FE , goes to approval , Admin user can approve and FE can see the news 
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("TestAppender"); 

        [Test]
 
        public void NewsArticleAddFE()
        {
            //TO Do : Remove hardcoded URL and replace with a function to open link "Submit Article"
            string URL = "http://feredo/home/news/Home-LatestNews/UserNews.aspx";
            string Title = "News Title Test";
            string Summary = "News Summary Test";
            string Body = "News Body Test";

                     

            log.Info("Giving URL ");
            NewsFrontend.NavigateTOURL(URL);
            NewsFrontend.NewsArticleFE(Title, Summary, Body);
            NewsFrontend.ClickSubmitButton();
            common.WindowMaximize();

            LoginPage.LoginToiD(ApplicationSettings.ApplicationSettings.URL, ApplicationSettings.ApplicationSettings.Username, ApplicationSettings.ApplicationSettings.Password);
            common.ExpandSubsite();
            NewsAdmin.NewsLinkClick();
            NewsAdmin.NewsApproveClick();
            NewsAdmin.NewsCategoryClick();
            NewsAdmin.NewsApproveButtonClick();

            IAlert javaScript = Selenium.SwitchTo().Alert();
            javaScript.Accept();
            Thread.Sleep(2000);
            common.WindowMaximize();
            LoginPage.LoginToiDFrontEnd(ApplicationSettings.ApplicationSettings.FrontEndURL, ApplicationSettings.ApplicationSettings.FrontEndUsername, ApplicationSettings.ApplicationSettings.FrontEndPassword);

            NewsFrontend.NewsLinkClick();
            Thread.Sleep(2000);

           // Testing Actual vs expetced Tile, Summary and Body
           NewsFrontend.NewsAddedFEConfirm(Title,Summary,Body);
        }
    }
}