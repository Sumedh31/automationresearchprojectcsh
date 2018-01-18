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

namespace iDAutomatedUITests.Tests
{
    public class AddNavBar : BaseTestClass
    {
        [SetUp]
        protected void SetUp()
        {
            SafeSetUp(true);

        }

        [TearDown]
        protected void TearDown()
        {
            SafeTearDown(true);
        }

        //Test: 

        [Test]
        public void NavAddNew()
        {
            const string expectedAddNav = "New Item";


            //NavEditor.ExpandSubsite();
            //NavEditor.ExpandNavEditor();
            common.ExpandSubsite();
            NavEditor.ExpandEditnav();
            NavEditor.ClickVertical();
            NavEditor.Clicknavitems();
            NavEditor.Clickaddmenu();
            NavEditor.Clickapply();
            NavEditor.FEURL();
            //Verify that FE Nav created as New item
            NavEditor.VerifyFeNav(expectedAddNav);




        }


    }

}