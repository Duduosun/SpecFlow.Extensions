using OpenQA.Selenium.Internal;

namespace SpecFlow.Extensions.WebDriver.PortalDriver
{
    /*
     * IPortalDriver is a wrapper of the Selenium WebDriver class
     * it also contains additional functionality beyond the generic driver (login and logout)
     * and convenience methods that make it easier to work with WebDrivers
     *
     * There should be a different PortalDrivers for each supported webportal
     * each PortalDrivers should know how to log in and log out of its respective webportal
     * they should also understand how to navigate to specifically named pages
     *
     * A base class could potential contain the shared code (WaitForPageLog and the convenience methods)
     */

    public interface IPortalDriver : IPortal, IPortalInteract, IWrapsDriver // TODO add IPortalData
    {
    }
}