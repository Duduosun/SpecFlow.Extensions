using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlow.Extensions.PageObjects;
using SpecFlow.Extensions.WebDriver;
using SpecFlow.Extensions.WebDriver.PortalDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlow.Extensions.Test.Tests
{
    [Binding]
    public class TestSlowGridSteps
    {
        private IPortalDriver d;
        private TestSlowGridPage _gridPage;
        private TestSlowGridPage GridPage { get { return _gridPage ?? new TestSlowGridPage(); } }

        public TestSlowGridSteps(WebContext webContext)
        {
            d = webContext.PortalDriver;
        }

        [Given(@"I go to the test slow grid search page")]
        public void GivenIGoToTheTestSlowGridSearchPage()
        {
            ((IWebDriver)d).Navigate().GoToUrl("http://w2ui.com/web/blog/7/JavaScript-Grid-with-One-Million-Records");
        }
        
        [Given(@"I generate (.*) million records")]
        public void GivenIGenerateMillionRecords(int p0)
        {
            d.Click(GridPage.MILRecordsButton);
        }

        private string _name;
        [When(@"I search for '(.*)'")]
        public void WhenISearchFor(string name)
        {
            _name = name;
            d.Type(GridPage.Search, _name);
            d.SendKeys(GridPage.Search, Keys.Return);
            Thread.Sleep(5000);
        }
        
        [Then(@"there are (.*)")]
        public void ThenThereAre(int count)
        {
            Assert.AreEqual(count, d.FindAll(GridPage.GetRecordsByName(_name)).Count());
        }
    }
}
