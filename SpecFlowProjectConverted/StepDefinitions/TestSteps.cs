using FluentAssertions;
using TechTalk.SpecFlow;
using System.Threading.Tasks;

[Binding]
public class TestSteps
{
    private readonly Page page = new Page();

    [Given(@"I navigate to the example page")]
    public async Task GivenINavigateToTheExamplePage()
    {
        await Page.GotoAsync("https://devexpress.github.io/testcafe/example/");
    }

    [Then(@"I type 'Peter' in the name input")]
    public async Task ThenITypePeterInTheNameInput()
    {
        await page.TypeTextAsync(page.NameInput, "Peter");
    }

    [Then(@"I replace it with 'Parker'")]
    public async Task ThenIReplaceItWithParker()
    {
        await page.TypeTextAsync(page.NameInput, "Parker", replace: true);
    }

    [Then(@"I correct the name to 'Parker'")]
    public async Task ThenICorrectTheNameToParker()
    {
        await page.TypeTextAsync(page.NameInput, "r", caretPos: 2);
        (await page.GetValueAsync(page.NameInput)).Should().Be("Parker");
    }

    [Then(@"I click an array of labels and check their states")]
    public async Task ThenIClickAnArrayOfLabelsAndCheckTheirStates()
    {
        foreach (var feature in page.FeatureList)
        {
            await page.ClickAsync(feature.Label);
            (await page.IsCheckedAsync(feature.Checkbox)).Should().BeTrue();
        }
    }

    [Then(@"I deal with text using the keyboard")]
    public async Task ThenIDealWithTextUsingTheKeyboard()
    {
        await page.TypeTextAsync(page.NameInput, "Peter Parker");
        await page.ClickAsync(page.NameInput, caretPos: 5);
        await page.PressKeyAsync("backspace");
        (await page.GetValueAsync(page.NameInput)).Should().Be("Pete Parker");
        await page.PressKeyAsync("home right . delete delete delete");
        (await page.GetValueAsync(page.NameInput)).Should().Be("P. Parker");
    }

    [Then(@"I move the slider")]
    public async Task ThenIMoveTheSlider()
    {
        var initialOffset = await page.GetOffsetLeftAsync(page.Slider.Handle);
        await page.ClickAsync(page.TriedTestCafeCheckbox);
        await page.DragToElementAsync(page.Slider.Handle, page.Slider.Tick.WithText("9"));
        (await page.GetOffsetLeftAsync(page.Slider.Handle)).Should().BeGreaterThan(initialOffset);
    }

    [Then(@"I deal with text using selection")]
    public async Task ThenIDealWithTextUsingSelection()
    {
        await page.TypeTextAsync(page.NameInput, "Test Cafe");
        await page.SelectTextAsync(page.NameInput, 7, 1);
        await page.PressKeyAsync("delete");
        (await page.GetValueAsync(page.NameInput)).Should().Be("Tfe");
    }

    [Then(@"I handle native confirmation dialog")]
    public async Task ThenIHandleNativeConfirmationDialog()
    {
        await page.SetNativeDialogHandlerAsync(() => true);
        await page.ClickAsync(page.PopulateButton);
        var dialogHistory = await page.GetNativeDialogHistoryAsync();
        dialogHistory[0].Text.Should().Be("Reset information before proceeding?");
        await page.ClickAsync(page.SubmitButton);
        (await page.GetInnerTextAsync(page.Results)).Should().Contain("Peter Parker");
    }

    [Then(@"I pick an option from select")]
    public async Task ThenIPickAnOptionFromSelect()
    {
        await page.ClickAsync(page.InterfaceSelect);
        await page.ClickAsync(page.InterfaceSelectOption.WithText("Both"));
        (await page.GetValueAsync(page.InterfaceSelect)).Should().Be("Both");
    }

    [Then(@"I fill the form")]
    public async Task ThenIFillTheForm()
    {
        await page.TypeTextAsync(page.NameInput, "Bruce Wayne");
        await page.ClickAsync(page.MacOSRadioButton);
        await page.ClickAsync(page.TriedTestCafeCheckbox);
        await page.TypeTextAsync(page.CommentsTextArea, "It's...");
        await Task.Delay(500);
        await page.TypeTextAsync(page.CommentsTextArea, "\ngood");
        await Task.Delay(500);
        await page.SelectTextAreaContentAsync(page.CommentsTextArea, 1, 0);
        await page.PressKeyAsync("delete");
        await page.TypeTextAsync(page.CommentsTextArea, "awesome!!!");
        await Task.Delay(500);
        await page.ClickAsync(page.SubmitButton);
        (await page.GetInnerTextAsync(page.Results)).Should().Contain("Bruce Wayne");
    }
}
