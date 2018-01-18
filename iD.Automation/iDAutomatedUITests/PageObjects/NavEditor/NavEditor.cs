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
    public class NavEditor
    {
        // Web Driver object
        private readonly IWebDriver _nav;



        // Constructor
        public NavEditor(IWebDriver driver)
        {
            _nav = driver;
        }

         //Expand Nav Editor
        public void ExpandNavEditor()
        {
            _nav.SwitchTo().DefaultContent();
            _nav.SelectFrameById("menu");
            _nav.SafeClick(String.Format(iDAutomatedUITests.UIElements.NavEditor.NavEditor.NavLink));
           Thread.Sleep(2000);
        }



        // Click on Edit Nav Bar 
        public void ExpandEditnav()
        {
             _nav.SwitchTo().DefaultContent();
             _nav.SelectFrameById("main");
             _nav.SafeClick(String.Format(iDAutomatedUITests.UIElements.NavEditor.NavEditor.NavEdit));
             Thread.Sleep(2000);
               
        }

        // Click on Vertical Nav bar
        public void ClickVertical()
        {
            _nav.SwitchTo().DefaultContent();
            _nav.SelectFrameById("main");
            _nav.SafeClick(String.Format(iDAutomatedUITests.UIElements.NavEditor.NavEditor.VerticalEdit));
            Thread.Sleep(2000);

        }

        // Click on nav items
        public void Clicknavitems()
        {
            _nav.SwitchTo().DefaultContent();
            _nav.SelectFrameById("main");
            _nav.SafeClick(String.Format(iDAutomatedUITests.UIElements.NavEditor.NavEditor.NavItems));
            Thread.Sleep(2000);

        }

        // Click on addmenu
        public void Clickaddmenu()
        {
            _nav.SwitchTo().DefaultContent();
            _nav.SelectFrameById("main");
            _nav.SafeClick(String.Format(iDAutomatedUITests.UIElements.NavEditor.NavEditor.AddNavMenu));
            Thread.Sleep(2000);

        }

        // Click on apply
        public void Clickapply()
        {
            _nav.SwitchTo().DefaultContent();
            _nav.SelectFrameById("main");
            _nav.SafeClick(String.Format(iDAutomatedUITests.UIElements.NavEditor.NavEditor.Apply));
            Thread.Sleep(2000);

        }
        //Call FE URL 
        public void FEURL()
        {
            _nav.Navigate().GoToUrl("http://feredo/home/");
        }

        // Verify that FE Nav Item has been created
        public void VerifyFeNav(string expectedAddNav)
        {
            string actualAddNav = _nav.SafeGetText(iDAutomatedUITests.UIElements.NavEditor.NavEditor.FeNav);


            Assert.AreEqual(expectedAddNav, actualAddNav);
        }
         



    }
}