using SpecFlow.Extensions.WebDriver.PortalDriver;

namespace SpecFlow.Extensions.WebDriver
{
    public interface IDriverFactory
    {
        IPortalDriver GetDriver();

        void SendBrowsersHome();

        void LogoutBrowsers();

        void CloseBrowsers();
    }
}