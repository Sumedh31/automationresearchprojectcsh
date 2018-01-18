using System;
using System.Drawing.Configuration;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using iDAutomatedTests.Admin.Apps.OnlineForms.TestEngine;
namespace iDAutomatedTests.Admin.Apps.OnlineForms.Tests
{
    class OnlineformTests:OnlineformPage
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
        public void addforms()
        {
            ExpandOnlineForms("Home", "Online Forms");
            AddOnlineFormsFolderUsingButtonInHeader("Test Folder is here");
        }
        [Test]
        public void Addworkflowtest()
        {
            AddWorkflowfromOnlinePage();
        }
    }
}
