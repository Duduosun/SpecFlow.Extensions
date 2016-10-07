using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlow.Extensions.PageObjects;
using SpecFlow.Extensions.WebDriver;
using SpecFlow.Extensions.WebDriver.PortalDriver;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SpecFlow.Extensions.Tests
{
    [Binding]
    public sealed class TestModalSteps
    {
        private IPortalDriver d;
        public TestModalSteps(WebContext webContext)
        {
            d = webContext.PortalDriver;
        }

        [Given(@"I go to the test modal page")]
        public void GivenIGoToTheTestModalPage()
        {
            ((IWebDriver)d).Navigate().GoToUrl("file:///" + AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/") + "/html/modals/index.html");
        }

        [Then(@"I can open and close the modals")]
        public void ThenICanOpenAndCloseTheModals()
        {
            var modalPage = new TestModalPage();
            Assert.IsTrue(d.Exists(modalPage.B1));
            Assert.IsTrue(d.Exists(modalPage.B2));
            Assert.IsTrue(d.Exists(modalPage.B3));
            for (int i = 0; i < 3; i++)
            {
                d.Click(modalPage.B1);
                d.Click(modalPage.Close);
                d.Click(modalPage.B2);
                d.Click(modalPage.Close);
                d.Click(modalPage.B3);
                d.Click(modalPage.Close);
            }
        }
    }
}
