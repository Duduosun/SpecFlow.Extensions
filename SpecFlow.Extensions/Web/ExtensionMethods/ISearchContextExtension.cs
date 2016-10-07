using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlow.Extensions.Web.ByWrappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SpecFlow.Extensions.Web.ExtensionMethods
{
    public static class ISearchContextExtension
    {
        private const int MAX_RETRIES = 3;
        private const int MAX_DELAY_MS = 1000;

        public static bool HasChild(this ISearchContext iFind, ByEx byEx)
        {
            return FindAll(iFind, byEx, 1, 0).Any(e => ByEx.SafeDisplayed(e) == true);
        }

        public static IWebElement FindElement(this ISearchContext iFind, ByEx byEx)
        {
            IWebElement e = null;

            int tryCount = 0;
            while ((tryCount < MAX_RETRIES) && e == null)
            {
                e = byEx.FilterElements(iFind.FindElements(byEx.By)).FirstOrDefault();

                tryCount++;
                if (e == null)
                {
                    Thread.Sleep(MAX_DELAY_MS);
                }
            }

            if (e == null) // fail normally with built-in FindElement
            {
                if (byEx.GetType() == typeof(ByEx))
                {
                    e = iFind.FindElement(byEx.By);
                }
                else
                {
                    // default FindElement(By) won't find it
                    throw new NoSuchElementException();
                }
            }

            return e;
        }

        public static IEnumerable<IWebElement> FindElements(this ISearchContext iFind, ByEx byEx)
        {
            return FindAll(iFind, byEx, MAX_RETRIES, MAX_DELAY_MS);
        }

        private static IEnumerable<IWebElement> FindAll(ISearchContext iFind, ByEx byEx, int retries, int milliseconds)
        {
            var elements = byEx.FilterElements(iFind.FindElements(byEx.By));
            while ((retries > 0) && elements.Count() == 0)
            {
                Thread.Sleep(milliseconds);
                elements = byEx.FilterElements(iFind.FindElements(byEx.By));
                retries--;
            }
            return elements;
        }

        public static IWebElement FindElementOrNull(this ISearchContext iFind, ByEx byEx)
        {
            return FindElements(iFind, byEx).FirstOrDefault();
        }

        public static SelectElement FindSelect(this ISearchContext iFind, ByEx byEx)
        {
            int tryCount = 0;
            var e = new SelectElement(iFind.FindElement(byEx));

            while ((tryCount < MAX_RETRIES) && e == null)
            {
                Thread.Sleep(MAX_DELAY_MS);
                e = new SelectElement(iFind.FindElement(byEx));
                tryCount++;
            }
            return e;
        }

        public static TableElement FindTable(this ISearchContext iFind, ByEx byEx)
        {
            return new TableElement(iFind.FindElement(byEx));
        }
    }
}