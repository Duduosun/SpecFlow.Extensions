using OpenQA.Selenium;
using SpecFlow.Extensions.Web.ByWrappers;
using SpecFlow.Extensions.Web.ExtensionMethods;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SpecFlow.Extensions.Web.CustomBys
{
    public abstract class BaseCustomBy : By
    {
        protected readonly Func<string, By> byActivator;

        protected BaseCustomBy(Func<string, By> activator)
        {
            byActivator = activator;
        }

        public BaseCustomBy(Func<string, By> activator, string usingString)
            : this(activator)
        {
            SetFindMethods(new ByEx(byActivator(usingString)));
        }

        protected string[] TokenizeUsing(string usingString, int tokenCount)
        {
            return usingString.Split(new[] { ' ' }, tokenCount);
        }

        protected void SetFindMethods(ByEx byEx)
        {
            FindElementMethod = (ISearchContext context) =>
            {
                return context.FindElement(byEx);
            };

            FindElementsMethod = (ISearchContext context) =>
            {
                return (ReadOnlyCollection<IWebElement>)context.FindElements(byEx);
            };
        }
    }

    public abstract class BaseText : BaseCustomBy
    {
        public BaseText(Func<string, By> activator, string usingString)
            : base(activator)
        {
            var tokens = TokenizeUsing(usingString, 2);
            SetFindMethods(new ByText(byActivator(tokens[0]), tokens[1]));
        }
    }

    public abstract class BaseTextPartial : BaseCustomBy
    {
        public BaseTextPartial(Func<string, By> activator, string usingString)
            : base(activator)
        {
            var tokens = TokenizeUsing(usingString, 2);
            SetFindMethods(new ByText(byActivator(tokens[0]), tokens[1], (string search, string find) => (search.Contains(find))));
        }
    }

    public abstract class BaseAttribute : BaseCustomBy
    {
        public BaseAttribute(Func<string, By> activator, string usingString)
            : base(activator)
        {
            var tokens = TokenizeUsing(usingString, 3);
            SetFindMethods(new ByAttribute(byActivator(tokens[0]), tokens[1], tokens[2]));
        }
    }

    public abstract class BaseTrim : BaseCustomBy
    {
        private readonly string[] filterList = new[] {
            "Button",
            "DropDown", "DropDownList", "DDL",
            "Table"
        };

        public BaseTrim(Func<string, By> activator, string usingString)
            : base(activator)
        {
            SetFindMethods(new ByEx(byActivator(TrimWords(usingString))));
        }

        private string TrimWords(string str)
        {
            var wordToRemove = filterList.FirstOrDefault(word => str.EndsWith(word));
            if (wordToRemove == null)
                return str;
            return str.Substring(0, str.Length - wordToRemove.Length);
        }
    }
}