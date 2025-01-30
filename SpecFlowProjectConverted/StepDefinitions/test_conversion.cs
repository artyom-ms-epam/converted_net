using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using Microsoft.Playwright;

[Binding]
public class TestConversionSteps
{
    private readonly IPage _page;
    private readonly IBrowser _browser;
    private readonly IBrowserContext _context;

    public TestConversionSteps()
    {
        var playwright = Playwright.CreateAsync().Result;
        _browser = playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }).Result;
        _context = _browser.NewContextAsync().Result;
        _page = _context.NewPageAsync().Result;
        _page.GotoAsync("https://devexpress.github.io/testcafe/example/").Wait();
    }

    [Given(@"I have entered '([^']*)' into the name field")]
    public async Task GivenIHaveEnteredIntoTheNameField(string name)
    {
        await _page.FillAsync("#developer-name", name);
    }

    [When(@"I replace '([^']*)' with '([^']*)' in the name field")]
    public async Task WhenIReplaceWithInTheNameField(string oldName, string newName)
    {
        await _page.FillAsync("#developer-name", newName);
    }

    [Then(@"the name field should contain '([^']*)'")]
    public async Task ThenTheNameFieldShouldContain(string expectedName)
    {
        var name = await _page.InputValueAsync("#developer-name");
        name.Should().Be(expectedName);
    }

    [When(@"I click all feature labels")]
    public async Task WhenIClickAllFeatureLabels()
    {
        var labels = await _page.QuerySelectorAllAsync(".column.col-2 label");
        foreach (var label in labels)
        {
            await label.ClickAsync();
        }
    }

    [Then(@"all feature checkboxes should be checked")]
    public async Task ThenAllFeatureCheckboxesShouldBeChecked()
    {
        var checkboxes = await _page.QuerySelectorAllAsync(".column.col-2 input[type='checkbox']");
        foreach (var checkbox in checkboxes)
        {
            var isChecked = await checkbox.IsCheckedAsync();
            isChecked.Should().BeTrue();
        }
    }

    [When(@"I move the slider to '([^']*)'")]
    public async Task WhenIMoveTheSliderTo(string value)
    {
        await _page.DragAndDropAsync("#slider", $".slider-value:contains('{value}')");
    }

    [Then(@"the slider value should be '([^']*)'")]
    public async Task ThenTheSliderValueShouldBe(string expectedValue)
    {
        var value = await _page.InputValueAsync("#slider");
        value.Should().Be(expectedValue);
    }

    [When(@"I select '([^']*)' from the interface dropdown")]
    public async Task WhenISelectFromTheInterfaceDropdown(string option)
    {
        await _page.SelectOptionAsync("#preferred-interface", option);
    }

    [Then(@"the selected interface should be '([^']*)'")]
    public async Task ThenTheSelectedInterfaceShouldBe(string expectedOption)
    {
        var selectedOption = await _page.InputValueAsync("#preferred-interface");
        selectedOption.Should().Be(expectedOption);
    }

    [When(@"I fill the comments with '([^']*)'")]
    public async Task WhenIFillTheCommentsWith(string comments)
    {
        await _page.FillAsync("#comments", comments);
    }

    [Then(@"the comments should contain '([^']*)'")]
    public async Task ThenTheCommentsShouldContain(string expectedComments)
    {
        var comments = await _page.InputValueAsync("#comments");
        comments.Should().Contain(expectedComments);
    }
}
