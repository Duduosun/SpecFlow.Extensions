using System;
using System.Collections.Generic;
using SpecFlow.Extensions.Framework.ExtensionMethods;
using SpecFlow.Extensions.Framework.Helpers;
using TechTalk.SpecFlow;

namespace SpecFlow.Extensions.PageObjects
{
    public class Macro
    {
        public const string RandomMacro = "!Random";
        public const string RandomShortMacro = "!RandomShort";
        public const string RandomHashMacro = "!Hash";
        public const string DataMacro = "!Data";
        public const string EmailMacro = "!Email";
        public const string PhoneMacro = "!Phone";
        public const string SkipMacro = "!Skip";

        public static Dictionary<string, Func<string, string>> MacroMethods = new Dictionary<string, Func<string, string>>() {
            {RandomMacro, (string s) => (s.Randomize())},
            {RandomShortMacro, (string s) => (s.RandomizeNoTimestamp())},
            {RandomHashMacro, (string s) => (s.RandomizeHashOnly())},
            {DataMacro, (string s) => (Tester.TestDataPath(s))},
            {EmailMacro, (string s) => (Tester.Email)},
            {PhoneMacro, (string s) => (StringRandomize.GenerateRandomNumber())},
            {SkipMacro, (string s) => (null) }
        };

        public IList<string> Headers = new List<string>();
        public IList<IDictionary<string, string>> Rows = new List<IDictionary<string, string>>();

        public void Format(Table table, string delimiter = "!")
        {
            var LookupTable = new Dictionary<string, string>();

            // replace with macros
            foreach (var header in table.Header)
            {
                if (header.Contains(delimiter)) // is macro
                {
                    bool skip = false;
                    var substring = header.Substring(header.LastIndexOf(delimiter));
                    if (MacroMethods.ContainsKey(substring))
                    {
                        foreach (var row in table.Rows)
                        {
                            var formattedString = MacroMethods[substring](row[header]);
                            if (formattedString == null)
                            {
                                skip = true;
                            }
                            else
                            {
                                row[header] = formattedString;
                            }
                        }
                    }
                    if (skip) // don't include in Headers
                    {
                        var newHeader = header.Replace(" ", string.Empty);
                        LookupTable.Add(header, newHeader);
                    }
                    else
                    {
                        var newHeader = header.Substring(0, header.Length - substring.Length)
                            .TrimEnd()
                            .Replace(" ", string.Empty);
                        Headers.Add(newHeader);
                        LookupTable.Add(header, newHeader);
                    }
                }
                else // is not macro
                {
                    var newHeader = header.Replace(" ", string.Empty);
                    Headers.Add(newHeader);
                    LookupTable.Add(header, newHeader);
                }
            }

            // build new table using look ups
            foreach (var row in table.Rows)
            {
                var dict = new Dictionary<string, string>();
                foreach (var pair in row)
                {
                    dict.Add(LookupTable[pair.Key], pair.Value);
                }
                Rows.Add(dict);
            }
        }
    }
}
