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

        [When(@"I type the name 'Peter' into the name input")]
        public async Task WhenITypeTheNamePeterIntoTheNameInput()
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.FillAsync("Peter");
        }

        [Then(@"the name input should have value 'Peter'")]
        public async Task ThenTheNameInputShouldHaveValuePeter()
        {
            var nameInput = _page.Locator("#developer-name");
            var value = await nameInput.InputValueAsync();
            value.Should().Be("Peter");
        }

        [When(@"I replace the name with 'Parker'")]
        public async Task WhenIReplaceTheNameWithParker()
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.FillAsync("Parker");
        }

        [When(@"I correct the name to 'Parker' at position 2")]
        public async Task WhenICorrectTheNameToParkerAtPosition2()
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.FillAsync("Parker", new LocatorFillOptions { Position = 2 });
        }

        [Then(@"the name input should have value 'Parker'")]
        public async Task ThenTheNameInputShouldHaveValueParker()
        {
            var nameInput = _page.Locator("#developer-name");
            var value = await nameInput.InputValueAsync();
            value.Should().Be("Parker");
        }

        [When(@"I click all feature labels")]
        public async Task WhenIClickAllFeatureLabels()
        {
            var featureLabels = _page.Locator(".feature label");
            var count = await featureLabels.CountAsync();
            for (int i = 0; i < count; i++)
            {
                await featureLabels.Nth(i).ClickAsync();
            }
        }

        [Then(@"all feature checkboxes should be checked")]
        public async Task ThenAllFeatureCheckboxesShouldBeChecked()
        {
            var featureCheckboxes = _page.Locator(".feature input[type='checkbox']");
            var count = await featureCheckboxes.CountAsync();
            for (int i = 0; i < count; i++)
            {
                var isChecked = await featureCheckboxes.Nth(i).IsCheckedAsync();
                isChecked.Should().BeTrue();
            }
        }

        [When(@"I type 'Peter Parker' and erase a character using backspace")]
        public async Task WhenITypePeterParkerAndEraseACharacterUsingBackspace()
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.FillAsync("Peter Parker");
            await nameInput.PressAsync("ArrowLeft");
            await nameInput.PressAsync("Backspace");
        }

        [Then(@"the name input should have value 'Pete Parker'")]
        public async Task ThenTheNameInputShouldHaveValuePeteParker()
        {
            var nameInput = _page.Locator("#developer-name");
            var value = await nameInput.InputValueAsync();
            value.Should().Be("Pete Parker");
        }

        [When(@"I shorten the name to 'P. Parker'")]
        public async Task WhenIShortenTheNameToPParker()
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.FillAsync("P. Parker");
        }

        [Then(@"the name input should have value 'P. Parker'")]
        public async Task ThenTheNameInputShouldHaveValuePParker()
        {
            var nameInput = _page.Locator("#developer-name");
            var value = await nameInput.InputValueAsync();
            value.Should().Be("P. Parker");
        }

        [When(@"I move the slider to 9")]
        public async Task WhenIMoveTheSliderTo9()
        {
            var sliderHandle = _page.Locator("#slider");
            await sliderHandle.DragToAsync(_page.Locator("#slider-tick-9"));
        }

        [Then(@"the slider handle should be moved")]
        public async Task ThenTheSliderHandleShouldBeMoved()
        {
            var sliderHandle = _page.Locator("#slider");
            var offset = await sliderHandle.EvaluateAsync<int>("el => el.offsetLeft");
            offset.Should().BeGreaterThan(0);
        }

        [When(@"I select text and delete it")]
        public async Task WhenISelectTextAndDeleteIt()
        {
            var nameInput = _page.Locator("#developer-name");
            await nameInput.FillAsync("Test Cafe");
            await nameInput.SelectTextAsync(1, 7);
            await nameInput.PressAsync("Delete");
        }

        [Then(@"the name input should have value 'Tfe'")]
        public async Task ThenTheNameInputShouldHaveValueTfe()
        {
            var nameInput = _page.Locator("#developer-name");
            var value = await nameInput.InputValueAsync();
            value.Should().Be("Tfe");
        }

        [When(@"I handle the native confirmation dialog")]
        public async Task WhenIHandleTheNativeConfirmationDialog()
        {
            _page.Dialog += (_, dialog) => dialog.AcceptAsync();
            await _page.Locator("#populate").ClickAsync();
        }

        [Then(@"the dialog text should be 'Reset information before proceeding?'")]
        public async Task ThenTheDialogTextShouldBeResetInformationBeforeProceeding()
        {
            var dialogHistory = await _page.Locator("#populate").EvaluateAllAsync<string[]>("el => window.dialogHistory");
            dialogHistory[0].Should().Be("Reset information before proceeding?");
        }

        [When(@"I submit the form")]
        public async Task WhenISubmitTheForm()
        {
            await _page.Locator("#submit-button").ClickAsync();
        }

        [Then(@"the results should contain 'Peter Parker'")]
        public async Task ThenTheResultsShouldContainPeterParker()
        {
            var results = await _page.Locator("#results").InnerTextAsync();
            results.Should().Contain("Peter Parker");
        }

        [When(@"I select 'Both' from the interface select")]
        public async Task WhenISelectBothFromTheInterfaceSelect()
        {
            await _page.Locator("#preferred-interface").SelectOptionAsync(new[] { "Both" });
        }

        [Then(@"the interface select should have value 'Both'")]
        public async Task ThenTheInterfaceSelectShouldHaveValueBoth()
        {
            var value = await _page.Locator("#preferred-interface").InputValueAsync();
            value.Should().Be("Both");
        }

        [When(@"I fill the form with 'Bruce Wayne' and leave a comment")]
        public async Task WhenIFillTheFormWithBruceWayneAndLeaveAComment()
        {
            await _page.Locator("#developer-name").FillAsync("Bruce Wayne");
            await _page.Locator("#macos").CheckAsync();
            await _page.Locator("#tried-test-cafe").CheckAsync();
            await _page.Locator("#comments").FillAsync("It's...");
            await Task.Delay(500);
            await _page.Locator("#comments").TypeAsync("\ngood");
        }

        [When(@"I change my mind and type 'awesome!!!'")]
        public async Task WhenIChangeMyMindAndTypeAwesome()
        {
            await Task.Delay(500);
            await _page.Locator("#comments").SelectTextAsync();
            await _page.Locator("#comments").PressAsync("Delete");
            await _page.Locator("#comments").TypeAsync("awesome!!!");
        }

        [Then(@"the results should contain 'Bruce Wayne'")]
        public async Task ThenTheResultsShouldContainBruceWayne()
        {
            await Task.Delay(500);
            await _page.Locator("#submit-button").ClickAsync();
            var results = await _page.Locator("#results").InnerTextAsync();
            results.Should().Contain("Bruce Wayne");
        }
    }
}
