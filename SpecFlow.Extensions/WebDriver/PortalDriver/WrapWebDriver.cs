using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using SpecFlow.Extensions.Web.ByWrappers;
using SpecFlow.Extensions.Web.ExtensionMethods;
using System.Collections.ObjectModel;

namespace SpecFlow.Extensions.WebDriver.PortalDriver
{
    public abstract class WrapWebDriver : IWebDriver, IWrapsDriver
    {
        private IWebDriver _driver;

        public WrapWebDriver(IWebDriver driver)
        {
            WrappedDriver = driver;
        }

        public IWebDriver WrappedDriver { get { return (_driver is IWrapsDriver) ? ((IWrapsDriver)_driver).WrappedDriver : _driver; } protected set { _driver = value; } }

        /// <summary>
        /// Gets the current window handle, which is an opaque handle to this
        /// window that uniquely identifies it within this driver instance.
        /// </summary>
        public string CurrentWindowHandle { get { return WrappedDriver.CurrentWindowHandle; } }

        /// <summary>
        /// Gets the source of the page last loaded by the browser.
        /// </summary>
        public string PageSource { get { return WrappedDriver.PageSource; } }

        /// <summary>
        /// Gets the title of the current browser window.
        /// </summary>
        public string Title { get { return WrappedDriver.Title; } }

        /// <summary>
        /// Gets or sets the URL the browser is currently displaying.
        /// </summary>
        public string Url { get { return WrappedDriver.Url; } set { WrappedDriver.Url = value; } }

        /// <summary>
        /// Gets the window handles of open browser windows.
        /// </summary>
        public ReadOnlyCollection<string> WindowHandles { get { return WrappedDriver.WindowHandles; } }

        /// <summary>
        /// Close the current window, quitting the browser if it is the last window currently open.
        /// </summary>
        public void Close()
        {
            WrappedDriver.Close();
        }

        /// <summary>
        /// Instructs the driver to change its settings.
        /// </summary>
        /// <returns>
        /// An <see cref="IOptions"/> object allowing the user to change the settings of the driver.
        /// </returns>
        public IOptions Manage()
        {
            return WrappedDriver.Manage();
        }

        /// <summary>
        /// Instructs the driver to navigate the browser to another location.
        /// </summary>
        /// <returns>
        /// An <see cref="INavigation"/> object allowing the user to access
        /// the browser's history and to navigate to a given URL.
        /// </returns>
        public INavigation Navigate()
        {
            return WrappedDriver.Navigate();
        }

        /// <summary>
        /// Quits this driver, closing every associated window.
        /// </summary>
        public void Quit()
        {
            WrappedDriver.Quit();
        }

        /// <summary>
        /// Instructs the driver to send future commands to a different frame or window.
        /// </summary>
        /// <returns>
        /// An <see cref="ITargetLocator"/> object which can be used to select a frame or window.
        /// </returns>
        public ITargetLocator SwitchTo()
        {
            return WrappedDriver.SwitchTo();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            WrappedDriver.Dispose();
        }

        IWebElement ISearchContext.FindElement(By by)
        {
            return WrappedDriver.FindElement(new ByEx(by));
        }

        ReadOnlyCollection<IWebElement> ISearchContext.FindElements(By by)
        {
            return (ReadOnlyCollection<IWebElement>)(WrappedDriver.FindElement(new ByEx(by)));
        }
    }
}