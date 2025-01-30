using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using Microsoft.Playwright;

namespace SpecFlowProjectConverted.StepDefinitions
{
    [Binding]
    public class TestStepDefinitions
    {
        private readonly IPage _page;

        public TestStepDefinitions(IPage page)
        {
            _page = page;
        }

        [Given(@"I navigate to the example page")]
        public async Task GivenINavigateToTheExamplePage()
        {
            await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
        }

        [When(@"I type 'Peter' in the name input")]
        public async Task WhenITypePeterInTheNameInput()
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.TypeAsync("Peter");
        }

        [When(@"I replace it with 'Parker'")]
        public async Task WhenIReplaceItWithParker()
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.FillAsync("Parker");
        }

        [Then(@"the name input should contain 'Parker'")]
        public async Task ThenTheNameInputShouldContainParker()
        {
            var nameInput = _page.Locator("#developer-name");
            var value = await nameInput.InputValueAsync();
            value.Should().Be("Parker");
        }

        // Additional step definitions for other tests can be added here
    }
}
