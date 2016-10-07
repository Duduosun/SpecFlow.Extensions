using SpecFlow.Extensions.Framework.ExtensionMethods;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlow.Extensions.Framework.Hooks
{
    [Binding]
    public sealed class SetTestHash
    {
        [BeforeFeature]
        public static void BeforeFeature()
        {
            StringRandomize.FeatureHash = GetUpperCaseOrFirstCharacterOfEachWord(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            StringRandomize.ScenarioHash = GetUpperCaseOrFirstCharacterOfEachWord(ScenarioContext.Current.ScenarioInfo.Title);
        }

        private static string GetUpperCaseOrFirstCharacterOfEachWord(string sentence)
        {
            return string.Join(string.Empty, sentence.Where((character, index) => char.IsUpper(character) || (character != ' ' && (index == 0 || sentence[index - 1] == ' '))));
        }
    }
}