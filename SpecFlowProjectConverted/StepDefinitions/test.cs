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

        [When(@"I type name '([^']*)' into the name input")]
        public async Task WhenITypeNameIntoTheNameInput(string name)
        {
            var nameInput = await _page.QuerySelectorAsync("#developer-name");
            await nameInput.FillAsync(name);
        }

        [Then(@"the name input should have value '([^']*)'")]
        public async Task ThenTheNameInputShouldHaveValue(string expectedValue)
        {
            var nameInput = await _page.QuerySelectorAsync("#developer-name");
            var value = await nameInput.GetAttributeAsync("value");
            value.Should().Be(expectedValue);
        }

        [When(@"I click the '([^']*)' checkbox")]
        public async Task WhenIClickTheCheckbox(string checkboxLabel)
        {
            var checkbox = await _page.QuerySelectorAsync($"label:has-text('{checkboxLabel}')");
            await checkbox.ClickAsync();
        }

        [Then(@"the '([^']*)' checkbox should be checked")]
        public async Task ThenTheCheckboxShouldBeChecked(string checkboxLabel)
        {
            var checkbox = await _page.QuerySelectorAsync($"label:has-text('{checkboxLabel}') input[type='checkbox']");
            var isChecked = await checkbox.IsCheckedAsync();
            isChecked.Should().BeTrue();
        }

        [When(@"I move the slider to '([^']*)'")]
        public async Task WhenIMoveTheSliderTo(string value)
        {
            var sliderHandle = await _page.QuerySelectorAsync(".ui-slider-handle");
            var targetTick = await _page.QuerySelectorAsync($".slider-value:has-text('{value}')");
            await sliderHandle.DragToAsync(targetTick);
        }

        [Then(@"the slider value should be '([^']*)'")]
        public async Task ThenTheSliderValueShouldBe(string expectedValue)
        {
            var sliderValue = await _page.QuerySelectorAsync(".slider-value");
            var value = await sliderValue.InnerTextAsync();
            value.Should().Be(expectedValue);
        }

        [When(@"I select '([^']*)' from the interface dropdown")]
        public async Task WhenISelectFromTheInterfaceDropdown(string option)
        {
            var select = await _page.QuerySelectorAsync("#preferred-interface");
            await select.SelectOptionAsync(option);
        }

        [Then(@"the selected interface should be '([^']*)'")]
        public async Task ThenTheSelectedInterfaceShouldBe(string expectedValue)
        {
            var select = await _page.QuerySelectorAsync("#preferred-interface");
            var value = await select.InputValueAsync();
            value.Should().Be(expectedValue);
        }

        [When(@"I fill out the form with name '([^']*)' and OS '([^']*)'")]
        public async Task WhenIFillOutTheFormWithNameAndOS(string name, string os)
        {
            await WhenITypeNameIntoTheNameInput(name);
            var osRadioButton = await _page.QuerySelectorAsync($"label:has-text('{os}')");
            await osRadioButton.ClickAsync();
        }

        [When(@"I leave a comment '([^']*)'")]
        public async Task WhenILeaveAComment(string comment)
        {
            var commentsTextArea = await _page.QuerySelectorAsync("#comments");
            await commentsTextArea.FillAsync(comment);
        }

        [When(@"I submit the form")]
        public async Task WhenISubmitTheForm()
        {
            var submitButton = await _page.QuerySelectorAsync("#submit-button");
            await submitButton.ClickAsync();
        }

        [Then(@"the results should contain '([^']*)'")]
        public async Task ThenTheResultsShouldContain(string expectedText)
        {
            var results = await _page.QuerySelectorAsync("#article-header");
            var text = await results.InnerTextAsync();
            text.Should().Contain(expectedText);
        }
    }
}