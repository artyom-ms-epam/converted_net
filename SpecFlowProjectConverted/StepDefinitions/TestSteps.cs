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

        [When(@"I click the '([^']*)' label")]
        public async Task WhenIClickTheLabel(string labelText)
        {
            await _page.ClickAsync($"label:has-text('{labelText}')");
        }

        [Then(@"the '([^']*)' checkbox should be checked")]
        public async Task ThenTheCheckboxShouldBeChecked(string labelText)
        {
            var isChecked = await _page.IsCheckedAsync($"label:has-text('{labelText}') + input");
            isChecked.Should().BeTrue();
        }

        [When(@"I press the '([^']*)' key")]
        public async Task WhenIPressTheKey(string key)
        {
            await _page.PressAsync("#developer-name", key);
        }

        [When(@"I drag the slider to '([^']*)'")]
        public async Task WhenIDragTheSliderTo(string value)
        {
            await _page.DragToAsync("#slider", $"#slider span:has-text('{value}')");
        }

        [When(@"I select '([^']*)' from the interface select")]
        public async Task WhenISelectFromTheInterfaceSelect(string option)
        {
            await _page.SelectOptionAsync("#preferred-interface", new[] { option });
        }

        [When(@"I fill the form with name '([^']*)' and comment '([^']*)'")]
        public async Task WhenIFillTheFormWithNameAndComment(string name, string comment)
        {
            await _page.FillAsync("#developer-name", name);
            await _page.ClickAsync("#macos");
            await _page.ClickAsync("#tried-test-cafe");
            await _page.FillAsync("#comments", comment);
        }

        [Then(@"the results should contain '([^']*)'")]
        public async Task ThenTheResultsShouldContain(string expectedText)
        {
            var results = await _page.InnerTextAsync("#article-header");
            results.Should().Contain(expectedText);
        }
    }
}
