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
        await _page.GoToUrl("https://devexpress.github.io/testcafe/example/");
    }

    [When(@"I type the name Peter")]
    public async Task WhenITypeTheNamePeter()
    {
        await _page.TypeText(_page.NameInput, "Peter");
    }

    [When(@"I replace the name with Parker")]
    public async Task WhenIReplaceTheNameWithParker()
    {
        await _page.TypeText(_page.NameInput, "Paker", replace: true);
    }

    [When(@"I correct the name to Parker")]
    public async Task WhenICorrectTheNameToParker()
    {
        await _page.TypeText(_page.NameInput, "r", caretPos: 2);
    }

    [Then(@"the name should be Parker")]
    public async Task ThenTheNameShouldBeParker()
    {
        var value = await _page.GetValue(_page.NameInput);
        value.Should().Be("Parker");
    }

    [When(@"I click all feature labels")]
    public async Task WhenIClickAllFeatureLabels()
    {
        foreach (var feature in _page.FeatureList)
        {
            await _page.Click(feature.Label);
            var isChecked = await _page.IsChecked(feature.Checkbox);
            isChecked.Should().BeTrue();
        }
    }

    [When(@"I type the name Peter Parker and edit it using the keyboard")]
    public async Task WhenITypeTheNamePeterParkerAndEditItUsingTheKeyboard()
    {
        await _page.TypeText(_page.NameInput, "Peter Parker");
        await _page.Click(_page.NameInput, caretPos: 5);
        await _page.PressKey("backspace");
        var value = await _page.GetValue(_page.NameInput);
        value.Should().Be("Pete Parker");
        await _page.PressKey("home right . delete delete delete");
        value = await _page.GetValue(_page.NameInput);
        value.Should().Be("P. Parker");
    }

    [When(@"I move the slider to 9")]
    public async Task WhenIMoveTheSliderTo9()
    {
        var initialOffset = await _page.GetOffsetLeft(_page.Slider.Handle);
        await _page.Click(_page.TriedTestCafeCheckbox);
        await _page.DragToElement(_page.Slider.Handle, _page.Slider.Tick.WithText("9"));
        var newOffset = await _page.GetOffsetLeft(_page.Slider.Handle);
        newOffset.Should().BeGreaterThan(initialOffset);
    }

    [When(@"I type Test Cafe and delete part of it using selection")]
    public async Task WhenITypeTestCafeAndDeletePartOfItUsingSelection()
    {
        await _page.TypeText(_page.NameInput, "Test Cafe");
        await _page.SelectText(_page.NameInput, 7, 1);
        await _page.PressKey("delete");
        var value = await _page.GetValue(_page.NameInput);
        value.Should().Be("Tfe");
    }

    [When(@"I handle the native confirmation dialog")]
    public async Task WhenIHandleTheNativeConfirmationDialog()
    {
        await _page.SetNativeDialogHandler(() => true);
        await _page.Click(_page.PopulateButton);
        var dialogHistory = await _page.GetNativeDialogHistory();
        dialogHistory[0].Text.Should().Be("Reset information before proceeding?");
        await _page.Click(_page.SubmitButton);
        var resultText = await _page.GetInnerText(_page.Results);
        resultText.Should().Contain("Peter Parker");
    }

    [When(@"I pick Both from the select dropdown")]
    public async Task WhenIPickBothFromTheSelectDropdown()
    {
        await _page.Click(_page.InterfaceSelect);
        await _page.Click(_page.InterfaceSelectOption.WithText("Both"));
        var value = await _page.GetValue(_page.InterfaceSelect);
        value.Should().Be("Both");
    }

    [When(@"I fill the form with Bruce Wayne's information")]
    public async Task WhenIFillTheFormWithBruceWaynesInformation()
    {
        await _page.TypeText(_page.NameInput, "Bruce Wayne");
        await _page.Click(_page.MacOSRadioButton);
        await _page.Click(_page.TriedTestCafeCheckbox);
        await _page.TypeText(_page.CommentsTextArea, "It's...");
        await _page.Wait(500);
        await _page.TypeText(_page.CommentsTextArea, "\ngood");
        await _page.Wait(500);
        await _page.SelectTextAreaContent(_page.CommentsTextArea, 1, 0);
        await _page.PressKey("delete");
        await _page.TypeText(_page.CommentsTextArea, "awesome!!!");
        await _page.Wait(500);
        await _page.Click(_page.SubmitButton);
        var resultText = await _page.GetInnerText(_page.Results);
        resultText.Should().Contain("Bruce Wayne");
    }
}
