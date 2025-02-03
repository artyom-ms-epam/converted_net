using FluentAssertions;
using TechTalk.SpecFlow;
using System.Threading.Tasks;

[Binding]
public class TestSteps
{
    [Given("Text typing basics")]
    public async Task TextTypingBasics()
    {
        var page = new Page();
        await page.TypeText(page.NameInput, "Peter");
        await page.TypeText(page.NameInput, "Paker", true);
        await page.TypeText(page.NameInput, "r", 2);
        page.NameInput.Value.Should().Be("Parker");
    }

    [Given("Click an array of labels and then check their states")]
    public async Task ClickArrayOfLabels()
    {
        var page = new Page();
        foreach (var feature in page.FeatureList)
        {
            await page.Click(feature.Label);
            feature.Checkbox.Checked.Should().BeTrue();
        }
    }

    [Given("Dealing with text using keyboard")]
    public async Task DealingWithTextUsingKeyboard()
    {
        var page = new Page();
        await page.TypeText(page.NameInput, "Peter Parker");
        await page.Click(page.NameInput, 5);
        await page.PressKey("backspace");
        page.NameInput.Value.Should().Be("Pete Parker");
        await page.PressKey("home right . delete delete delete");
        page.NameInput.Value.Should().Be("P. Parker");
    }

    [Given("Moving the slider")]
    public async Task MovingTheSlider()
    {
        var page = new Page();
        var initialOffset = await page.Slider.Handle.OffsetLeft;
        await page.Click(page.TriedTestCafeCheckbox);
        await page.DragToElement(page.Slider.Handle, page.Slider.Tick.WithText("9"));
        (await page.Slider.Handle.OffsetLeft).Should().BeGreaterThan(initialOffset);
    }

    [Given("Dealing with text using selection")]
    public async Task DealingWithTextUsingSelection()
    {
        var page = new Page();
        await page.TypeText(page.NameInput, "Test Cafe");
        await page.SelectText(page.NameInput, 7, 1);
        await page.PressKey("delete");
        page.NameInput.Value.Should().Be("Tfe");
    }

    [Given("Handle native confirmation dialog")]
    public async Task HandleNativeConfirmationDialog()
    {
        var page = new Page();
        await page.SetNativeDialogHandler(() => true);
        await page.Click(page.PopulateButton);
        var dialogHistory = await page.GetNativeDialogHistory();
        dialogHistory[0].Text.Should().Be("Reset information before proceeding?");
        await page.Click(page.SubmitButton);
        page.Results.InnerText.Should().Contain("Peter Parker");
    }

    [Given("Pick option from select")]
    public async Task PickOptionFromSelect()
    {
        var page = new Page();
        await page.Click(page.InterfaceSelect);
        await page.Click(page.InterfaceSelectOption.WithText("Both"));
        page.InterfaceSelect.Value.Should().Be("Both");
    }

    [Given("Filling a form")]
    public async Task FillingAForm()
    {
        var page = new Page();
        await page.TypeText(page.NameInput, "Bruce Wayne");
        await page.Click(page.MacOSRadioButton);
        await page.Click(page.TriedTestCafeCheckbox);
        await page.TypeText(page.CommentsTextArea, "It's...");
        await Task.Delay(500);
        await page.TypeText(page.CommentsTextArea, "\ngood");
        await Task.Delay(500);
        await page.SelectTextAreaContent(page.CommentsTextArea, 1, 0);
        await page.PressKey("delete");
        await page.TypeText(page.CommentsTextArea, "awesome!!!");
        await Task.Delay(500);
        await page.Click(page.SubmitButton);
        page.Results.InnerText.Should().Contain("Bruce Wayne");
    }
}