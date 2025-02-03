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

        [When(@"I type '([^']*)' in the name input")]
        public async Task WhenITypeInTheNameInput(string name)
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.FillAsync(name);
        }

        [Then(@"the name input should have value '([^']*)'")]
        public async Task ThenTheNameInputShouldHaveValue(string expectedValue)
        {
            var nameInput = _page.Locator("#developer-name");
            var value = await nameInput.InputValueAsync();
            value.Should().Be(expectedValue);
        }

        [When(@"I click on the feature labels")]
        public async Task WhenIClickOnTheFeatureLabels()
        {
            var featureLabels = _page.Locator(".column.col-2 label");
            var count = await featureLabels.CountAsync();
            for (int i = 0; i < count; i++)
            {
                await featureLabels.Nth(i).ClickAsync();
            }
        }

        [Then(@"the feature checkboxes should be checked")]
        public async Task ThenTheFeatureCheckboxesShouldBeChecked()
        {
            var featureCheckboxes = _page.Locator(".column.col-2 input[type='checkbox']");
            var count = await featureCheckboxes.CountAsync();
            for (int i = 0; i < count; i++)
            {
                var isChecked = await featureCheckboxes.Nth(i).IsCheckedAsync();
                isChecked.Should().BeTrue();
            }
        }

        [When(@"I type '([^']*)' and press '([^']*)'")]
        public async Task WhenITypeAndPress(string text, string keys)
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.FillAsync(text);
            await nameInput.PressAsync(keys);
        }

        [Then(@"the name input should have value '([^']*)'")]
        public async Task ThenTheNameInputShouldHaveValue(string expectedValue)
        {
            var nameInput = _page.Locator("#developer-name");
            var value = await nameInput.InputValueAsync();
            value.Should().Be(expectedValue);
        }

        [When(@"I move the slider to '([^']*)'")]
        public async Task WhenIMoveTheSliderTo(string value)
        {
            var slider = _page.Locator("#slider");
            await slider.SetValueAsync(value);
        }

        [Then(@"the slider value should be '([^']*)'")]
        public async Task ThenTheSliderValueShouldBe(string expectedValue)
        {
            var slider = _page.Locator("#slider");
            var value = await slider.InputValueAsync();
            value.Should().Be(expectedValue);
        }

        [When(@"I select '([^']*)' from the interface select")]
        public async Task WhenISelectFromTheInterfaceSelect(string option)
        {
            var interfaceSelect = _page.Locator("#preferred-interface");
            await interfaceSelect.SelectOptionAsync(option);
        }

        [Then(@"the interface select should have value '([^']*)'")]
        public async Task ThenTheInterfaceSelectShouldHaveValue(string expectedValue)
        {
            var interfaceSelect = _page.Locator("#preferred-interface");
            var value = await interfaceSelect.InputValueAsync();
            value.Should().Be(expectedValue);
        }

        [When(@"I fill the form with '([^']*)' and '([^']*)'")]
        public async Task WhenIFillTheFormWithAnd(string name, string comment)
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.FillAsync(name);
            var commentsTextArea = _page.Locator("#comments");
            await commentsTextArea.FillAsync(comment);
        }

        [Then(@"the form should be submitted with '([^']*)' and '([^']*)'")]
        public async Task ThenTheFormShouldBeSubmittedWithAnd(string expectedName, string expectedComment)
        {
            var results = _page.Locator("#article-header");
            var text = await results.InnerTextAsync();
            text.Should().Contain(expectedName);
            text.Should().Contain(expectedComment);
        }
    }
}
