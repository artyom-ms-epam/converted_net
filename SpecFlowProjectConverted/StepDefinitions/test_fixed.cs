using FluentAssertions;
using TechTalk.SpecFlow;
using Microsoft.Playwright;

namespace SpecFlowProjectConverted.StepDefinitions
{
    [Binding]
    public class TestSteps
    {
        private readonly IPage _page;
        private readonly ScenarioContext _scenarioContext;

        public TestSteps(IPage page, ScenarioContext scenarioContext)
        {
            _page = page;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I navigate to the example page")]
        public async Task GivenINavigateToTheExamplePage()
        {
            await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
        }

        [When(@"I type '([^']*)' into the name input")]
        public async Task WhenITypeIntoTheNameInput(string name)
        {
            await _page.FillAsync("#developer-name", name);
        }

        [Then(@"the name input should have value '([^']*)'")]
        public async Task ThenTheNameInputShouldHaveValue(string expectedValue)
        {
            var value = await _page.InputValueAsync("#developer-name");
            value.Should().Be(expectedValue);
        }

        // Additional step definitions based on the TestCafe tests
    }
}
