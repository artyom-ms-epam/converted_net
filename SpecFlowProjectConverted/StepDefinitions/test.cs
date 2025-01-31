using FluentAssertions;
using TechTalk.SpecFlow;
using System.Threading.Tasks;

[Binding]
public class TestSteps
{
    private readonly Page _page;

    public TestSteps(Page page)
    {
        _page = page;
    }

    [Given(@"I navigate to the example page")]
    public async Task GivenINavigateToTheExamplePage()
    {
        await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
    }

    [When(@"I type the name Peter")]
    public async Task WhenITypeTheNamePeter()
    {
        await _page.TypeTextAsync(_page.NameInput, "Peter");
    }

    [Then(@"the name input should be Parker")]
    public async Task ThenTheNameInputShouldBeParker()
    {
        var value = await _page.GetValueAsync(_page.NameInput);
        value.Should().Be("Parker");
    }

    [When(@"I click an array of labels")]
    public async Task WhenIClickAnArrayOfLabels()
    {
        foreach (var feature in _page.FeatureList)
        {
            await _page.ClickAsync(feature.Label);
            var isChecked = await _page.IsCheckedAsync(feature.Checkbox);
            isChecked.Should().BeTrue();
        }
    }

    [When(@"I deal with text using keyboard")]
    public async Task WhenIDealWithTextUsingKeyboard()
    {
        await _page.TypeTextAsync(_page.NameInput, "Peter Parker");
        await _page.ClickAsync(_page.NameInput, new ClickOptions { CaretPos = 5 });
        await _page.PressKeyAsync("backspace");
        var value = await _page.GetValueAsync(_page.NameInput);
        value.Should().Be("Pete Parker");
        await _page.PressKeyAsync("home right . delete delete delete");
        value = await _page.GetValueAsync(_page.NameInput);
        value.Should().Be("P. Parker");
    }

    [When(@"I move the slider")]
    public async Task WhenIMoveTheSlider()
    {
        var initialOffset = await _page.GetOffsetLeftAsync(_page.Slider.Handle);
        await _page.ClickAsync(_page.TriedTestCafeCheckbox);
        await _page.DragToElementAsync(_page.Slider.Handle, _page.Slider.Tick.WithText("9"));
        var newOffset = await _page.GetOffsetLeftAsync(_page.Slider.Handle);
        newOffset.Should().BeGreaterThan(initialOffset);
    }

    [When(@"I deal with text using selection")]
    public async Task WhenIDealWithTextUsingSelection()
    {
        await _page.TypeTextAsync(_page.NameInput, "Test Cafe");
        await _page.SelectTextAsync(_page.NameInput, 7, 1);
        await _page.PressKeyAsync("delete");
        var value = await _page.GetValueAsync(_page.NameInput);
        value.Should().Be("Tfe");
    }

    [When(@"I handle native confirmation dialog")]
    public async Task WhenIHandleNativeConfirmationDialog()
    {
        await _page.SetNativeDialogHandlerAsync(() => true);
        await _page.ClickAsync(_page.PopulateButton);
        var dialogHistory = await _page.GetNativeDialogHistoryAsync();
        dialogHistory[0].Text.Should().Be("Reset information before proceeding?");
        await _page.ClickAsync(_page.SubmitButton);
        var resultText = await _page.GetInnerTextAsync(_page.Results);
        resultText.Should().Contain("Peter Parker");
    }

    [When(@"I pick option from select")]
    public async Task WhenIPickOptionFromSelect()
    {
        await _page.ClickAsync(_page.InterfaceSelect);
        await _page.ClickAsync(_page.InterfaceSelectOption.WithText("Both"));
        var value = await _page.GetValueAsync(_page.InterfaceSelect);
        value.Should().Be("Both");
    }

    [When(@"I fill a form")]
    public async Task WhenIFillAForm()
    {
        await _page.TypeTextAsync(_page.NameInput, "Bruce Wayne");
        await _page.ClickAsync(_page.MacOSRadioButton);
        await _page.ClickAsync(_page.TriedTestCafeCheckbox);
        await _page.TypeTextAsync(_page.CommentsTextArea, "It's...");
        await _page.WaitAsync(500);
        await _page.TypeTextAsync(_page.CommentsTextArea, "\ngood");
        await _page.WaitAsync(500);
        await _page.SelectTextAreaContentAsync(_page.CommentsTextArea, 1, 0);
        await _page.PressKeyAsync("delete");
        await _page.TypeTextAsync(_page.CommentsTextArea, "awesome!!!");
        await _page.WaitAsync(500);
        await _page.ClickAsync(_page.SubmitButton);
        var resultText = await _page.GetInnerTextAsync(_page.Results);
        resultText.Should().Contain("Bruce Wayne");
    }
}
