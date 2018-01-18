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
    public class NewsAdmin 
    {
        // Web Driver object
        private readonly IWebDriver _newsadmin;



        // Constructor
        public NewsAdmin(IWebDriver driver)
        {
            _newsadmin = driver;
        }



        // Clicking News on Admin side and expanding 
        public void NewsLinkClick()
        {
            Console.WriteLine("Clicking news link on admin side");
            _newsadmin.SwitchTo().DefaultContent();
            _newsadmin.SelectFrameById("menu");
            _newsadmin.SafeClick(iDAutomatedUITests.UIElements.News.NewsAdmin.News);
            Thread.Sleep(2000);
        }

        // Click on Admin Approve News 
        public void NewsApproveClick()
        {
           _newsadmin.SwitchTo().DefaultContent();
           _newsadmin.SelectFrameById("menu");
           _newsadmin.SafeClick(iDAutomatedUITests.UIElements.News.NewsAdmin.NewsApprove);
            Thread.Sleep(2000);
        }

        // Click on Admin News Category
        public void NewsCategoryClick()
        {
            _newsadmin.SwitchTo().DefaultContent();
            _newsadmin.SelectFrameById("main");
            _newsadmin.SafeClick(iDAutomatedUITests.UIElements.News.NewsAdmin.NewsCategory);
            Thread.Sleep(2000);
        }
        //Click on Approve button 
        public void NewsApproveButtonClick()
        {
            _newsadmin.SwitchTo().DefaultContent();
            _newsadmin.SelectFrameById("main");
            _newsadmin.SafeClick(iDAutomatedUITests.UIElements.News.NewsAdmin.NewsApproveButton);
            Thread.Sleep(1000);
        }
    }
}