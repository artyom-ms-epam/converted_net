using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using Microsoft.Playwright;

namespace SpecFlowPlaywrightTests.StepDefinitions
{
    [Binding]
    public class TestCafeExamplesStepDefinitions
    {
        private readonly IPage _page;

        public TestCafeExamplesStepDefinitions(IPage page)
        {
            _page = page;
        }

        [Given("I navigate to the TestCafe example page")]
        public async Task GivenINavigateToTheTestCafeExamplePage()
        {
            await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
        }

        [When("I type the name '(.*)'")]
        public async Task WhenITypeTheName(string name)
        {
            await _page.FillAsync("#developer-name", name);
        }

        [Then("the name input should have value '(.*)'")]
        public async Task ThenTheNameInputShouldHaveValue(string expectedValue)
        {
            var value = await _page.InputValueAsync("#developer-name");
            value.Should().Be(expectedValue);
        }

        [When("I click the '(.*)' checkbox")]
        public async Task WhenIClickTheCheckbox(string label)
        {
            await _page.ClickAsync($"label:has-text('{label}')");
        }

        [Then("the '(.*)' checkbox should be checked")]
        public async Task ThenTheCheckboxShouldBeChecked(string label)
        {
            var isChecked = await _page.IsCheckedAsync($"label:has-text('{label}') + input[type='checkbox']");
            isChecked.Should().BeTrue();
        }

        [When("I move the slider to '(.*)'")]
        public async Task WhenIMoveTheSliderTo(string value)
        {
            await _page.DragAndDropAsync(".ui-slider-handle", $".ui-slider-tick:has-text('{value}')");
        }

        [Then("the slider value should be greater than '(.*)'")]
        public async Task ThenTheSliderValueShouldBeGreaterThan(int initialValue)
        {
            var offsetLeft = await _page.EvaluateAsync<int>("() => document.querySelector('.ui-slider-handle').offsetLeft");
            offsetLeft.Should().BeGreaterThan(initialValue);
        }

        [When("I select '(.*)' from the dropdown")]
        public async Task WhenISelectFromTheDropdown(string option)
        {
            await _page.SelectOptionAsync("#preferred-interface", option);
        }

        [Then("the dropdown should have value '(.*)'")]
        public async Task ThenTheDropdownShouldHaveValue(string expectedValue)
        {
            var value = await _page.InputValueAsync("#preferred-interface");
            value.Should().Be(expectedValue);
        }

        [When("I fill the form with name '(.*)' and OS '(.*)'")]
        public async Task WhenIFillTheFormWithNameAndOS(string name, string os)
        {
            await _page.FillAsync("#developer-name", name);
            await _page.ClickAsync($"input[value='{os}']");
            await _page.ClickAsync("#tried-test-cafe");
        }

        [When("I submit the form")]
        public async Task WhenISubmitTheForm()
        {
            await _page.ClickAsync("#submit-button");
        }

        [Then("the results should contain '(.*)'")]
        public async Task ThenTheResultsShouldContain(string expectedResult)
        {
            var resultsText = await _page.InnerTextAsync("#article-header");
            resultsText.Should().Contain(expectedResult);
        }
    }
}
