using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Base;
using Core.Generic.MainFrameSettings;
using Core.Generic.Locators.Admin;
using System.Runtime.InteropServices;
using Core.Wrappers;
using System.Threading;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;


namespace Core.AppModules.Admin
{
    public class AdminCommonUtilities : BaseClass
    {
        public AdminCommonUtilities() : base() { }
        // Login to iD - Admin
        public void LoginToiD(string url, String userName, String password)
        {
            string subsiteName = "Home";
            Selenium.Open(url);

            Selenium.WindowMaximize();

            Selenium.WaitForElementPresent(LoginPageElements.UserNameTextBox);

            Selenium.Clear(LoginPageElements.UserNameTextBox);
            Selenium.SafeType(LoginPageElements.UserNameTextBox, userName);

            Selenium.Clear(LoginPageElements.PasswordTextBox);
            Selenium.SafeType(LoginPageElements.PasswordTextBox, password);
            ////LoginButton
            Selenium.SafeClick(LoginPageElements.AdminLoginButton);
            Thread.Sleep(10000);

            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("header");
            Selenium.WaitForElementPresent(iDWelcomePageElements.LogoutLink);

            //Thread.Sleep(5000);
        }
        // Logout
        public void Logout()
        {
            Selenium.SafeClick(iDWelcomePageElements.LogoutLink);
            Selenium.WaitForElementPresent(LoginPageElements.AdminLoginButton);
            Thread.Sleep(2000);
            //webdriver.Quit();
        }
        // SetUp
        protected void AdminLogin([Optional] string otherUsername, [Optional] string otherPassword)
        {

            LoginToiD(ApplicationSettings.URL, ApplicationSettings.Username, ApplicationSettings.Password);

        }
        protected virtual void SafeTearDown(bool adminSide)
        {
            if (adminSide)
            {
                Selenium.SwitchTo().DefaultContent();
                Selenium.SelectFrameById("header");

                Selenium.SafeClick(iDWelcomePageElements.LogoutLink);

                IAlert javascriptAlert = Selenium.SwitchTo().Alert();

                // Click on OK button
                javascriptAlert.Accept();
                if (String.Equals(GetBrowserName(), "IE"))
                {
                    javascriptAlert.Accept();
                }

                //commenting out following switch and sleep calls to check if we can do even without them
                //Thread.Sleep(5000);

                //Selenium.SwitchTo().DefaultContent();

                // Wait for Username text field to be displayed
                else
                {
                    Selenium.WaitForElementPresent(LoginPageElements.UserNameTextBox);

                    //Thread.Sleep(3000);
                    Selenium.Quit();
                }
            }
            else
            {
                Thread.Sleep(3000);
                Selenium.Quit();
            }

        }

        public void AddWorkflow()
        {
            ExpandUtilitiesMenu();
            Selenium.SafeClick(WorkflowControlElements.WorkflowMenuUnderUtilities);
            string parent_window = Selenium.WindowHandles.Last();
            Selenium.SafeClick(WorkflowControlElements.AddWorkflowMenuItem);
            string child_window = Selenium.WindowHandles.Last();
            Selenium.SwitchTo().Window(child_window);
            Selenium.WindowMaximize();
            Selenium.SafeType(WorkflowControlElements.AddWorkflow_Title,"TestWorkflow");
            Selenium.SafeType(WorkflowControlElements.AddWorkFlow_Description,"TestDesc");
            Selenium.SafeClick(WorkflowControlElements.AddWorkFlow_CreateWorkflowButton);                        
            Thread.Sleep(3000);
            Actions builder = new Actions(Selenium);
            builder.DoubleClick().Perform();            
            IWebElement first_step = Selenium.FindElement(By.XPath("//div[.='Start']//.."));
            IWebElement firststep_Bottom = Selenium.FindElement(By.XPath("//div[.='Start']//..//following-sibling::div[@anchortype='bottom']"));
            int x = firststep_Bottom.Location.X;
            int y = firststep_Bottom.Location.Y;
            IWebElement second_step = Selenium.FindElement(By.XPath("//div[.='Untitled Step (1)']//.."));
            //IWebElement drop_to = Selenium.FindElement(By.XPath("//div[.='Start']//..//following-sibling::div[@anchortype='bottom']"));
            //Selenium.SafeDragAndDrop("//div[.='Untitled Step (1)']//..", "//div[.='Start']//..//following-sibling::div[@anchortype='bottom']");
            builder.DragAndDropToOffset(second_step,x, y).Perform();//DragAndDropToOffset(second_step,x,y-3);
            Thread.Sleep(4000);
            //builder.MoveToElement(first_step).Perform();           
            Selenium.SwitchTo().Window(parent_window);
            
        }

        public void ExpandUtilitiesMenu()
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("menu");
            //Selenium.SafeClick(iDWelcomePageElements.AdministrationExpand);
            Selenium.SafeClick(iDWelcomePageElements.UtilitiesExapand);
        }

        public void Expandsubsite(string Subsitename)
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("menu");
            Selenium.SafeClick(iDWelcomePageElements.HomeExpand);
            Selenium.WaitForElementPresent(iDWelcomePageElements.FirstTreeElementInExpandedSubsite);
        }

        public void ExpandApplication(string ApplicationName)
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("menu");
            Selenium.SafeClick(String.Format(iDWelcomePageElements.ApplicationExpand, ApplicationName, ApplicationName));
            Thread.Sleep(2000);

        }

        public void SelectOwnerToBeAdded(string AddUserFromValue, string SearchKeyWordForGivenName,string UsernameOfTheOwner)
        {
            //Click On Add Owners button and select Add From Option // and enter search key words for user searching
            Selenium.SafeClick(OwnerSelectControl.AddOwnersButton);
            Selenium.SafeType(OwnerSelectControl.GivenNameOwnerUserSearch,SearchKeyWordForGivenName);

            //Uncomment this to enable optional parameteres
            //if (!String.IsNullOrEmpty(SearchKeyWordForLastName))
            //{
            //        Selenium.SafeType(OwnerSelectControl.lastNameOwnerUserSearch,SearchKeyWordForLastName);
            //}
            //else if(!String.IsNullOrEmpty(SearchKeyWordForEmail))
            //{
            //        Selenium.SafeType(OwnerSelectControl.EmailInOwnerUserSearch, SearchKeyWordForEmail);
            //}

            //Select value either AD or DB to determine whether to extract user from DB or AD
            SelectElement AddFromCheckBox = new SelectElement(Selenium.FindElement(By.XPath(OwnerSelectControl.AddFromDropDownInUserSearch)));
            AddFromCheckBox.SelectByValue(AddUserFromValue);

            //In case if user will be extraxcted from AD add additional wait
            if (String.Equals(AddUserFromValue, "AD"))
            {
                Thread.Sleep(5000);
                Selenium.SafeClick(OwnerSelectControl.SearchButtonInUserSearch);
            }
            //Else search the user directly
            else
            {
                Selenium.SafeClick(OwnerSelectControl.SearchButtonInUserSearch);
            }
            //Now Select particular user from the returned search results
            Selenium.SafeClick(String.Format(OwnerSelectControl.SelectParticularUserCheckBoxSearchResults,UsernameOfTheOwner));
            Selenium.SafeClick(OwnerSelectControl.ClickOkToAddUserFromSearchResults);
        }
    }
}
