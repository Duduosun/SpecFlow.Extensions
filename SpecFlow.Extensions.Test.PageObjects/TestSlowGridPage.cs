using OpenQA.Selenium;
using SpecFlow.Extensions.Web.ByWrappers;

namespace SpecFlow.Extensions.PageObjects
{
    public class TestSlowGridPage : Page
    {
        public ByAttribute MILRecordsButton { get { return new ByAttribute(By.TagName("input"), "value", "1MIL Records"); } }

        public ByEx Search { get { return new ByEx(By.Id("grid_grid_search_all")); } }

        public ByText SearchButton { get { return new ByText(By.ClassName("w2ui-tb-caption"), "Search..."); } }

        public ByText GetRecordsByName(string name)
        {
            return new ByText(By.ClassName("w2ui-marker"), name);
        }
    }
}