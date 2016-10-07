using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlow.Extensions.Framework.ExtensionMethods
{
    public static class SpecFlowTableExtension
    {
        public static bool IsNullOrBlank(this Table table)
        {
            if (table == null)
                return true;

            if (table.Rows.Count == 0)
                return true;

            return table.Rows.All(row => row.Values.All(value => string.IsNullOrWhiteSpace(value)));
        }
    }
}