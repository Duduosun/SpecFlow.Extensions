namespace SpecFlow.Extensions.WebDriver.PortalDriver
{
    public interface IPortal
    {
        bool LoggedIn();

        void Login();

        void Logout();

        void NavigateHome();

        void NavigateTo(string pageName, string pageExtension = "");
    }
}