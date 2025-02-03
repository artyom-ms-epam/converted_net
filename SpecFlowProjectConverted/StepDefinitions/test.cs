using FluentAssertions;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
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

        [When(@"I type the name 'Peter' in the name input")]
        public async Task WhenITypeTheNamePeterInTheNameInput()
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.FillAsync("Peter");
        }

        [Then(@"the name input should contain 'Peter'")]
        public async Task ThenTheNameInputShouldContainPeter()
        {
            var nameInput = _page.Locator("#developer-name");
            var value = await nameInput.InputValueAsync();
            value.Should().Be("Peter");
        }

        [When(@"I type the name 'Parker' in the name input replacing the previous name")]
        public async Task WhenITypeTheNameParkerInTheNameInputReplacingThePreviousName()
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.FillAsync("Parker");
        }

        [When(@"I correct the name to 'Parker' by setting the caret position")]
        public async Task WhenICorrectTheNameToParkerBySettingTheCaretPosition()
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.PressAsync("ArrowLeft");
            await nameInput.PressAsync("r");
        }

        [Then(@"the name input should contain 'Parker'")]
        public async Task ThenTheNameInputShouldContainParker()
        {
            var nameInput = _page.Locator("#developer-name");
            var value = await nameInput.InputValueAsync();
            value.Should().Be("Parker");
        }

        // Add the rest of the tests following the same pattern
    }
}
