using OpenQA.Selenium;

namespace SpecFlow.Extensions.Web.ByWrappers
{
    public class ByColumns : ByEx
    {
        public string[] Columns = null;

        public ByColumns(By by, string[] columnHeaders, Input input = Input.Type, bool visibleOnly = true)
            : base(by, input, visibleOnly)
        {
            Columns = columnHeaders;
        }
    }
}