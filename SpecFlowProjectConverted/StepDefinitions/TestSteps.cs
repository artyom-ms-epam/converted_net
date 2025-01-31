using FluentAssertions;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using Microsoft.Playwright;

[Binding]
public class TestSteps
{
    private readonly IPage _page;
    private readonly PageModel _pageModel;

    public TestSteps(IPage page, PageModel pageModel)
    {
        _page = page;
        _pageModel = pageModel;
    }

    [Given("I navigate to the TestCafe example page")]
    public async Task GivenINavigateToTheTestCafeExamplePage()
    {
        await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
    }

    [When("I type the name 'Peter' in the name input")]
    public async Task WhenITypeTheNamePeterInTheNameInput()
    {
        await _page.FillAsync(_pageModel.NameInput, "Peter");
    }

    [When("I replace the name with 'Parker'")]
    public async Task WhenIReplaceTheNameWithParker()
    {
        await _page.FillAsync(_pageModel.NameInput, "Parker");
    }

    [When("I correct the name to 'Parker'")]
    public async Task WhenICorrectTheNameToParker()
    {
        await _page.FillAsync(_pageModel.NameInput, "Parker");
    }

    [Then("the name input should have the value 'Parker'")]
    public async Task ThenTheNameInputShouldHaveTheValueParker()
    {
        var value = await _page.InputValueAsync(_pageModel.NameInput);
        value.Should().Be("Parker");
    }

    // Add the rest of the tests following the same pattern
}

public class PageModel
{
    public string NameInput => "#developer-name";
    public string SliderHandle => "#slider .ui-slider-handle";
    public string TriedTestCafeCheckbox => "#tried-test-cafe";
    public string PopulateButton => "#populate";
    public string SubmitButton => "#submit-button";
    public string Results => "#article-header";
    public string InterfaceSelect => "#preferred-interface";
    public string InterfaceSelectOption => "#preferred-interface option";
    public string CommentsTextArea => "#comments";
    public string MacOSRadioButton => "#macos";
    public string FeatureList => ".feature";
}
