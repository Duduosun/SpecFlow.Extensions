using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects;
using SpecFlow.Extensions.Web.ExtensionMethods;
using SpecFlow.Extensions.WebDriver;
using SpecFlow.Extensions.WebDriver.PortalDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlow.Extensions.Test.Tests
{
    [Binding]
    public sealed class TestTableCollapseSteps
    {
        private IPortalDriver d;
        private TestTableCollapsePage _tablePage;
        private TestTableCollapsePage TablePage { get { return _tablePage ?? new TestTableCollapsePage(); } }

        private int beforeCount, afterCount;

        public TestTableCollapseSteps(WebContext webContext)
        {
            d = webContext.PortalDriver;
        }

        [Given(@"I go to the table collapse page")]
        public void GivenIGoToTheTableCollapsePage()
        {
            ((IWebDriver)d).Navigate().GoToUrl("http://dev.sencha.com/extjs/5.1.0/examples/portal/index.html");
        }

        [When(@"I collapse the table")]
        public void WhenICollapseTheTable()
        {
            var rows = d.Find(TablePage.StocksTable).FindElements(TablePage.StocksTableRows);
            beforeCount = rows.Count();
            d.Click(TablePage.StocksHeader);
        }

        [When(@"I repeatly collapse the left nav menu")]
        public void WhenIRepeatedlyCollapseTheLeftNavMenu()
        {
            for (int i = 0; i < 3; i++)
            {
                d.Click(TablePage.LeftNavCollapse);
                d.Click(TablePage.LeftNavExpand);
            }
        }

        [Then(@"I do not fail when I select a row")]
        public void ThenIDoNotFailWhenISelectARow()
        {
            var rows = d.Find(TablePage.StocksTable).FindElements(TablePage.StocksTableRows);
            afterCount = rows.Count();
            Assert.IsTrue(beforeCount > 0, "There were no visible rows at start of test");
            Assert.IsTrue(afterCount == 0, string.Format("{0} out of {1} rows were visible after table collapse", afterCount, beforeCount));
        }

    }
}
