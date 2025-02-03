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

        [When(@"I type the name 'Peter' in the name input")]
        public async Task WhenITypeTheNamePeterInTheNameInput()
        {
            await _page.FillAsync("#developer-name", "Peter");
        }

        [When(@"I replace the name with 'Parker'")]
        public async Task WhenIReplaceTheNameWithParker()
        {
            await _page.FillAsync("#developer-name", "Parker");
        }

        [When(@"I correct the name to 'Parker'")]
        public async Task WhenICorrectTheNameToParker()
        {
            await _page.FillAsync("#developer-name", "Parker");
        }

        [Then(@"the name input should have the value 'Parker'")]
        public async Task ThenTheNameInputShouldHaveTheValueParker()
        {
            var value = await _page.InputValueAsync("#developer-name");
            value.Should().Be("Parker");
        }

        [When(@"I click on all feature labels")]
        public async Task WhenIClickOnAllFeatureLabels()
        {
            var labels = await _page.QuerySelectorAllAsync(".feature label");
            foreach (var label in labels)
            {
                await label.ClickAsync();
            }
        }

        [Then(@"all feature checkboxes should be checked")]
        public async Task ThenAllFeatureCheckboxesShouldBeChecked()
        {
            var checkboxes = await _page.QuerySelectorAllAsync(".feature input[type='checkbox']");
            foreach (var checkbox in checkboxes)
            {
                var isChecked = await checkbox.IsCheckedAsync();
                isChecked.Should().BeTrue();
            }
        }

        [When(@"I type 'Peter Parker' in the name input")]
        public async Task WhenITypePeterParkerInTheNameInput()
        {
            await _page.FillAsync("#developer-name", "Peter Parker");
        }

        [When(@"I move the caret to position 5 and press backspace")]
        public async Task WhenIMoveTheCaretToPositionAndPressBackspace()
        {
            await _page.ClickAsync("#developer-name", new ClickOptions { Position = new Position { X = 5, Y = 0 } });
            await _page.PressAsync("#developer-name", "Backspace");
        }

        [Then(@"the name input should have the value 'Pete Parker'")]
        public async Task ThenTheNameInputShouldHaveTheValuePeteParker()
        {
            var value = await _page.InputValueAsync("#developer-name");
            value.Should().Be("Pete Parker");
        }

        [When(@"I press home, right, dot, delete, delete, delete")]
        public async Task WhenIPressHomeRightDotDeleteDeleteDelete()
        {
            await _page.PressAsync("#developer-name", "Home");
            await _page.PressAsync("#developer-name", "ArrowRight");
            await _page.PressAsync("#developer-name", ".");
            await _page.PressAsync("#developer-name", "Delete");
            await _page.PressAsync("#developer-name", "Delete");
            await _page.PressAsync("#developer-name", "Delete");
        }

        [Then(@"the name input should have the value 'P. Parker'")]
        public async Task ThenTheNameInputShouldHaveTheValuePParker()
        {
            var value = await _page.InputValueAsync("#developer-name");
            value.Should().Be("P. Parker");
        }

        [When(@"I click the tried TestCafe checkbox")]
        public async Task WhenIClickTheTriedTestCafeCheckbox()
        {
            await _page.ClickAsync("#tried-test-cafe");
        }

        [When(@"I drag the slider to 9")]
        public async Task WhenIDragTheSliderTo()
        {
            var sliderHandle = await _page.QuerySelectorAsync("#slider");
            var tick = await _page.QuerySelectorAsync(".ui-slider-tick:nth-child(10)");
            await sliderHandle.DragToAsync(tick);
        }

        [Then(@"the slider handle should be at position greater than initial position")]
        public async Task ThenTheSliderHandleShouldBeAtPositionGreaterThanInitialPosition()
        {
            var sliderHandle = await _page.QuerySelectorAsync("#slider");
            var offsetLeft = await sliderHandle.EvaluateAsync<int>("e => e.offsetLeft");
            offsetLeft.Should().BeGreaterThan(0);
        }

        [When(@"I type 'Test Cafe' in the name input")]
        public async Task WhenITypeTestCafeInTheNameInput()
        {
            await _page.FillAsync("#developer-name", "Test Cafe");
        }

        [When(@"I select text from position 7 to 1 and press delete")]
        public async Task WhenISelectTextFromPositionToAndPressDelete()
        {
            await _page.ClickAsync("#developer-name", new ClickOptions { Position = new Position { X = 7, Y = 0 } });
            await _page.PressAsync("#developer-name", "Shift+ArrowLeft");
            await _page.PressAsync("#developer-name", "Delete");
        }

        [Then(@"the name input should have the value 'Tfe'")]
        public async Task ThenTheNameInputShouldHaveTheValueTfe()
        {
            var value = await _page.InputValueAsync("#developer-name");
            value.Should().Be("Tfe");
        }

        [When(@"I set native dialog handler to accept and click populate button")]
        public async Task WhenISetNativeDialogHandlerToAcceptAndClickPopulateButton()
        {
            await _page.DialogAsync += async (_, dialog) => await dialog.AcceptAsync();
            await _page.ClickAsync("#populate");
        }

        [Then(@"the dialog history should contain 'Reset information before proceeding?'")]
        public async Task ThenTheDialogHistoryShouldContainResetInformationBeforeProceeding()
        {
            var dialogs = await _page.QuerySelectorAllAsync(".dialog");
            var dialogText = await dialogs[0].TextContentAsync();
            dialogText.Should().Be("Reset information before proceeding?");
        }

        [When(@"I click submit button")]
        public async Task WhenIClickSubmitButton()
        {
            await _page.ClickAsync("#submit-button");
        }

        [Then(@"the results should contain 'Peter Parker'")]
        public async Task ThenTheResultsShouldContainPeterParker()
        {
            var results = await _page.TextContentAsync("#results");
            results.Should().Contain("Peter Parker");
        }

        [When(@"I click the interface select and choose 'Both'")]
        public async Task WhenIClickTheInterfaceSelectAndChooseBoth()
        {
            await _page.ClickAsync("#preferred-interface");
            await _page.ClickAsync("#preferred-interface option[value='Both']");
        }

        [Then(@"the interface select should have the value 'Both'")]
        public async Task ThenTheInterfaceSelectShouldHaveTheValueBoth()
        {
            var value = await _page.InputValueAsync("#preferred-interface");
            value.Should().Be("Both");
        }

        [When(@"I fill the form with 'Bruce Wayne', 'macOS', and 'tried TestCafe'")]
        public async Task WhenIFillTheFormWithBruceWayneMacOSTriedTestCafe()
        {
            await _page.FillAsync("#developer-name", "Bruce Wayne");
            await _page.ClickAsync("#macos");
            await _page.ClickAsync("#tried-test-cafe");
        }

        [When(@"I leave a comment 'It's... good'")]
        public async Task WhenILeaveACommentItsGood()
        {
            await _page.FillAsync("#comments", "It's...");
            await Task.Delay(500);
            await _page.FillAsync("#comments", "It's...\ngood");
        }

        [When(@"I change the comment to 'awesome!!!'")]
        public async Task WhenIChangeTheCommentToAwesome()
        {
            await _page.FillAsync("#comments", "awesome!!!");
        }

        [When(@"I submit the form")]
        public async Task WhenISubmitTheForm()
        {
            await _page.ClickAsync("#submit-button");
        }

        [Then(@"the results should contain 'Bruce Wayne'")]
        public async Task ThenTheResultsShouldContainBruceWayne()
        {
            var results = await _page.TextContentAsync("#results");
            results.Should().Contain("Bruce Wayne");
        }
    }
}