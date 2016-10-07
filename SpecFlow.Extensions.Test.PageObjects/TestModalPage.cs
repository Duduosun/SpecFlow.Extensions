using OpenQA.Selenium;
using SpecFlow.Extensions.Web.ByWrappers;

namespace SpecFlow.Extensions.PageObjects
{
    public class TestModalPage : Page
    {
        public ByEx B1 { get { return new ByEx(By.Id("b1"), Input.Click); } }

        public ByEx B2 { get { return new ByEx(By.Id("b2"), Input.Click); } }

        public ByEx B3 { get { return new ByEx(By.Id("b3"), Input.Click); } }

        public ByEx Close { get { return new ByEx(By.ClassName("close"), Input.Click); } }
    }
}