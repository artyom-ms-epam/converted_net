using FluentAssertions;
using TechTalk.SpecFlow;
using Microsoft.Playwright;

namespace SpecFlowProjectConverted.StepDefinitions
{
    [Binding]
    public class TestSteps
    {
        private readonly IPage _page;

        public TestSteps(IPage page)
        {
            _page = page;
        }

        [Given(@"I navigate to the example page")]
        public async Task GivenINavigateToTheExamplePage()
        {
            await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
        }

        [Then(@"I type the name 'Peter' into the name input")]
        public async Task ThenITypeTheNamePeterIntoTheNameInput()
        {
            var nameInput = await _page.QuerySelectorAsync("#developer-name");
            await nameInput.TypeAsync("Peter");
        }

        [Then(@"I replace it with 'Parker'")]
        public async Task ThenIReplaceItWithParker()
        {
            var nameInput = await _page.QuerySelectorAsync("#developer-name");
            await nameInput.FillAsync("Parker");
        }

        [Then(@"I correct the name to 'Parker'")]
        public async Task ThenICorrectTheNameToParker()
        {
            var nameInput = await _page.QuerySelectorAsync("#developer-name");
            await nameInput.PressAsync("ArrowLeft");
            await nameInput.TypeAsync("r");
            var value = await nameInput.GetAttributeAsync("value");
            value.Should().Be("Parker");
        }

        // Additional steps converted similarly
    }
}