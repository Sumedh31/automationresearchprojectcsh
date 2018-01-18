using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using System.Web;
using NUnit.Framework;
using iDAutomatedUITests.PageObjects;
using iDAutomatedUITests.PageObjects.Common;
using iDAutomatedUITests.Helpers;
using System.Runtime.InteropServices;
using iDAutomatedUITests.UIElements;
using NUnit.Core;

namespace iDAutomatedUITests.PageObjects.CMS.Folders
{
    public class Folders
    {
        // Web Driver object
        private  readonly IWebDriver _folders;

        // Constructor
        public Folders(IWebDriver driver)
        {
            _folders = driver;
        }

        // Clicking on iD CMS Folder 'Publish Content Pages'
        public void ClickFolder()
        {
            _folders.WaitForElementPresent(
                iDAutomatedUITests.UIElements.CMS.Folders.Folders.PublishContentPagesFolder);
            _folders.SafeClick(iDAutomatedUITests.UIElements.CMS.Folders.Folders.PublishContentPagesFolder);
            Thread.Sleep(5000);
        }
    }
}
