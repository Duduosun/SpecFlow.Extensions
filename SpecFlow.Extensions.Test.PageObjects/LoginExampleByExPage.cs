using OpenQA.Selenium;
using SpecFlow.Extensions.Web.ByWrappers;

namespace SpecFlow.Extensions.PageObjects
{
    public class LoginExampleByExPage : Page
    {
        public ByEx Username { get { return new ByEx(By.Id("Username")); } }

        public ByEx Password { get { return new ByEx(By.Id("Password")); } }

        public ByEx LoginButton { get { return new ByText(By.TagName("input"), "Log In"); } }
    }
}