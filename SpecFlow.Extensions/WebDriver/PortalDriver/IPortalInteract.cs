using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlow.Extensions.Web;
using SpecFlow.Extensions.Web.ByWrappers;
using System.Collections.Generic;

namespace SpecFlow.Extensions.WebDriver.PortalDriver
{
    public interface IPortalInteract
    {
        void WaitForPageLoad();

        void WaitForJQueryLoad();

        bool ClickChangesUrl(ByEx byEx);

        /*
         * These are convenience methods so that users of IPortalDriver do not have to access the Driver.Find methods
         *
         * Find calls out to Driver.Find
         *      which in turn calls the derivative Find methods of ISearchContext and ISearchContextExtension
         *
         * The other methods should call out to their respective Driver.Find.<method> Methods
         */

        IWebElement Find(ByEx byEx);

        IEnumerable<IWebElement> FindAll(ByEx byEx);

        SelectElement FindSelect(ByEx byEx);

        TableElement FindTable(ByEx byEx);

        void Clear(ByEx byEx);

        void Click(ByEx byEx);

        void ClickInvisible(ByEx byEx);

        bool Displayed(ByEx byEx);

        bool Exists(ByEx byEx);

        void Select(ByEx byEx);

        void Select(ByEx byEx, string text);

        void SendKeys(ByEx byEx, string text);

        void Set(ByEx byEx, string text);

        void Type(ByEx byEx, string text);
    }
}