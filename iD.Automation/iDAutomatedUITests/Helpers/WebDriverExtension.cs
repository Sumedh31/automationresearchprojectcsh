using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using iDAutomatedUITests.Settings;
using NUnit.Core;

namespace iDAutomatedUITests.Helpers
{
    public static class WebDriverExtension
    {
        private const int Timeout = 10;
        private static StringBuilder VerificationErrors { get; set; }

     
        // Is Element Present 
        public static bool IsElementPresent(this IWebDriver webDriver, string bylocator)
        {
            try
            {
                webDriver.FindElement(By.XPath(bylocator));
                return true;
            }
            catch (NoSuchElementException ignored)
            {
                return false;
            }
        }

        // Is Element Present 
        public static bool IsElementPresent(this IWebDriver webDriver, By bylocator)
        {
            try
            {
                webDriver.FindElement(bylocator);
                return true;
            }
            catch (NoSuchElementException ignored)
            {
                return false;
            }
        }

        // Is Element Not Present 
        public static bool IsElementNotPresent(this IWebDriver webDriver, string bylocator)
        {
            try
            {
                webDriver.FindElement(By.XPath(bylocator));
                return false;
            }
            catch (NoSuchElementException ignored)
            {
                return true;
            }
        }

        // Sanitize
        public static string Sanitize(string locator)
        {
            return locator.Replace("\"", " ")
                .Replace(":", " ")
                .Replace("*", " ")
                .Replace("?", "questionMark")
                .Replace("/", " ")
                .Replace("+", "plus")
                .Replace("<", " ")
                .Replace(">", " ")
                .Replace("\\", " ");
        }

        // Create Directory
        public static void CreateDirectoryIfDoesNotExists(string directoryPath)
        {
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    Console.WriteLine("Screenshot directory exists");
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(directoryPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e);
            }
        }

        // Save Screenshot
        //public static void SaveScreenShot(this IWebDriver webDriver, string locator)
        //{
        //    // get the screenshot
        //    string sanitizedLocator = Sanitize(locator);
        //    Screenshot screenshot = ((ScreenShotRemoteWebDriver)webDriver).GetScreenshot();

        //    string imagePath = Path.Combine(
        //        //            _parentLogFolder,
        //        ConfigurationPaths.ErrorScreenshotPath,
        //        sanitizedLocator + " "
        //        + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss")
        //        + ".png");

        //    //save the image
        //    CreateDirectoryIfDoesNotExists(ConfigurationPaths.ErrorScreenshotPath);

        //    screenshot.SaveAsFile(imagePath, ImageFormat.Png);
        //}

        // Wait For Element Not present
        public static void WaitForElementNotPresent(this IWebDriver webDriver, string bylocator)
        {
            for (int quarterSecond = 0; ; quarterSecond++)
            {
                if (quarterSecond >= Timeout)
                {
                    // SaveScreenShot(webDriver, "Element is still present: " + bylocator);
                    throw new NoSuchElementException("Element is still present: " + bylocator);
                }
                try
                {
                    if (!IsVisible(webDriver, bylocator)) break;
                }
                catch (NoSuchElementException e)
                {
                    if (VerificationErrors != null) VerificationErrors.Append(e.Message);
                }
                Thread.Sleep(250);
            }
        }

        // Wait For Element present
        public static void WaitForElementPresent(this IWebDriver webDriver, string byLocator)
        {
            for (int quarterSecond = 0; ; quarterSecond++)
            {
                if (quarterSecond >= Timeout)
                {
                   // SaveScreenShot(webDriver, "Element not present: " + byLocator);
                    throw new NoSuchElementException("Element not present: " + byLocator);
                }
                try
                {
                    if (IsElementPresent(webDriver, byLocator)) break;
                }
                catch (NoSuchElementException e)
                {
                    if (VerificationErrors != null) VerificationErrors.Append(e.Message);
                }
                Thread.Sleep(250);
            }
        }

        // Wait For Element present
        public static void WaitForElementPresent(this IWebDriver webDriver, By byLocator)
        {
            for (int quarterSecond = 0; ; quarterSecond++)
            {
                if (quarterSecond >= Timeout)
                {
                    //SaveScreenShot(webDriver, "Element not present: " + byLocator);
                    throw new NoSuchElementException("Element not present: " + byLocator);
                }
                try
                {
                    if (IsElementPresent(webDriver, byLocator)) break;
                }
                catch (NoSuchElementException e)
                {
                    if (VerificationErrors != null) VerificationErrors.Append(e.Message);
                }
                Thread.Sleep(250);
            }
        }
           
        // Is Visible
        public static bool IsVisible(this IWebDriver webDriver, string bylocator)
        {
            try
            {
                if (webDriver.FindElement(By.XPath(bylocator)).Displayed)
                {
                    return true;
                }
                {
                    return false;
                }
            }
            catch (StaleElementReferenceException ignored)
            {
                return false;
            }
            catch (NoSuchElementException ignored)
            {
                return false;
            }
        }

        // Get Text
        public static string GetText(this IWebDriver webDriver, string locator)
        {
            string query = webDriver.FindElement(By.XPath(locator)).Text;
            return query;
        }

        // Safe Get Text
        public static string SafeGetText(this IWebDriver webDriver, String locator)
        {
            webDriver.WaitForElementPresent(locator);
            return webDriver.GetText(locator);
        }

        // Get Value
        public static string GetValue(this IWebDriver webDriver, string locator)
        {
            string query = webDriver.FindElement(By.XPath(locator)).GetAttribute("value");
            return query;
        }

        // Safe Get Value
        public static String SafeGetValue(this IWebDriver webDriver, String locator)
        {
            webDriver.WaitForElementPresent(locator);
            return webDriver.GetValue(locator);
            
        }

        //// Safe Get Check box value
        //public static String SafeGetCheckBoxValue(this IWebDriver webDriver, string locator)
        //{
        //    webDriver.WaitForElementPresent(locator);
        //    string isChecked = webDriver.FindElement(By.XPath(locator)).GetAttribute("checked");
        //}

        // Get Selected Value
        public static string GetSelectedValue(this IWebDriver webDriver, string locator)
        {
            var selectElement = new SelectElement(webDriver.FindElement(By.XPath(locator)));
            return selectElement.SelectedOption.Text;
        }

        // Get Element By Id
        public static string GetElementById(this IWebElement webDriver, string Id)
        {
            string query = webDriver.FindElement(By.Id(Id)).GetAttribute("value");
            return query;
        }

        // Get XPath Count
        public static int GetXpathCount(this IWebDriver webDriver, string locator, int countToBeCompared)
        {
            int size = 0;
            ReadOnlyCollection<IWebElement> countOriginally = webDriver.FindElements(By.XPath(locator));
            foreach (IWebElement webElement in countOriginally)
            {
                size++;
            }
            Assert.AreEqual(size, countToBeCompared);
            return size;
        }

        // Wait For Text
        public static void WaitForText(this IWebDriver webDriver, String locator, String text)
        {
            for (int quarterSecond = 0; ; quarterSecond++)
            {
                if (quarterSecond >= Timeout)
                {
                    //SaveScreenShot(webDriver, "Text '" + text + "' in element '" + locator + "' not present.");
                    throw new NoSuchElementException("Text '" + text + "' in element '" + locator + "' not present.");
                }
                try
                {
                    if (text.Trim().Equals(GetText(webDriver, locator).Trim())) break;
                }
                catch (NoSuchElementException e)
                {
                    if (VerificationErrors != null) VerificationErrors.Append(e.Message);
                }
                Thread.Sleep(250);
            }
        }

        // Window Maximize
        public static void WindowMaximize(this IWebDriver webDriver)
        {
            webDriver.Manage().Window.Maximize();
        }

        // Refresh
        public static void Refresh(this IWebDriver webDriver)
        {
            webDriver.Navigate().Refresh();
        }

        // Clear
        public static void Clear(this IWebDriver webDriver, string locator)
        {
            webDriver.FindElement(By.XPath(locator)).Clear();
        }

        // Open
        public static void Open(this IWebDriver webDriver, String Url)
        {
            webDriver.Navigate().GoToUrl(Url);
        }

        // Select Frame By Id
        public static void SelectFrameById(this IWebDriver webDriver, String Id)
        {

            //webDriver.SwitchTo().ActiveElement(); 
            IWebElement iFrame = webDriver.FindElement(By.Id(Id));
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id(Id)));            
            webDriver.SwitchTo().Frame(iFrame);
            
        }

        // Safe Click
        public static void SafeClick(this IWebDriver webDriver, string locator)
        {
            webDriver.WaitForElementPresent(locator);
            webDriver.FindElement(By.XPath(locator)).Click();
        }

        // Safe Clink Link
        public static void SafeLinkClick(this IWebDriver webDriver, string locator)
        {
            webDriver.WaitForElementPresent(locator);
            IWebElement link = webDriver.FindElement(By.XPath(locator));
            IJavaScriptExecutor js = webDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", link);
        }


        // Safe Select
        public static void SafeSelect(this IWebDriver webDriver, string locator, string optionValue)
        {
            webDriver.WaitForElementPresent(locator);
            IWebElement element = webDriver.FindElement(By.XPath(locator));
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(optionValue);
        }

        // Safe Type
        public static void SafeType(this IWebDriver webDriver, string locator, string textToType)
        {
            webDriver.WaitForElementPresent(locator);
            webDriver.FindElement(By.XPath(locator)).SendKeys(textToType);
        }

        // Safe Drag and Drop
        public static void SafeDragAndDrop(this IWebDriver webDriver, string draggableLocator, string droppableLocator)
        {
            webDriver.WaitForElementPresent(draggableLocator);
            var draggable = webDriver.FindElement(By.XPath(draggableLocator));
            var to = webDriver.FindElement(By.XPath(droppableLocator));
            Thread.Sleep(2000);
            new Actions(webDriver).DragAndDrop(draggable, to).Build().Perform();
            Thread.Sleep(2000);
          }

        // Verify if Checkbox is checked
        public static bool IsChecked(this IWebDriver webDriver, string locator)
        {
            if(webDriver.FindElement(By.XPath(locator)).Selected)
                return true;
            else
            {
                return false;
            }
        }




        //// Solution for Excetion generated randomly
        // SelectElement GetSelectElemnt
        //public static SelectElement GetSelectElement(this IWebDriver webDriver, By byXpath)
        //{
        //    return new SelectElement(webDriver.GetElement(byXpath));
        //}

        //public static IWebElement GetElement(this IWebDriver webDriver, By by)
        //{
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        try
        //        { return webDriver.FindElement(by); }
        //        catch (Exception e)
        //        { Console.WriteLine("Exception was raised on locating element: " + e.Message); }
        //    }
        //    throw new ElementNotVisibleException(by.ToString());
        //}
    }

    
}
