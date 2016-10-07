using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlow.Extensions.Framework.Hooks
{
    [Binding]
    public sealed class EmptyScenarioIsInconclusive
    {
        private bool isEmpty = true;

        [BeforeStep]
        public void BeforeStep()
        {
            isEmpty = false;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (isEmpty)
                Assert.Inconclusive("The scenario is empty");
        }
    }
}