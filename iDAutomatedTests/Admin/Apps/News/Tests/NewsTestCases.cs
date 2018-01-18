using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iDAutomatedTests.Admin.Apps.News.TestEngine;
using NUnit.Framework;


namespace iDAutomatedTests.Admin.Apps.News.Tests
{
    class NewsTestCases:NewsTestEngine
    {
        [SetUp]
        public void setup()
        {
            AdminLogin();
        }
        [TearDown]
        public void TearDown()
        {
            SafeTearDown(true);
        }
        [Test]
        public void AddNews()
        {
            const string subsitename = "Home";
            const string applicationname = "News";
            const string NewsTitle = "TestNews";
            const string NewsBody = "News body for test please test this carefully";
            AddNews(subsitename, applicationname, NewsTitle, NewsBody);
        }
    }
}
