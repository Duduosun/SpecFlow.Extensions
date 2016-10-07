using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecFlow.Extensions.Web.ByWrappers
{
    public class ByAttribute : ByEx
    {
        public Dictionary<string, string> Attributes { get; private set; }
        public Func<string, string, bool> ComparisonMethod;

        public ByAttribute(By by, string attributeName, string attributeValue, Input input = Input.Type, bool visibleOnly = true)
            : this(by, attributeName, attributeValue, string.Equals, input, visibleOnly)
        {
        }

        public ByAttribute(By by, string attributeName, string attributeValue, Func<string, string, bool> attrComparisonMethod, Input input = Input.Type, bool visibleOnly = true)
            : base(by, input, visibleOnly)
        {
            Attributes = new Dictionary<string, string>();
            Attributes.Add(attributeName, attributeValue);
            ComparisonMethod = attrComparisonMethod;
        }

        public ByAttribute(By by, Dictionary<string, string> attr, Input input = Input.Type, bool visibleOnly = true)
            : this(by, attr, string.Equals, input, visibleOnly)
        {
        }

        public ByAttribute(By by, Dictionary<string, string> attr, Func<string, string, bool> attrComparisonMethod, Input input = Input.Type, bool visibleOnly = true)
            : base(by, input, visibleOnly)
        {
            Attributes = attr ?? new Dictionary<string, string>();
            ComparisonMethod = attrComparisonMethod;
        }

        public override IEnumerable<IWebElement> FilterElements(IEnumerable<IWebElement> elements)
        {
            return base.FilterElements(elements).Where(element => Attributes.All(attribute => ComparisonMethod(element.GetAttribute(attribute.Key), attribute.Value)));
        }
    }
}