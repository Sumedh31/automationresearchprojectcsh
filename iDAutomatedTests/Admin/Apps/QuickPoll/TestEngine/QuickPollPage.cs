using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using System.Web;
using NUnit.Framework;
using Core.Base;
using Core.Wrappers;
using iDAutomatedTests.Admin.Apps.QuickPoll.Locators;
using iDAutomatedTests.Admin.Generic.Locators;
using Core.AppModules.Admin;


using NUnit.Core;

namespace iDAutomatedTests.Admin.Apps.QuickPoll.TestEngine
{
    public class QuickPollPage:AdminCommonUtilities
    {

        public bool deleteConfirm;

        //constructor
        public QuickPollPage():base()
        {
            
        }
        
        // Navigate to Quick Poll
        public void NavigateToQuickPoll(string subsitename, string applicationName)
        {
            Expandsubsite(subsitename);
            ExpandApplication(applicationName);
        }

        // Verify if Active check box is checked
        public bool VerfiyActiveCheckbox(string locator)
        {
            bool IsChecked = Selenium.IsChecked(locator);
            if (IsChecked == true)
                return true;
            else
            {
                return false;
            }

        }

        // Verify if Allow Multiple Votes Per User is checked
        public bool VerifyAllowMultipleVotesPerUserCheckBox(string locator)
        {
            bool isChecked = Selenium.IsChecked(locator);
            if (isChecked == true)
                return true;
            else
            {
                return false;
            }
        }

        // Add Quick Poll
        public void AddQuickPoll(int numOfAnswers, string question, Boolean allowMultipleVotes, Boolean active,
            string answer1, string answer2, [Optional] string answer3, [Optional] string readMoreLink)
        {
            // Click on Add Poll in Admin Menu
            Selenium.WaitForElementPresent(QuickPollAddPollAdminElements.AddPollSubMenuOption);
            Selenium.SafeClick(QuickPollAddPollAdminElements.AddPollSubMenuOption);

            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("main");

            Selenium.WaitForElementPresent(QuickPollAddPollAdminElements.StepTypePollRadioButton);

            // Select Poll option
            Selenium.SafeClick(QuickPollAddPollAdminElements.StepTypePollRadioButton);

            // Click on Next
            Selenium.SafeClick(QuickPollAddPollAdminElements.StepNextButton);
            Selenium.WaitForElementPresent(QuickPollAddPollAdminElements.StepQuestionQuestionTextBox);
            Thread.Sleep(1000);

            // Enter Question
            if (question != String.Empty)
            {
                Selenium.SafeType(
                    QuickPollAddPollAdminElements.StepQuestionQuestionTextBox, question);
            }

            // Select Allow Multiple votes if required
            if (allowMultipleVotes == true)
            {
                bool allowVotes =
                    VerifyAllowMultipleVotesPerUserCheckBox(QuickPollAddPollAdminElements.StepQuestionAllowMultipleVotesPerUserCheckBox);
                if (allowVotes == false)
                {
                    Selenium.SafeClick(QuickPollAddPollAdminElements.StepQuestionAllowMultipleVotesPerUserCheckBox);
                    Thread.Sleep(2000);
                }
            }
            else
            {
                bool allowVotes =
                    VerifyAllowMultipleVotesPerUserCheckBox(QuickPollAddPollAdminElements.StepQuestionAllowMultipleVotesPerUserCheckBox);
                if (allowVotes == true)
                {
                    Selenium.SafeClick(QuickPollAddPollAdminElements.StepQuestionAllowMultipleVotesPerUserCheckBox);
                    Thread.Sleep(2000);
                }
            }

            // Select Active/Inavtive
            if (active == true)
            {
                bool activeCheckBox =
                    VerfiyActiveCheckbox(QuickPollAddPollAdminElements.StepQuestionActiveCheckBox);

                if (activeCheckBox == false)
                {
                    Selenium.SafeClick(QuickPollAddPollAdminElements.StepQuestionActiveCheckBox);
                }

            }
            else
            {
                bool activeCheckBox =
                    VerfiyActiveCheckbox(QuickPollAddPollAdminElements.StepQuestionActiveCheckBox);

                if (activeCheckBox == true)
                {
                    Selenium.SafeClick(QuickPollAddPollAdminElements.StepQuestionActiveCheckBox);
                }
            }

            // Click on Next
            Selenium.SafeClick(QuickPollAddPollAdminElements.StepNextButton);
            Selenium.WaitForElementPresent(QuickPollAddPollAdminElements.StepAnswersAddAnswerButton);
            Thread.Sleep(1000);

            // Add Answers text boxes
            if (numOfAnswers > 2)
            {
                for (int i = 3; i <= numOfAnswers; i++)
                {
                    Selenium.SafeClick(QuickPollAddPollAdminElements.StepAnswersAddAnswerButton);
                    Selenium.WaitForElementPresent(String.Format(QuickPollAddPollAdminElements.StepAnswersAnswerTextBox,numOfAnswers));
                }
            }

            Thread.Sleep(4000);

            if (answer1 != String.Empty)
            {
                Selenium.SafeClick(String.Format(QuickPollAddPollAdminElements.StepAnswersAnswerTextBox,"2"));
                Selenium.SafeType(String.Format(QuickPollAddPollAdminElements.StepAnswersAnswerTextBox,"2"), answer1);
                Thread.Sleep(1000);

            }

            if (answer2 != String.Empty)
            {
                Selenium.SafeClick(String.Format(QuickPollAddPollAdminElements.StepAnswersAnswerTextBox,"3"));
                Selenium.SafeType(String.Format(QuickPollAddPollAdminElements.StepAnswersAnswerTextBox,"3"), answer2);
                Thread.Sleep(1000);
            }

            if (answer3 != String.Empty)
            {
                Selenium.SafeClick(String.Format(QuickPollAddPollAdminElements.StepAnswersAnswerTextBox,"4"));
                Selenium.SafeType(String.Format(QuickPollAddPollAdminElements.StepAnswersAnswerTextBox,"4"), answer3);
                Thread.Sleep(1000);
            }

            // Add Read More Link
            if (readMoreLink != String.Empty)
            {
                Selenium.SafeType(QuickPollAddPollAdminElements.StepAnswersReadMoreLinkTextBox,readMoreLink);
                Thread.Sleep(2000);
            }

            //Click on Next
            Selenium.SafeClick(QuickPollAddPollAdminElements.StepNextButton);
            Selenium.WaitForElementPresent(QuickPollAddPollAdminElements.StepFinishButton);

            // Click on Finish
            Selenium.SafeClick(QuickPollAddPollAdminElements.StepFinishButton);
            Thread.Sleep(4000);
        }

        // Edit Quick Poll - Add New Answers (need to slightly update it while adding answers)
        public void EditPollAddNewsAnswers(string question, int oldNumberOfAnswers, int newNumberOfAnswers, string newAnswer1, [Optional] string newAnswer2, [Optional] string newAnswer3)
        {
            // Add text boxes for new answers
            for (int i = 1; i <= newNumberOfAnswers; i++)
            {
                Selenium.SafeClick(QuickPollAddPollAdminElements.EditPollAddNewAnswerButton);
                Selenium.WaitForElementPresent(String.Format(QuickPollAddPollAdminElements.EditPollAnswerTextBox, i + oldNumberOfAnswers + 1));

                // Add data in new answer text boxes
                Selenium.SafeClick(String.Format(QuickPollAddPollAdminElements.EditPollAnswerTextBox, i + oldNumberOfAnswers + 1));
                Selenium.SafeType(String.Format(QuickPollAddPollAdminElements.EditPollAnswerTextBox, i + oldNumberOfAnswers + 1), newAnswer1);
                Thread.Sleep(1000);
            }

            // Click on OK
           Selenium.SafeClick(QuickPollAddPollAdminElements.EditPollOKButton);
           Selenium.WaitForElementPresent(
               String.Format(QuickPollAddPollAdminElements.EditPollEditLink, question));

        }

        // Update Quick Poll Question
        public void UpdateQuickPollQuestion(string oldQuestion, string newQuestion)
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("menu");

            //Click on Edit Poll option
            Selenium.WaitForElementPresent(QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Selenium.SafeClick(QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Thread.Sleep(2000);

            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("main");

            // Edit Poll
            Selenium.WaitForElementPresent(String.Format(QuickPollAddPollAdminElements.EditPollEditLink, oldQuestion));
            Selenium.SafeClick(String.Format(QuickPollAddPollAdminElements.EditPollEditLink, oldQuestion));
            Selenium.WaitForElementPresent(QuickPollAddPollAdminElements.EditPollQuestionsTab);

            // Clear Question text box
            Selenium.Clear(QuickPollAddPollAdminElements.EditPollQuestionTextBox);

            // Update Question
            Selenium.SafeType(QuickPollAddPollAdminElements.EditPollQuestionTextBox,newQuestion);
            Selenium.WaitForElementPresent(QuickPollAddPollAdminElements.EditPollOKButton);

            // Click on OK
            Selenium.SafeClick(QuickPollAddPollAdminElements.EditPollOKButton);
            Selenium.WaitForElementPresent(String.Format(QuickPollAddPollAdminElements.EditPollEditLink, newQuestion));

        }

        // Edit Quick Poll
        public void EditQuickPoll(string question)
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("menu");

            //Click on Edit Poll option
            Selenium.WaitForElementPresent(QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Selenium.SafeClick(QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Thread.Sleep(2000);

            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("main");

            // Edit Poll
            Selenium.WaitForElementPresent(String.Format(QuickPollAddPollAdminElements.EditPollEditLink, question));
            Selenium.SafeClick(String.Format(QuickPollAddPollAdminElements.EditPollEditLink, question));
            Selenium.WaitForElementPresent(QuickPollAddPollAdminElements.EditPollQuestionsTab);

        }

        // Edit Quick Poll - Get Question Name
        public string GetQuestionName()
        {
            Selenium.WaitForElementPresent(QuickPollAddPollAdminElements.EditPollQuestionTextBox);

            Selenium.SafeClick(QuickPollAddPollAdminElements.EditPollQuestionTextBox);
            string questionName = Selenium.GetValue(QuickPollAddPollAdminElements.EditPollQuestionTextBox);
            return questionName;
        }

        // Delete Quick Poll
        public void DeleteQuickPoll(string question, bool confirmdeleteoption)
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("menu");

            //Click on Edit Poll option
            Selenium.WaitForElementPresent(QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Selenium.SafeClick(QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Thread.Sleep(2000);

            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("main");

            //Click on Delete button for quick poll
            Selenium.WaitForElementPresent(String.Format(QuickPollDeletePollAdminElements.DeleteButton, question));
            Selenium.SafeClick(String.Format(QuickPollDeletePollAdminElements.DeleteButton, question));
            Thread.Sleep(4000);

            // if yes, quick poll will be deleted otherwise it will not
            if (confirmdeleteoption)
            {
                IAlert javascriptAlert = Selenium.SwitchTo().Alert();
                javascriptAlert.Accept();
            }
            else
            {
                IAlert javascriptAlert = Selenium.SwitchTo().Alert();
                javascriptAlert.Dismiss();
            }
        }

        // Verify that Quick Poll is deleted 
        public void VerifyQuickPollDeletedSuccessfully(string question)
        {
            //Navigating to admin menu->Quick Poll application
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("menu");

            //Click on Edit Poll option
            Selenium.WaitForElementPresent(QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Selenium.SafeClick(QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Thread.Sleep(2000);

            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("main");

            //verifying deleted Quick Poll does not exists
            Assert.IsTrue(Selenium.IsElementNotPresent(String.Format(QuickPollDeletePollAdminElements.DeleteButton, question)));

        }

        // Verify that Quick Poll is Added
        public void VerifyQuickPollAddedSuccesfully(string question)
        {
            //Switching to quick poll
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("menu");

            //Click on edit quick poll

            Selenium.WaitForElementPresent(QuickPollAddPollAdminElements.EditPollSubMenuOption);
            Selenium.SafeClick(QuickPollAddPollAdminElements.EditPollSubMenuOption);

            //Verifying question is present
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("main");
            Selenium.WaitForElementPresent(
                String.Format(QuickPollDeletePollAdminElements.DeleteButton, question));
            Assert.IsTrue(Selenium.IsElementPresent(String.Format(QuickPollAddPollAdminElements.VerifyQuestion, question)));
        }

        // Update Quick Poll - Allow Multiple Votes
        public void UpdateQuickPollAllowMultipleVotes(string question, bool newValue)
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("menu");

            //Click on Edit Poll option
            Selenium.WaitForElementPresent(QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Selenium.SafeClick(QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Thread.Sleep(2000);

            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("main");

            // Edit Poll
            Selenium.WaitForElementPresent(String.Format(QuickPollAddPollAdminElements.EditPollEditLink, question));
            Selenium.SafeClick(String.Format(QuickPollAddPollAdminElements.EditPollEditLink, question));
            Selenium.WaitForElementPresent(QuickPollAddPollAdminElements.EditPollQuestionsTab);

            // Update Allow Multiple Votes check box
            if (newValue == true)
            {
                bool allowVotes =
                    VerifyAllowMultipleVotesPerUserCheckBox(QuickPollAddPollAdminElements.StepQuestionAllowMultipleVotesPerUserCheckBox);
                if (allowVotes == false)
                {
                    Selenium.SafeClick(QuickPollAddPollAdminElements.StepQuestionAllowMultipleVotesPerUserCheckBox);
                    Thread.Sleep(2000);
                }

            }

            else
            {
                bool allowVotes =
                    VerifyAllowMultipleVotesPerUserCheckBox(QuickPollAddPollAdminElements.StepQuestionAllowMultipleVotesPerUserCheckBox);
                if (allowVotes == true)
                {
                    Selenium.SafeClick(QuickPollAddPollAdminElements.StepQuestionAllowMultipleVotesPerUserCheckBox);
                    Thread.Sleep(2000);
                }
            }

            // Click on OK
            Selenium.SafeClick(QuickPollAddPollAdminElements.EditPollOKButton);
            Selenium.WaitForElementPresent(String.Format(QuickPollAddPollAdminElements.EditPollEditLink, question));
        }

        // Update Quick Poll - Active Check Box
        public void UpdateQuickPollActiveCheckBox(string question, bool newValue)
        {
            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("menu");

            //Click on Edit Poll option
            Selenium.WaitForElementPresent(QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Selenium.SafeClick(QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Thread.Sleep(2000);

            Selenium.SwitchTo().DefaultContent();
            Selenium.SelectFrameById("main");

            // Edit Poll
            Selenium.WaitForElementPresent(String.Format(QuickPollAddPollAdminElements.EditPollEditLink, question));
            Selenium.SafeClick(String.Format(QuickPollAddPollAdminElements.EditPollEditLink, question));
            Selenium.WaitForElementPresent(QuickPollAddPollAdminElements.EditPollQuestionsTab);

            // Update Allow Multiple Votes check box
            if (newValue == true)
            {
                bool allowVotes =
                    VerifyAllowMultipleVotesPerUserCheckBox(QuickPollAddPollAdminElements.StepQuestionActiveCheckBox);
                if (allowVotes == false)
                {
                    Selenium.SafeClick(QuickPollAddPollAdminElements.StepQuestionActiveCheckBox);
                    Thread.Sleep(2000);
                }

            }

            else
            {
                bool allowVotes =
                    VerifyAllowMultipleVotesPerUserCheckBox(QuickPollAddPollAdminElements.StepQuestionActiveCheckBox);
                if (allowVotes == true)
                {
                    Selenium.SafeClick(QuickPollAddPollAdminElements.StepQuestionActiveCheckBox);
                    Thread.Sleep(2000);
                }
            }

            // Click on OK
            Selenium.SafeClick(QuickPollAddPollAdminElements.EditPollOKButton);
            Selenium.WaitForElementPresent(String.Format(QuickPollAddPollAdminElements.EditPollEditLink, question));
        }

        // Get Allow Multiple Votes check box status
        public bool GetAllowMultipleVotesStatus()
        {
            bool isChecked =
                Selenium.IsChecked(QuickPollAddPollAdminElements.EditPollAllowMultipleVotesCheckbox);
            if (isChecked == true)
                return true;
            else
            {
                return false;
            }
        }

        // Get Active Check box status
        public bool GetActiveCheckBoxStatus()
        {
            bool isChecked =
                Selenium.IsChecked(QuickPollAddPollAdminElements.EditPollActiveCheckBox);
            if (isChecked == true)
                return true;
            else
            {
                return false;
            }
        }

        // Navigate to Answers Tab - Edit Tab
        public void NavigateToAnswersTabEditPoll()
        {
            Selenium.SafeClick(QuickPollAddPollAdminElements.EditPollQuestionsTab);
            Selenium.WaitForElementPresent(QuickPollAddPollAdminElements.EditPollQuestionTextBox);

            // Click on Answers Tab
            Selenium.SafeClick(QuickPollAddPollAdminElements.EditPollAnswersTab);
            Selenium.WaitForElementPresent(QuickPollAddPollAdminElements.EditPollAddNewAnswerButton);

        }

    }
}

