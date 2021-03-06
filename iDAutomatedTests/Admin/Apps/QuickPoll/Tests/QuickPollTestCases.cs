using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using Core.Base;
using iDAutomatedTests.Admin.Apps.QuickPoll.TestEngine;

using OpenQA.Selenium.Remote;

namespace iDAutomatedTests.Admin.Apps.QuickPoll.Tests
{
    public class QuickPollTestCases : QuickPollPage
    {
        
        [SetUp]
        protected void SetUp()
        {
            AdminLogin();
          
        }

        [TearDown]
        protected void TearDown()
        {
            SafeTearDown(true);
        }


        // Add Quick Poll 
        [Test]
        public void AddQuickPoll()
        {
            const string applicationName = "Quick Poll";
            const string subsiteName = "Home";
            const int numberOfAnswers = 3;
            const string question = "What is the full form on iD?";
            const Boolean allowMultipleVotes = true;
            const Boolean activeCheckBox = true;
            const string answer1 = "Internet Dashboard";
            const string answer2 = "Intranet Dashboard";
            const string answer3 = "Inernational Dashbaord";
            const string readMoreLink = "http://help.intranetdashboard.com";

            // Navigate to Quick Poll
            NavigateToQuickPoll(subsiteName, applicationName);

            // Add Quick Poll
            AddQuickPoll(numberOfAnswers, question, allowMultipleVotes, activeCheckBox, answer1, answer2, answer3, readMoreLink);

            // Delete Quick Poll
            DeleteQuickPoll(question, true);

        }

        // Verify Quick Poll Added
        [Test]
        public void VerifyQuickPollisAddedSuccesfully()
        {
            const string applicationName = "Quick Poll";
            const string subsiteName = "Home";
            const int numberOfAnswers = 3;
            const string question = "Should we delete the test data at the end of the test case?";
            const Boolean allowMultipleVotes = true;
            const Boolean activeCheckBox = true;
            const string answer1 = "Yes";
            const string answer2 = "No";
            const string answer3 = "Maybe";
            const string readMoreLink = "http://help.intranetdashboard.com";

            //Navigating to Quick Poll
            NavigateToQuickPoll(subsiteName, applicationName);

            //Add Quick Poll
            AddQuickPoll(numberOfAnswers, question, allowMultipleVotes, activeCheckBox, answer1, answer2, answer3, readMoreLink);

            //Verify if quick poll is present
            VerifyQuickPollAddedSuccesfully(question);

            //Deleting quick poll data 
            DeleteQuickPoll(question, true);

        }

        // Edit Quick Poll Question
        [Test]
        public void EditQuickPollQuestion()
        {
            const string applicationName = "Quick Poll";
            const string subsiteName = "Home";
            const int numberOfAnswers = 3;
            const string question = "Quick Poll is widely used iD applicaton?";
            const Boolean allowMultipleVotes = true;
            const Boolean activeCheckBox = true;
            const string answer1 = "Yes";
            const string answer2 = "No";
            const string answer3 = "Maybe";
            const string readMoreLink = "http://help.intranetdashboard.com";

            const string newQuestion = "Updated Question - Quick Poll is widely used iD applicaton?";

            // Navigate to Quick Poll
            NavigateToQuickPoll(subsiteName, applicationName);

            // Add Quick Poll
            AddQuickPoll(numberOfAnswers, question, allowMultipleVotes, activeCheckBox, answer1, answer2, answer3, readMoreLink);

            // Edit Quick Poll - Question
            UpdateQuickPollQuestion(question, newQuestion);

            // Edit Quick Poll
            EditQuickPoll(newQuestion);

            // Verify Question Name
            Assert.AreEqual(newQuestion, GetQuestionName());

            // Deleting Quick Poll
            DeleteQuickPoll(newQuestion, true);
        }
        
        // Edit QuickPoll Allow Multiple Votes check box
        [Test]
        public void EditQuickPollAllowMultipleVotes()
        {
            const string applicationName = "Quick Poll";
            const string subsiteName = "Home";
            const int numberOfAnswers = 3;
            const string question = "Automation helps to test Quick Poll easily?";
            const Boolean allowMultipleVotes = true;
            const Boolean activeCheckBox = true;
            const string answer1 = "Yes";
            const string answer2 = "No";
            const string answer3 = "Maybe";
            const string readMoreLink = "http://help.intranetdashboard.com";

            // Navigate to Quick Poll
            NavigateToQuickPoll(subsiteName, applicationName);

            // Add Quick Poll
            AddQuickPoll(numberOfAnswers, question, allowMultipleVotes, activeCheckBox, answer1, answer2, answer3, readMoreLink);

            // Update Allow Multiple Votes check box
            UpdateQuickPollAllowMultipleVotes(question, false);

            // Edit Quick Poll
            EditQuickPoll(question);
            
            // Get Allow Multiple Votes check box status
            Assert.AreEqual(false, GetAllowMultipleVotesStatus());
            
            // Deleting Quick Poll
            DeleteQuickPoll(question, true);
        }

        // Edit QuickPoll Active Check box
        [Test]
        public void EditQuickPollActiveCheckbox()
        {
            const string applicationName = "Quick Poll";
            const string subsiteName = "Home";
            const int numberOfAnswers = 3;
            const string question = "Quick Poll application is very easy to use?";
            const Boolean allowMultipleVotes = true;
            const Boolean activeCheckBox = true;
            const string answer1 = "Yes";
            const string answer2 = "No";
            const string answer3 = "Maybe";
            const string readMoreLink = "http://help.intranetdashboard.com";

            // Navigate to Quick Poll
            NavigateToQuickPoll(subsiteName, applicationName);

            // Add Quick Poll
            AddQuickPoll(numberOfAnswers, question, allowMultipleVotes, activeCheckBox, answer1, answer2, answer3, readMoreLink);

            // Update Allow Multiple Votes check box
            UpdateQuickPollActiveCheckBox(question, false);

            // Edit Quick Poll
            EditQuickPoll(question);

            // Get Active check box status
            Assert.AreEqual(false, GetActiveCheckBoxStatus());

            // Deleting Quick Poll
            DeleteQuickPoll(question, true);
        }

        // Edit Quick Poll and Add Answers
        [Test]
        public void EditQuickPollAddAnswers()
        {
            const string applicationName = "Quick Poll";
            const string subsiteName = "Home";
            const int oldNumberOfAnswers = 3;
            const string question = "Should we edit this Question and add new answers?";
            const Boolean allowMultipleVotes = true;
            const Boolean activeCheckBox = true;
            const string answer1 = "Yes";
            const string answer2 = "No";
            const string answer3 = "Maybe";
            const string readMoreLink = "http://help.intranetdashboard.com";

            const int newNumberOfAnswers = 2;
            const string newAnswer1 = "Definitely Yes";
            const string newAnswer2 = "Definitely No";

            // Navigate to Quick Poll
            NavigateToQuickPoll(subsiteName, applicationName);

            // Add Quick Poll
            AddQuickPoll(oldNumberOfAnswers, question, allowMultipleVotes, activeCheckBox, answer1, answer2, answer3, readMoreLink);

            // Edit Quick Poll
            EditQuickPoll(question);

            // Navigate to Answers tab
            NavigateToAnswersTabEditPoll();

            // Add New Answers
            EditPollAddNewsAnswers(question, oldNumberOfAnswers, newNumberOfAnswers, newAnswer1, newAnswer2);

            // Deleting Quick Poll
            DeleteQuickPoll(question, true);
        }

        // Delete Quick Poll
        [Test]
        public void DeleteQuickPollQuestion()
        {
            const string applicationName = "Quick Poll";
            const string subsiteName = "Home";
            const string quickPollName = "Should we delete this Quick Poll?";
            const int numberOfAnswers = 3;
            const Boolean confirmQuickPollName = true;
            const Boolean allowMultipleVotes = true;
            const Boolean activeCheckBox = true;
            const string answer1 = "Yes";
            const string answer2 = "No";
            const string answer3 = "Maybe";
            const string readMoreLink = "http://help.intranetdashboard.com";

            // Navigate to Quick Poll
            NavigateToQuickPoll(subsiteName, applicationName);

            // Add Quick Poll
            AddQuickPoll(numberOfAnswers, quickPollName, allowMultipleVotes, activeCheckBox, answer1, answer2, answer3, readMoreLink);

            //Delete Quick Poll
            DeleteQuickPoll(quickPollName, confirmQuickPollName);

            // Verify that Quick Poll has been delete successfully
            VerifyQuickPollDeletedSuccessfully(quickPollName);

        }

        

    }
}
