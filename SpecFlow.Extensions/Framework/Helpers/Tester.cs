using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace SpecFlow.Extensions.Framework.Helpers
{
    public static class Tester
    {
        public static string Email
        {
            get
            {
                var contents = File.ReadAllText("testdata\\testers.json");
                var testers = JsonConvert.DeserializeObject<ReadOnlyDictionary<string, ReadOnlyDictionary<string, string>>>(contents);
                var machineName = System.Environment.MachineName.ToUpper();
                return testers[testers.ContainsKey(machineName) ? machineName : "DEFAULT"]["Email"];
            }
        }

        public static string TestDataPath(string testDataName)
        {
            return string.Format("{0}{1}{2}", Environment.CurrentDirectory, @"\testdata\", testDataName);
        }
    }
}