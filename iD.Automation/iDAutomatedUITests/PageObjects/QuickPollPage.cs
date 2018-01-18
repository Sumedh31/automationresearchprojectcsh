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

using iDAutomatedUITests.PageObjects;
using iDAutomatedUITests.Helpers;
using iDAutomatedUITests.UIElements;
using NUnit.Core;

namespace iDAutomatedUITests.PageObjects
{
    public class QuickPollPage
    {

        private readonly IWebDriver _quickPoll;
        public bool deleteConfirm;

        //constructor
        public QuickPollPage(IWebDriver driver)
        {
            _quickPoll = driver;
        }

        //Expand subsite
        public void ExpandSubsite(String subsitename)
        {
            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("menu");
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.iDWelcomePageElements.HomeExpand);
            Thread.Sleep(2000);
        }

        // Expand Quick Poll
        public void ExpandApplication(string subsiteName, string applicationName)
        {
            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("menu");
            _quickPoll.SafeClick(String.Format(iDAutomatedUITests.UIElements.iDWelcomePageElements.SubsiteExpand,
                applicationName, applicationName));
        }

        // Navigate to Quick Poll
        public void NavigateToQuickPoll(string subsitename, string applicationName)
        {
            ExpandSubsite(subsitename);
            ExpandApplication(applicationName, applicationName);
        }

        // Verify if Active check box is checked
        public bool VerfiyActiveCheckbox(string locator)
        {
            bool IsChecked = _quickPoll.IsChecked(locator);
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
            bool isChecked = _quickPoll.IsChecked(locator);
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
            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.AddPollSubMenuOption);
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.AddPollSubMenuOption);

            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("main");

            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepTypePollRadioButton);

            // Select Poll option
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepTypePollRadioButton);

            // Click on Next
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepNextButton);
            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepQuestionQuestionTextBox);
            Thread.Sleep(1000);

            // Enter Question
            if (question != String.Empty)
            {
                _quickPoll.SafeType(
                    iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepQuestionQuestionTextBox, question);
            }

            // Select Allow Multiple votes if required
            if (allowMultipleVotes == true)
            {
                bool allowVotes =
                    VerifyAllowMultipleVotesPerUserCheckBox(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements
                            .StepQuestionAllowMultipleVotesPerUserCheckBox);
                if (allowVotes == false)
                {
                    _quickPoll.SafeClick(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements
                            .StepQuestionAllowMultipleVotesPerUserCheckBox);
                    Thread.Sleep(2000);
                }
            }
            else
            {
                bool allowVotes =
                    VerifyAllowMultipleVotesPerUserCheckBox(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements
                            .StepQuestionAllowMultipleVotesPerUserCheckBox);
                if (allowVotes == true)
                {
                    _quickPoll.SafeClick(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements
                            .StepQuestionAllowMultipleVotesPerUserCheckBox);
                    Thread.Sleep(2000);
                }
            }

            // Select Active/Inavtive
            if (active == true)
            {
                bool activeCheckBox =
                    VerfiyActiveCheckbox(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepQuestionActiveCheckBox);

                if (activeCheckBox == false)
                {
                    _quickPoll.SafeClick(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepQuestionActiveCheckBox);
                }

            }
            else
            {
                bool activeCheckBox =
                    VerfiyActiveCheckbox(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepQuestionActiveCheckBox);

                if (activeCheckBox == true)
                {
                    _quickPoll.SafeClick(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepQuestionActiveCheckBox);
                }
            }

            // Click on Next
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepNextButton);
            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepAnswersAddAnswerButton);
            Thread.Sleep(1000);

            // Add Answers text boxes
            if (numOfAnswers > 2)
            {
                for (int i = 3; i <= numOfAnswers; i++)
                {
                    _quickPoll.SafeClick(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepAnswersAddAnswerButton);
                    _quickPoll.WaitForElementPresent(
                        String.Format(
                            iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepAnswersAnswerTextBox,
                            numOfAnswers));
                }
            }

            Thread.Sleep(4000);

            if (answer1 != String.Empty)
            {
                _quickPoll.SafeClick(
                    String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepAnswersAnswerTextBox,
                        "2"));
                _quickPoll.SafeType(
                    String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepAnswersAnswerTextBox,
                        "2"), answer1);
                Thread.Sleep(1000);

            }

            if (answer2 != String.Empty)
            {
                _quickPoll.SafeClick(
                    String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepAnswersAnswerTextBox,
                        "3"));
                _quickPoll.SafeType(
                    String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepAnswersAnswerTextBox,
                        "3"), answer2);
                Thread.Sleep(1000);
            }

            if (answer3 != String.Empty)
            {
                _quickPoll.SafeClick(
                    String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepAnswersAnswerTextBox,
                        "4"));
                _quickPoll.SafeType(
                    String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepAnswersAnswerTextBox,
                        "4"), answer3);
                Thread.Sleep(1000);
            }

            // Add Read More Link
            if (readMoreLink != String.Empty)
            {
                _quickPoll.SafeType(
                    iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepAnswersReadMoreLinkTextBox,
                    readMoreLink);
                Thread.Sleep(2000);
            }

            //Click on Next
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepNextButton);
            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepFinishButton);

            // Click on Finish
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepFinishButton);
            Thread.Sleep(4000);
        }

        // Edit Quick Poll - Add New Answers (need to slightly update it while adding answers)
        public void EditPollAddNewsAnswers(string question, int oldNumberOfAnswers, int newNumberOfAnswers, string newAnswer1, [Optional] string newAnswer2, [Optional] string newAnswer3)
        {
            // Add text boxes for new answers
            for (int i = 1; i <= newNumberOfAnswers; i++)
            {
                _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollAddNewAnswerButton);
                _quickPoll.WaitForElementPresent(String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollAnswerTextBox, i + oldNumberOfAnswers + 1));

                // Add data in new answer text boxes
                _quickPoll.SafeClick(String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollAnswerTextBox, i + oldNumberOfAnswers + 1));
                _quickPoll.SafeType(String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollAnswerTextBox, i + oldNumberOfAnswers + 1), newAnswer1);
                Thread.Sleep(1000);
            }

            // Click on OK
           _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollOKButton);
           _quickPoll.WaitForElementPresent(
               String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollEditLink, question));

        }

        // Update Quick Poll Question
        public void UpdateQuickPollQuestion(string oldQuestion, string newQuestion)
        {
            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("menu");

            //Click on Edit Poll option
            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Thread.Sleep(2000);

            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("main");

            // Edit Poll
            _quickPoll.WaitForElementPresent(
                String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollEditLink, oldQuestion));
            _quickPoll.SafeClick(
                String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollEditLink, oldQuestion));
            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollQuestionsTab);

            // Clear Question text box
            _quickPoll.Clear(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollQuestionTextBox);

            // Update Question
            _quickPoll.SafeType(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollQuestionTextBox,
                newQuestion);
            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollOKButton);

            // Click on OK
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollOKButton);
            _quickPoll.WaitForElementPresent(
                String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollEditLink, newQuestion));

        }

        // Edit Quick Poll
        public void EditQuickPoll(string question)
        {
            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("menu");

            //Click on Edit Poll option
            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Thread.Sleep(2000);

            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("main");

            // Edit Poll
            _quickPoll.WaitForElementPresent(
                String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollEditLink, question));
            _quickPoll.SafeClick(
                String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollEditLink, question));
            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollQuestionsTab);

        }

        // Edit Quick Poll - Get Question Name
        public string GetQuestionName()
        {
            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollQuestionTextBox);

            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollQuestionTextBox);
            string questionName =
                _quickPoll.GetValue(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollQuestionTextBox);
            return questionName;
        }

        // Delete Quick Poll
        public void DeleteQuickPoll(string question, bool confirmdeleteoption)
        {
            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("menu");

            //Click on Edit Poll option
            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Thread.Sleep(2000);

            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("main");

            //Click on Delete button for quick poll
            _quickPoll.WaitForElementPresent(
                String.Format(iDAutomatedUITests.UIElements.QuickPollDeletePollAdminElements.DeleteButton, question));
            _quickPoll.SafeClick(
                String.Format(iDAutomatedUITests.UIElements.QuickPollDeletePollAdminElements.DeleteButton, question));
            Thread.Sleep(4000);

            // if yes, quick poll will be deleted otherwise it will not
            if (confirmdeleteoption)
            {
                IAlert javascriptAlert = _quickPoll.SwitchTo().Alert();
                javascriptAlert.Accept();
            }
            else
            {
                IAlert javascriptAlert = _quickPoll.SwitchTo().Alert();
                javascriptAlert.Dismiss();
            }
        }

        // Verify that Quick Poll is deleted 
        public void VerifyQuickPollDeletedSuccessfully(string question)
        {
            //Navigating to admin menu->Quick Poll application
            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("menu");

            //Click on Edit Poll option
            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Thread.Sleep(2000);

            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("main");

            //verifying deleted Quick Poll does not exists
            Assert.IsTrue(
                _quickPoll.IsElementNotPresent(
                    String.Format(iDAutomatedUITests.UIElements.QuickPollDeletePollAdminElements.DeleteButton, question)));

        }

        // Verify that Quick Poll is Added
        public void VerifyQuickPollAddedSuccesfully(string question)
        {
            //Switching to quick poll
            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("menu");

            //Click on edit quick poll

            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollSubMenuOption);
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollSubMenuOption);

            //Verifying question is present
            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("main");
            _quickPoll.WaitForElementPresent(
                String.Format(iDAutomatedUITests.UIElements.QuickPollDeletePollAdminElements.DeleteButton, question));
            Assert.IsTrue(
                _quickPoll.IsElementPresent(
                    String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.VerifyQuestion, question)));
        }

        // Update Quick Poll - Allow Multiple Votes
        public void UpdateQuickPollAllowMultipleVotes(string question, bool newValue)
        {
            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("menu");

            //Click on Edit Poll option
            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Thread.Sleep(2000);

            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("main");

            // Edit Poll
            _quickPoll.WaitForElementPresent(
                String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollEditLink, question));
            _quickPoll.SafeClick(
                String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollEditLink, question));
            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollQuestionsTab);

            // Update Allow Multiple Votes check box
            if (newValue == true)
            {
                bool allowVotes =
                    VerifyAllowMultipleVotesPerUserCheckBox(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements
                            .StepQuestionAllowMultipleVotesPerUserCheckBox);
                if (allowVotes == false)
                {
                    _quickPoll.SafeClick(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements
                            .StepQuestionAllowMultipleVotesPerUserCheckBox);
                    Thread.Sleep(2000);
                }

            }

            else
            {
                bool allowVotes =
                    VerifyAllowMultipleVotesPerUserCheckBox(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements
                            .StepQuestionAllowMultipleVotesPerUserCheckBox);
                if (allowVotes == true)
                {
                    _quickPoll.SafeClick(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements
                            .StepQuestionAllowMultipleVotesPerUserCheckBox);
                    Thread.Sleep(2000);
                }
            }

            // Click on OK
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollOKButton);
            _quickPoll.WaitForElementPresent(
                String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollEditLink, question));
        }

        // Update Quick Poll - Active Check Box
        public void UpdateQuickPollActiveCheckBox(string question, bool newValue)
        {
            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("menu");

            //Click on Edit Poll option
            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollDeletePollAdminElements.EditPollSubMenuOption);
            Thread.Sleep(2000);

            _quickPoll.SwitchTo().DefaultContent();
            _quickPoll.SelectFrameById("main");

            // Edit Poll
            _quickPoll.WaitForElementPresent(
                String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollEditLink, question));
            _quickPoll.SafeClick(
                String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollEditLink, question));
            _quickPoll.WaitForElementPresent(
                iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollQuestionsTab);

            // Update Allow Multiple Votes check box
            if (newValue == true)
            {
                bool allowVotes =
                    VerifyAllowMultipleVotesPerUserCheckBox(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements
                            .StepQuestionActiveCheckBox);
                if (allowVotes == false)
                {
                    _quickPoll.SafeClick(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepQuestionActiveCheckBox);
                    Thread.Sleep(2000);
                }

            }

            else
            {
                bool allowVotes =
                    VerifyAllowMultipleVotesPerUserCheckBox(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements
                            .StepQuestionActiveCheckBox);
                if (allowVotes == true)
                {
                    _quickPoll.SafeClick(
                        iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.StepQuestionActiveCheckBox);
                    Thread.Sleep(2000);
                }
            }

            // Click on OK
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollOKButton);
            _quickPoll.WaitForElementPresent(
                String.Format(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollEditLink, question));
        }

        // Get Allow Multiple Votes check box status
        public bool GetAllowMultipleVotesStatus()
        {
            bool isChecked =
                _quickPoll.IsChecked(
                    iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollAllowMultipleVotesCheckbox);
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
                _quickPoll.IsChecked(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollActiveCheckBox);
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
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollQuestionsTab);
            _quickPoll.WaitForElementPresent(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollQuestionTextBox);

            // Click on Answers Tab
            _quickPoll.SafeClick(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollAnswersTab);
            _quickPoll.WaitForElementPresent(iDAutomatedUITests.UIElements.QuickPollAddPollAdminElements.EditPollAddNewAnswerButton);

        }

    }
}

