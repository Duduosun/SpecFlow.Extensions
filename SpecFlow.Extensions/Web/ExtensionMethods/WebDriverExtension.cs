using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using SpecFlow.Extensions.Web.ByWrappers;
using System;
using System.Threading;

namespace SpecFlow.Extensions.Web.ExtensionMethods
{
    public static class WebDriverExtension
    {
        private const int MAX_DELAY_MS = 1000;

        public static void WaitForPageLoad(this IWebDriver driver, int seconds = 60)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            var d = (driver is IWrapsDriver) ? ((IWrapsDriver)driver).WrappedDriver : driver;
            wait.Until(w => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void WaitForJQueryLoad(this IWebDriver driver, int seconds = 60)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            var d = (driver is IWrapsDriver) ? ((IWrapsDriver)driver).WrappedDriver : driver;
            wait.Until(w => ((IJavaScriptExecutor)d).ExecuteScript("return jQuery.active").ToString().Equals("0"));
        }

        public static void WaitForUrlToChange(this IWebDriver driver, string oldUrl, int timeMilliseconds = MAX_DELAY_MS)
        {
            while (driver.Url == oldUrl && timeMilliseconds > 0)
            {
                Thread.Sleep(100);
                timeMilliseconds -= 100;
            }
        }

        public static void WaitForElement(this IWebDriver driver, ByEx byEx)
        {
            const int MAX_TIME_MS = 10000;
            int time_current = 0;

            var e = driver.FindElementOrNull(byEx);
            while ((time_current < MAX_TIME_MS) && e == null)
            {
                Thread.Sleep(MAX_DELAY_MS);
                time_current += MAX_DELAY_MS;
                e = driver.FindElementOrNull(byEx);
            }
            int time_delta = Math.Max(0, MAX_TIME_MS - time_current);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time_delta));
            wait.Until<IWebElement>((d) =>
                {
                    if (e.Displayed && e.Enabled)
                    {
                        return e;
                    }
                    else
                    {
                        return null;
                    }
                }
            );
        }
    }
}