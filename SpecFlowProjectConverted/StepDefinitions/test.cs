using FluentAssertions;
using TechTalk.SpecFlow;
using System.Threading.Tasks;

[Binding]
public class TestSteps
{
    private readonly Page _page = new Page();

    [Given(@"I navigate to the TestCafe example page")]
    public async Task GivenINavigateToTheTestCafeExamplePage()
    {
        await Page.GotoAsync("https://devexpress.github.io/testcafe/example/");
    }

    [When(@"I type the name 'Peter' into the name input")]
    public async Task WhenITypeTheNamePeterIntoTheNameInput()
    {
        await Page.TypeTextAsync(_page.NameInput, "Peter");
    }

    [When(@"I replace the name with 'Paker'")]
    public async Task WhenIReplaceTheNameWithPaker()
    {
        await Page.TypeTextAsync(_page.NameInput, "Paker", new { replace = true });
    }

    [When(@"I correct the name to 'Parker'")]
    public async Task WhenICorrectTheNameToParker()
    {
        await Page.TypeTextAsync(_page.NameInput, "r", new { caretPos = 2 });
    }

    [Then(@"the name input should contain 'Parker'")]
    public async Task ThenTheNameInputShouldContainParker()
    {
        var value = await Page.GetValueAsync(_page.NameInput);
        value.Should().Be("Parker");
    }

    [When(@"I click each feature and check their states")]
    public async Task WhenIClickEachFeatureAndCheckTheirStates()
    {
        foreach (var feature in _page.FeatureList)
        {
            await Page.ClickAsync(feature.Label);
            var checked = await Page.IsCheckedAsync(feature.Checkbox);
            checked.Should().BeTrue();
        }
    }

    [When(@"I type the name 'Peter Parker' and modify it using the keyboard")]
    public async Task WhenITypeTheNamePeterParkerAndModifyItUsingTheKeyboard()
    {
        await Page.TypeTextAsync(_page.NameInput, "Peter Parker");
        await Page.ClickAsync(_page.NameInput, new { caretPos = 5 });
        await Page.PressKeyAsync("backspace");
        var value = await Page.GetValueAsync(_page.NameInput);
        value.Should().Be("Pete Parker");
        await Page.PressKeyAsync("home right . delete delete delete");
        value = await Page.GetValueAsync(_page.NameInput);
        value.Should().Be("P. Parker");
    }

    [When(@"I move the slider")]
    public async Task WhenIMoveTheSlider()
    {
        var initialOffset = await Page.GetOffsetLeftAsync(_page.Slider.Handle);
        await Page.ClickAsync(_page.TriedTestCafeCheckbox);
        await Page.DragToElementAsync(_page.Slider.Handle, _page.Slider.Tick.WithText("9"));
        var offset = await Page.GetOffsetLeftAsync(_page.Slider.Handle);
        offset.Should().BeGreaterThan(initialOffset);
    }

    [When(@"I select text and delete it")]
    public async Task WhenISelectTextAndDeleteIt()
    {
        await Page.TypeTextAsync(_page.NameInput, "Test Cafe");
        await Page.SelectTextAsync(_page.NameInput, 7, 1);
        await Page.PressKeyAsync("delete");
        var value = await Page.GetValueAsync(_page.NameInput);
        value.Should().Be("Tfe");
    }

    [When(@"I handle the native confirmation dialog")]
    public async Task WhenIHandleTheNativeConfirmationDialog()
    {
        await Page.SetNativeDialogHandlerAsync(() => true);
        await Page.ClickAsync(_page.PopulateButton);
        var dialogHistory = await Page.GetNativeDialogHistoryAsync();
        dialogHistory[0].Text.Should().Be("Reset information before proceeding?");
        await Page.ClickAsync(_page.SubmitButton);
        var innerText = await Page.GetInnerTextAsync(_page.Results);
        innerText.Should().Contain("Peter Parker");
    }

    [When(@"I pick an option from the select")]
    public async Task WhenIPickAnOptionFromTheSelect()
    {
        await Page.ClickAsync(_page.InterfaceSelect);
        await Page.ClickAsync(_page.InterfaceSelectOption.WithText("Both"));
        var value = await Page.GetValueAsync(_page.InterfaceSelect);
        value.Should().Be("Both");
    }

    [When(@"I fill the form")]
    public async Task WhenIFillTheForm()
    {
        await Page.TypeTextAsync(_page.NameInput, "Bruce Wayne");
        await Page.ClickAsync(_page.MacOSRadioButton);
        await Page.ClickAsync(_page.TriedTestCafeCheckbox);
        await Page.TypeTextAsync(_page.CommentsTextArea, "It's...");
        await Task.Delay(500);
        await Page.TypeTextAsync(_page.CommentsTextArea, "\ngood");
        await Task.Delay(500);
        await Page.SelectTextAreaContentAsync(_page.CommentsTextArea, 1, 0);
        await Page.PressKeyAsync("delete");
        await Page.TypeTextAsync(_page.CommentsTextArea, "awesome!!!");
        await Task.Delay(500);
        await Page.ClickAsync(_page.SubmitButton);
        var innerText = await Page.GetInnerTextAsync(_page.Results);
        innerText.Should().Contain("Bruce Wayne");
    }
}