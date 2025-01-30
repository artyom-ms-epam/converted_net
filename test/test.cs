using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using Microsoft.Playwright;

namespace TestProject
{
    [Binding]
    public class TestSteps
    {
        private readonly IPage _page;

        public TestSteps(IPage page)
        {
            _page = page;
        }

        [Given("I navigate to the TestCafe example page")]
        public async Task GivenINavigateToTheTestCafeExamplePage()
        {
            await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
        }

        [When("I type '(.*)' into the name input")]
        public async Task WhenITypeIntoTheNameInput(string name)
        {
            await _page.FillAsync("#developer-name", name);
        }

        [Then("the name input should have value '(.*)'")]
        public async Task ThenTheNameInputShouldHaveValue(string expectedValue)
        {
            var value = await _page.InputValueAsync("#developer-name");
            value.Should().Be(expectedValue);
        }

        [When("I click on the '(.*)' feature")]
        public async Task WhenIClickOnTheFeature(string feature)
        {
            await _page.ClickAsync($"label[for='{feature}']");
        }

        [Then("the '(.*)' checkbox should be checked")]
        public async Task ThenTheCheckboxShouldBeChecked(string feature)
        {
            var isChecked = await _page.IsCheckedAsync($"#remote-testing");
            isChecked.Should().BeTrue();
        }

        [When("I type '(.*)' into the name input and press '(.*)'")]
        public async Task WhenITypeIntoTheNameInputAndPress(string name, string keys)
        {
            await _page.FillAsync("#developer-name", name);
            await _page.PressAsync("#developer-name", keys);
        }

        [Then("the name input should have value '(.*)' after pressing keys")]
        public async Task ThenTheNameInputShouldHaveValueAfterPressingKeys(string expectedValue)
        {
            var value = await _page.InputValueAsync("#developer-name");
            value.Should().Be(expectedValue);
        }

        [When("I click on the slider and move to '(.*)'")]
        public async Task WhenIClickOnTheSliderAndMoveTo(string value)
        {
            var sliderHandle = await _page.QuerySelectorAsync(".ui-slider-handle");
            await sliderHandle.DragToAsync(await _page.QuerySelectorAsync($".ui-slider-tick[data-value='{value}']"));
        }

        [Then("the slider should have value '(.*)'")]
        public async Task ThenTheSliderShouldHaveValue(string expectedValue)
        {
            var value = await _page.InputValueAsync(".ui-slider-handle");
            value.Should().Be(expectedValue);
        }

        [When("I select '(.*)' from the interface select")]
        public async Task WhenISelectFromTheInterfaceSelect(string option)
        {
            await _page.SelectOptionAsync("#preferred-interface", option);
        }

        [Then("the interface select should have value '(.*)'")]
        public async Task ThenTheInterfaceSelectShouldHaveValue(string expectedValue)
        {
            var value = await _page.InputValueAsync("#preferred-interface");
            value.Should().Be(expectedValue);
        }

        [When("I fill the form with '(.*)' and '(.*)'")]
        public async Task WhenIFillTheFormWithAnd(string name, string comment)
        {
            await _page.FillAsync("#developer-name", name);
            await _page.ClickAsync("#macos");
            await _page.ClickAsync("#tried-test-cafe");
            await _page.FillAsync("#comments", comment);
        }

        [Then("the form should be submitted with '(.*)' and '(.*)'")]
        public async Task ThenTheFormShouldBeSubmittedWithAnd(string name, string comment)
        {
            await _page.ClickAsync("#submit-button");
            var result = await _page.InnerTextAsync("#article-header");
            result.Should().Contain(name);
            result.Should().Contain(comment);
        }
    }
}
