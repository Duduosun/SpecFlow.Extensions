using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Protractor;
using SpecFlow.Extensions.WebDriver.PortalDriver;
using System.Collections.Generic;
using System.Linq;

namespace SpecFlow.Extensions.WebDriver
{
    /*
     * TODO I am an example only, I am in no way complete or correct
     */

    public class ExampleDriverFactory : IDriverFactory
    {
        public enum DriverTypes
        {
            IE, Chrome
        }

        private static List<IPortalDriver> _driverBag = new List<IPortalDriver>();

        public IPortalDriver GetDriver()
        {
            if (_driverBag.Count == 0)
            {
                var driver = new ExampleWebDriver(GetDriver(DriverTypes.Chrome));
                _driverBag.Add(driver);
                return driver;
            }
            else
            {
                // TODO add logic to handle multiple drivers at the same time
                return _driverBag.First();
            }
        }

        // TODO randomize the driver every few hours to keep testers on their toes :)
        private IWebDriver GetDriverRandom()
        {
            return GetDriver(DriverTypes.Chrome);
        }

        private IWebDriver GetDriver(DriverTypes type)
        {
            IWebDriver driver = null;
            switch (type)
            {
                case DriverTypes.IE:
                    driver = new InternetExplorerDriver(
                        new InternetExplorerOptions
                        {
                            UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Default,
                            EnableNativeEvents = true,
                            //ForceCreateProcessApi = true,
                            //BrowserCommandLineArguments = "-private",
                            EnsureCleanSession = true
                        });
                    driver = new NgWebDriver(driver);
                    break;

                case DriverTypes.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--disable-plugins");
                    driver = new ChromeDriver(options);
                    driver = new NgWebDriver(driver);
                    break;
            }
            ((NgWebDriver)driver).IgnoreSynchronization = true;
            return driver;
        }

        public void SendBrowsersHome()
        {
            _driverBag.ForEach(driver => driver.NavigateHome());
        }

        public void LogoutBrowsers()
        {
            _driverBag.ForEach(driver => driver.Logout());
        }

        public void CloseBrowsers()
        {
            // local user could have closed the browser or killed the driver process
            try
            {
                _driverBag.ForEach(driver => driver.WrappedDriver.Close());
            }
            catch
            {
            }

            // local user could have closed the browser or killed the driver process
            try
            {
                _driverBag.ForEach(driver => driver.WrappedDriver.Quit());
            }
            catch
            {
            }

            _driverBag.Clear();
        }
    }
}