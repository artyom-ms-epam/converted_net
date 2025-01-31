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

        [Given(@"I navigate to the TestCafe example page")]
        public async Task GivenINavigateToTheTestCafeExamplePage()
        {
            await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
        }

        [When(@"I type 'Peter' in the name input field")]
        public async Task WhenITypePeterInTheNameInputField()
        {
            await _page.FillAsync("#developer-name", "Peter");
        }

        [When(@"I replace the name with 'Parker'")]
        public async Task WhenIReplaceTheNameWithParker()
        {
            await _page.FillAsync("#developer-name", "Parker");
        }

        [Then(@"the name input field should contain 'Parker'")]
        public async Task ThenTheNameInputFieldShouldContainParker()
        {
            var value = await _page.InputValueAsync("#developer-name");
            value.Should().Be("Parker");
        }

        [When(@"I type 'Peter Parker' in the name input field")]
        public async Task WhenITypePeterParkerInTheNameInputField()
        {
            await _page.FillAsync("#developer-name", "Peter Parker");
        }

        [When(@"I move the caret position to 5 and press backspace")]
        public async Task WhenIMoveTheCaretPositionTo5AndPressBackspace()
        {
            await _page.ClickAsync("#developer-name", new ClickOptions { Position = new Position { X = 5, Y = 0 } });
            await _page.PressAsync("#developer-name", "Backspace");
        }

        [Then(@"the name input field should contain 'Pete Parker'")]
        public async Task ThenTheNameInputFieldShouldContainPeteParker()
        {
            var value = await _page.InputValueAsync("#developer-name");
            value.Should().Be("Pete Parker");
        }

        // Additional steps for other test cases can be added here following the same pattern
    }
}