namespace SpecFlow.Extensions.WebDriver.PortalDriver
{
    public interface IPortalData
    {
        LoginCredential LoginCredential { get; }

        string Email { get; }

        string TesterHash { get; }

        string TestDataPath(string testDataName);

        string TestImageAsHexadecimalString(string imageFileName);
    }
}