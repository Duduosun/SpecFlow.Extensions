﻿using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using SpecFlow.Extensions.Web;
using SpecFlow.Extensions.Web.ByWrappers;
using SpecFlow.Extensions.Web.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SpecFlow.Extensions.WebDriver.PortalDriver
{
    public abstract class PortalWebDriver : WrapWebDriver, IPortalInteract, IWebDriver, IWrapsDriver
    {
        private readonly int _maxFindAttempts;
        private readonly int _maxTimeoutMilliseconds;

        public PortalWebDriver(IWebDriver driver, int maxFindAttempts = 3, int maxTimeoutMilliseconds = 2000)
            : base(driver)
        {
            _maxFindAttempts = maxFindAttempts;
            _maxTimeoutMilliseconds = maxTimeoutMilliseconds;
        }

        public void WaitForPageLoad()
        {
            WrappedDriver.WaitForPageLoad();
        }

        public bool ClickChangesUrl(ByEx byEx)
        {
            string oldUrl = WrappedDriver.Url;
            Click(byEx);
            WrappedDriver.WaitForUrlToChange(oldUrl, _maxTimeoutMilliseconds);
            return oldUrl != WrappedDriver.Url;
        }

        public IWebElement Find(ByEx byEx)
        {
            return WrappedDriver.FindElement(byEx);
        }

        public IEnumerable<IWebElement> FindAll(ByEx byEx)
        {
            return WrappedDriver.FindElements(byEx);
        }

        public SelectElement FindSelect(ByEx byEx)
        {
            return WrappedDriver.FindSelect(byEx);
        }

        public SelectElement FindSelect(IWebElement element)
        {
            return new SelectElement(element);
        }

        public TableElement FindTable(ByEx byEx)
        {
            return WrappedDriver.FindTable(byEx);
        }

        public TableElement FindTable(IWebElement element)
        {
            return new TableElement(element);
        }

        public void Clear(ByEx byEx)
        {
            TryAgain(() =>
            {
                Find(byEx).Clear();
                return true;
            });
        }

        public void Click(ByEx byEx)
        {
            TryAgain(() =>
            {
                Find(byEx).Click();
                return true;
            });
            WaitForPageLoad();
        }

        public void ClickInvisible(ByEx byEx)
        {
            TryAgain(() =>
            {
                ((IJavaScriptExecutor)WrappedDriver).ExecuteScript("arguments[0].Click()", Find(byEx));
                return true;
            });
        }

        public bool Displayed(ByEx byEx)
        {
            return TryAgain(() =>
            {
                return Find(byEx).Displayed;
            });
        }

        public bool Exists(ByEx byEx)
        {
            return WrappedDriver.HasChild(byEx);
        }

        public void Select(ByEx byEx)
        {
            TryAgain(() =>
            {
                Find(byEx).Click();
                WaitForPageLoad();
                return Find(byEx).Selected;
            });
        }

        public void SendKeys(ByEx byEx, string text)
        {
            TryAgain(() =>
            {
                Find(byEx).SendKeys(text);
                return true;
            });
        }

        public void Type(ByEx byEx, string text)
        {
            TryAgain(() =>
            {
                var cachedElement = Find(byEx);
                cachedElement.Click();
                cachedElement.Clear();
                cachedElement.SendKeys(text);
                return true;
            });
        }

        public void Set(ByEx byEx, string text)
        {
            switch (byEx.Input)
            {
                case Input.Click:
                    Click(byEx);
                    break;

                case Input.Select:
                    FindSelect(byEx).SelectByText(text);
                    break;

                case Input.SendKeys:
                case Input.Upload:
                    SendKeys(byEx, text);
                    break;

                case Input.Type:
                    Type(byEx, text);
                    break;
            }
        }

        private bool TryAgain(Func<bool> func)
        {
            int tryCount = 0;
            bool success = false;
            Exception lastException = null;
            while (tryCount < _maxFindAttempts && !success)
            {
                try
                {
                    success = func();
                }
                catch (Exception e)
                {
                    lastException = e;
                    success = false;
                }
                tryCount++;
                if (!success)
                {
                    Thread.Sleep(1000);
                }
            }

            if (!success && lastException != null)
            {
                throw lastException;
            }

            return success;
        }
    }
}