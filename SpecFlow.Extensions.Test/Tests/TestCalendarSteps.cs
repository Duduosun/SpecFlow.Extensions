using OpenQA.Selenium;
using PageObjects;
using SpecFlow.Extensions.WebDriver;
using SpecFlow.Extensions.WebDriver.PortalDriver;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlow.Extensions.Tests
{
    [Binding]
    public class TestCalendarSteps
    {
        private IPortalDriver d;
        private TestCalendarPage _calPage;
        private TestCalendarPage CalPage { get { return _calPage ?? new TestCalendarPage(); } }
        private DateTime date = DateTime.Parse("10/15/2018");

        public TestCalendarSteps(WebContext webContext)
        {
            d = webContext.PortalDriver;
        }

        [Given(@"I go to the test calendar page")]
        public void GivenIGoToTheTestCalendarPage()
        {
            ((IWebDriver)d).Navigate().GoToUrl("http://dev.sencha.com/extjs/5.1.0/examples/calendar/index.html");
        }
        
        [When(@"I select the mini calendar month drop down")]
        public void WhenISelectTheMiniCalendarMonthDropDown()
        {
            d.Click(CalPage.MiniCalendarMonthDropDown);
        }
        
        [When(@"I select a date in the mini calendar")]
        public void WhenISelectADateInTheMiniCalendar()
        {
            CalPage.MiniCalendarSelectDate(d, date);
        }
        
        [When(@"I add an event")]
        public void WhenIAddAnEvent()
        {
            CalPage.MiniCalendarSelectDay(d, date);
            d.Click(CalPage.CalendarDate(date));
            d.Type(CalPage.AddEventTitle, string.Format("this is a test {0}", DateTime.Now.ToString()));
            d.Click(CalPage.AddEventSaveButton);
        }
        
        [When(@"I add a detailed event")]
        public void WhenIAddADetailedEvent()
        {
            CalPage.MiniCalendarSelectDay(d, date);
            d.Click(CalPage.CalendarDate(date));
            d.Click(CalPage.EditDetails);
            d.Type(CalPage.AddEventTitle, string.Format("this is a test {0}", DateTime.Now.ToString()));
            d.Click(CalPage.AddEventSaveButton);
        }

        [When(@"I select theme '(.*)'")]
        public void WhenISelectTheme(string themeName)
        {
            d.Type(CalPage.ThemeDropDown, themeName);
            d.SendKeys(CalPage.ThemeDropDown, Keys.Return);
            d.Click(CalPage.CalendarDay);
            d.Click(CalPage.AddEventCancelButton);
        }
    }
}
