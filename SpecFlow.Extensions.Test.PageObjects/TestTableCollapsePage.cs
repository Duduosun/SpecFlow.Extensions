using OpenQA.Selenium;
using SpecFlow.Extensions.Web.ByWrappers;

namespace PageObjects
{
    public class TestTableCollapsePage
    {
        public ByEx StocksHeader { get { return new ByText(By.TagName("div"), "Stocks"); } }
        public ByEx StocksTable { get { return new ByEx(By.CssSelector("div[id*='stocks-']")); } }
        public ByEx StocksTableRows { get { return new ByEx(By.CssSelector("table[id*='gridview-']")); } }

        public ByEx LeftNavCollapse { get { return new ByEx(By.Id("tool-1032-toolEl")); } }
        public ByEx LeftNavExpand { get { return new ByEx(By.Id("tool-1062-toolEl")); } }
    }
}
