using OpenQA.Selenium;
using System;

namespace SpecFlow.Extensions.Web.CustomBys
{
    public class ByClassName : BaseCustomBy
    {
        private static Func<string, By> activator = By.ClassName;

        public ByClassName(string usingString)
            : base(activator, usingString)
        {
        }

        public class Text : BaseText
        {
            public Text(string usingString)
                : base(activator, usingString)
            {
            }
        }

        public class TextPartial : BaseTextPartial
        {
            public TextPartial(string usingString)
                : base(activator, usingString)
            {
            }
        }

        public class Attribute : BaseAttribute
        {
            public Attribute(string usingString)
                : base(activator, usingString)
            {
            }
        }
    }
}