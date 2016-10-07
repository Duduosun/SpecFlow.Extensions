using OpenQA.Selenium;
using Protractor;
using SpecFlow.Extensions.PageObjects;
using SpecFlow.Extensions.WebDriver.PortalDriver;

namespace SpecFlow.Extensions.WebDriver
{
    public class ExampleWebDriver : PortalWebDriver, IPortalDriver, IWebDriver, ISearchContext
    {
        public ExampleWebDriver(IWebDriver driver)
            : base(driver)
        {
            // initialize your web driver for a specific web portal
            // configure timeouts from config or environment
            // get credentials and urls for example
        }

        public bool LoggedIn()
        {
            // return the logged in state
            return false;
        }

        public void Login()
        {
            // use some credential to log in
            // set LoggedIn = true if successful
        }

        public void Logout()
        {
            // log out of your web portal by clicking a link or button, etc.
        }

        public void NavigateHome()
        {
            // navigate to the home url of your web portal
        }

        public void NavigateTo(string pageName, string pageExtension = "")
        {
            string url = GetUrl(pageName) + pageExtension;
            if (WrappedDriver is NgWebDriver && (WrappedDriver.Url == "data:," || WrappedDriver.Url == "about:blank"))
            {
                // java script error if there is no page
                ((NgWebDriver)WrappedDriver).WrappedDriver.Navigate().GoToUrl(url);
            }
            else
            {
                Navigate().GoToUrl(url);
            }
        }

        private string GetUrl(string pageName)
        {
            return GetBaseUrl("LOCAL") + PageFactory.GetPage(pageName).Uri;
        }

        private string GetBaseUrl(string environmentName)
        {
            return string.Empty; // TODO add your base url
        }
    }
}