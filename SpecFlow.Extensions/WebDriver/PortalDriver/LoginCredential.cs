using Newtonsoft.Json;

namespace SpecFlow.Extensions.WebDriver.PortalDriver
{
    [JsonObject]
    public class LoginCredential
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}