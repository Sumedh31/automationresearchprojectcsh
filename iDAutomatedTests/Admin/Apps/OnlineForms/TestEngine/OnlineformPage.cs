using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.AppModules.Admin;
using Core.Wrappers;
using iDAutomatedTests.Admin.Apps.OnlineForms.Locators;
using OpenQA.Selenium;
using NUnit.Framework;


namespace iDAutomatedTests.Admin.Apps.OnlineForms.TestEngine
{
    class OnlineformPage:AdminCommonUtilities
    {
        public void ExpandOnlineForms(string subsitename,string applicationname)
        {
            Expandsubsite(subsitename);
            ExpandApplication(applicationname);

            //Selenium.SafeClick(OnlineFormsElements.ManageForms);
            
            //Selenium.SwitchTo().DefaultContent();
            //Selenium.SelectFrameById("main");
            //Selenium.SwitchTo().Frame(Selenium.FindElement(By.XPath("//frame[contains(@src,'/admin/apps/OnlineForms/listFolders.aspx')]")));
            

            //Selenium.SafeClick(String.Format(OnlineFormsElements.SelectFolderToManageForms,"Staff Feedback"));
        }

        public void SwitchtoListOfFoldersFrame()
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("main");
            Selenium.SwitchTo().Frame(Selenium.FindElement(By.XPath("//frame[contains(@src,'/admin/apps/OnlineForms/listFolders.aspx')]")));
        }

        public void SwitchtToEditControlForFormFolderFrame()
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("main");
            Selenium.SwitchTo().Frame(Selenium.FindElement(By.XPath("//frame[contains(@src,'/admin/apps/OnlineForms/listOnlineForms.aspx')]")));
        }
        public void AddOnlineFormsFolderUsingButtonInHeader(string NewFolderName)
        {
            Selenium.SafeClick(OnlineFormsElements.ManageForms);
            SwitchtoListOfFoldersFrame();
            //Start new folder creation process

            Selenium.SafeClick(OnlineFormsElements.NewFolderButtonInHeader);
            //Switch to edit control of the folder
            SwitchtToEditControlForFormFolderFrame();
            //Enter name and Desc
            Selenium.SafeType(OnlineFormsElements.FolderTitleAddFolderWizard,NewFolderName);
            Selenium.SafeType(OnlineFormsElements.FolderDescriptioninAddFolderWizard,NewFolderName);
            //Activate the folder if it is not active 
            if (Selenium.IsNotChecked(OnlineFormsElements.FolderActiveCheckbox))
            {
                Selenium.SafeClick(OnlineFormsElements.FolderActiveCheckbox);
            }
                
            //Select Workflow
            Selenium.SafeClick(OnlineFormsElements.FolderWizardNextButton);
            Selenium.SafeClick(String.Format(OnlineFormsElements.FolderWizardWorkflowTabSelectAnyParticularWorkflowCheckBox, "1 Step Approval"));
            Selenium.SafeClick(OnlineFormsElements.FolderWizardNextButton);
                
            //Set the security
            Selenium.SafeClick(OnlineFormsElements.FolderWizardNextButton);

            //Set the owners
            SelectOwnerToBeAdded("DB","alice","(alice)");
            Selenium.SafeClick(OnlineFormsElements.FolderWizardNextButton);
            //Finish the process
            Assert.IsTrue(Selenium.IsElementPresent(OnlineFormsElements.FolderWizardFinishStepConfirmFolderIsActive));
            Selenium.SafeClick(OnlineFormsElements.FolderWizardFinishButton);
             
        }
        public void AddWorkflowfromOnlinePage()
        {
            //ExpandUtilitiesMenu();
            AddWorkflow();
        }
    }
}
