using OpenQA.Selenium;
using SpecFlow.Extensions.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlow.Extensions.WebDriver.Hooks
{
    [Binding]
    public class WebDriverHook
    {
        private static IDriverFactory factory = new ExampleDriverFactory(); // TODO add your own driver factory
        private IWebDriver _driver;
        private bool _closeBrowsersAfterScenario = true;
        private bool _logoutAfterScenario = true;

        public WebDriverHook(WebContext webContext)
        {
			PageFactory.DriverFactory = factory;
            webContext.PortalDriver = factory.GetDriver();
            _driver = (IWebDriver)webContext.PortalDriver;
        }

        private void SetDefaultBrowserSize()
        {
            _driver.Manage().Window.Size = new System.Drawing.Size(1024, 768);
        }

        [BeforeScenario("web")]
        public void BeforeScenarioWeb()
        {
            SetDefaultBrowserSize();
        }

        [BeforeScenario("web_max")]
        public void BeforeScenarioWebMax()
        {
            _driver.Manage().Window.Maximize();
        }

        [BeforeScenario("web_persist")] // enable reuse of browsers
        public void BeforeScenarioWebPersist()
        {
            _closeBrowsersAfterScenario = false;
        }

        [BeforeScenario("web_persistLogin")] // enable reuse of logged in session
        public void BeforeScenarioWebPersistLogin()
        {
            _closeBrowsersAfterScenario = false;
            _logoutAfterScenario = false;
        }

        [BeforeScenario("web_small")]
        public void BeforeScenarioWebSmall()
        {
            _driver.Manage().Window.Size = new System.Drawing.Size(500, 500);
        }

        // TODO list all scenario web hooks here
        [AfterScenario("web", "web_max", "web_persist", "web_persistLogin", "web_small")]
        public void AfterScenarioWeb()
        {
            if (_logoutAfterScenario)
            {
                factory.LogoutBrowsers();
            }
            else
            {
                factory.SendBrowsersHome();
            }
            if (_closeBrowsersAfterScenario)
            {
                factory.CloseBrowsers();
            }
        }

        // TODO list all scenario web hooks that don't close browsers after scenarios here
        [AfterFeature("web_persist", "web_persistLogin")]
        public static void AfterFeatureWeb()
        {
            factory.LogoutBrowsers();
            factory.CloseBrowsers();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            factory.CloseBrowsers();
        }
    }
}