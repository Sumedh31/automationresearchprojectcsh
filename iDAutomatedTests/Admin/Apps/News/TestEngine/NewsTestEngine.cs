using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.AppModules.Admin;
using Core.Wrappers;
using iDAutomatedTests.Admin.Apps.News.Locators;
using System.Threading;

namespace iDAutomatedTests.Admin.Apps.News.TestEngine
{
    class NewsTestEngine :AdminCommonUtilities
    {
        public NewsTestEngine(): base()
        {
            
        }
               
        // Navigate to News
        public void AddNews(string subsitename,string applicationName,string NewsTitle, string NewsBody)
        {
           
           Expandsubsite(subsitename);
           ExpandApplication(applicationName);
           Selenium.WaitForElementPresent(NewsPageElements.MainMenuAddNewsLink);

            // Click on Add News
           Selenium.SafeClick(NewsPageElements.MainMenuAddNewsLink);

            //switch to main
           Selenium.SwitchTo().DefaultContent();
           Selenium.SelectFrameById("main");
           Selenium.WaitForElementPresent(NewsPageElements.NewsTitleTextBox);

            //Enter Title for the news
           Selenium.SafeType(NewsPageElements.NewsTitleTextBox, NewsTitle);
            Thread.Sleep(1000);
            Selenium.SafeClick(NewsPageElements.NextButton);
           
            //Swicthing to news article body frame and enter news content
            Selenium.SelectFrameById(NewsPageElements.NewsArticleBodyFrameID);
            Selenium.Clear(NewsPageElements.NewsArticleBody);
            Selenium.SafeType(NewsPageElements.NewsArticleBody, NewsBody);
            Thread.Sleep(2000);

            //Swicthing back to main window since we need to click on next button
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("main");
            Selenium.SafeClick(NewsPageElements.NextButton);
            //click finish
            Selenium.SafeClick(NewsPageElements.NewsFinishButton);
        }
    }
}
