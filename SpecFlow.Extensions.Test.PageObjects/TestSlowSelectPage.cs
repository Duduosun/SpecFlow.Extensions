using OpenQA.Selenium;
using SpecFlow.Extensions.Web.ByWrappers;

namespace SpecFlow.Extensions.PageObjects
{
    public class TestSlowSelectPage : Page
    {
        public ByEx Select { get { return new ByEx(By.TagName("select")); } }
        public ByEx SelectNgOption { get { return new ByEx(By.TagName("select")); } }
    }
}