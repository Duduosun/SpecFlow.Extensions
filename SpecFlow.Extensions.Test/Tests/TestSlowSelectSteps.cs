using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlow.Extensions.PageObjects;
using SpecFlow.Extensions.Web.ByWrappers;
using SpecFlow.Extensions.Web.ExtensionMethods;
using SpecFlow.Extensions.WebDriver;
using SpecFlow.Extensions.WebDriver.PortalDriver;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SpecFlow.Extensions.Test
{
    [Binding]
    public class TestSlowSelectSteps
    {
        private DateTime now;
        private TimeSpan time;
        private ByEx selectByEx;
        private IPortalDriver d;
        public TestSlowSelectSteps(WebContext webContext)
        {
            d = webContext.PortalDriver;
        }

        [Given(@"I go to the test select page")]
        public void GivenIGoToTheTestSlowSelectPage()
        {
            ((IWebDriver)d).Navigate().GoToUrl("file:///" + AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/") + "/html/slow_select/select.html");
            var selectPage = new TestSlowSelectPage();
            selectByEx = selectPage.Select;
        }
       
        [Given(@"I go to the test select ngOption page")]
        public void GivenIGoToTheTestSelectNgOptionPage()
        {
            ((IWebDriver)d).Navigate().GoToUrl("file:///" + AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/") + "/html/slow_select/ngOption.html");
            var selectPage = new TestSlowSelectPage();
            selectByEx = selectPage.SelectNgOption;
        }
        
        [When(@"I select '(.*)'")]
        public void WhenISelect(string name)
        {
            now = DateTime.Now;
            d.Select(selectByEx, name);
            Assert.AreEqual(name, d.Find(selectByEx).Value());
            time = DateTime.Now - now;
        }
        
        [Then(@"it took less than a second")]
        public void ThenItTookLessThanASecond()
        {
            Assert.IsTrue(time.TotalSeconds < 1, string.Format("select took {0} seconds", time.TotalSeconds));
        }
    }
}
