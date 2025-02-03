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

        [Given("I navigate to the example page")]
        public async Task GivenINavigateToTheExamplePage()
        {
            await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
        }

        [Then("I type name 'Peter' and replace with 'Parker'")]
        public async Task ThenITypeNamePeterAndReplaceWithParker()
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.FillAsync("Peter");
            await nameInput.FillAsync("Parker");
            var value = await nameInput.InputValueAsync();
            value.Should().Be("Parker");
        }

        [Then("I click an array of labels and check their states")]
        public async Task ThenIClickAnArrayOfLabelsAndCheckTheirStates()
        {
            var featureList = _page.Locator(".feature");
            var count = await featureList.CountAsync();
            for (int i = 0; i < count; i++)
            {
                var feature = featureList.Nth(i);
                await feature.ClickAsync();
                var checkbox = feature.Locator("input[type='checkbox']");
                var isChecked = await checkbox.IsCheckedAsync();
                isChecked.Should().BeTrue();
            }
        }

        [Then("I deal with text using keyboard")]
        public async Task ThenIDealWithTextUsingKeyboard()
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.FillAsync("Peter Parker");
            await nameInput.PressAsync("ArrowLeft");
            await nameInput.PressAsync("Backspace");
            var value = await nameInput.InputValueAsync();
            value.Should().Be("Pete Parker");
            await nameInput.PressAsync("Home");
            await nameInput.PressAsync("ArrowRight");
            await nameInput.PressAsync(".");
            await nameInput.PressAsync("Delete");
            await nameInput.PressAsync("Delete");
            await nameInput.PressAsync("Delete");
            value = await nameInput.InputValueAsync();
            value.Should().Be("P. Parker");
        }

        [Then("I move the slider")]
        public async Task ThenIMoveTheSlider()
        {
            var sliderHandle = _page.Locator("#slider");
            var initialOffset = await sliderHandle.EvaluateAsync<int>("el => el.offsetLeft");
            await _page.ClickAsync("#tried-test-cafe");
            await sliderHandle.DragToAsync(_page.Locator(".slider-value").WithText("9"));
            var newOffset = await sliderHandle.EvaluateAsync<int>("el => el.offsetLeft");
            newOffset.Should().BeGreaterThan(initialOffset);
        }

        [Then("I deal with text using selection")]
        public async Task ThenIDealWithTextUsingSelection()
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.FillAsync("Test Cafe");
            await nameInput.SelectTextAsync(1, 7);
            await nameInput.PressAsync("Delete");
            var value = await nameInput.InputValueAsync();
            value.Should().Be("Tfe");
        }

        [Then("I handle native confirmation dialog")]
        public async Task ThenIHandleNativeConfirmationDialog()
        {
            await _page.DialogAsync(dialog => dialog.AcceptAsync());
            await _page.ClickAsync("#populate");
            var dialogHistory = await _page.DialogHistoryAsync();
            dialogHistory[0].Message.Should().Be("Reset information before proceeding?");
            await _page.ClickAsync("#submit-button");
            var resultText = await _page.Locator("#result").InnerTextAsync();
            resultText.Should().Contain("Peter Parker");
        }

        [Then("I pick option from select")]
        public async Task ThenIPickOptionFromSelect()
        {
            await _page.ClickAsync("#preferred-interface");
            await _page.ClickAsync("option[value='Both']");
            var selectedValue = await _page.Locator("#preferred-interface").InputValueAsync();
            selectedValue.Should().Be("Both");
        }

        [Then("I fill a form")]
        public async Task ThenIFillAForm()
        {
            await _page.FillAsync("#developer-name", "Bruce Wayne");
            await _page.ClickAsync("#macos");
            await _page.ClickAsync("#tried-test-cafe");
            await _page.FillAsync("#comments", "It's...");
            await _page.WaitForTimeoutAsync(500);
            await _page.FillAsync("#comments", "\ngood");
            await _page.WaitForTimeoutAsync(500);
            await _page.Locator("#comments").SelectTextAsync();
            await _page.PressAsync("Delete");
            await _page.FillAsync("#comments", "awesome!!!");
            await _page.WaitForTimeoutAsync(500);
            await _page.ClickAsync("#submit-button");
            var resultText = await _page.Locator("#result").InnerTextAsync();
            resultText.Should().Contain("Bruce Wayne");
        }
    }
}
