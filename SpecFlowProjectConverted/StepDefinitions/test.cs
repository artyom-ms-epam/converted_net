using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using System.Threading.Tasks;
using Microsoft.Playwright;

[Binding]
public class TestSteps
{
    private readonly IPage _page;
    private readonly IBrowser _browser;
    private readonly IBrowserContext _context;

    public TestSteps(IPage page, IBrowser browser, IBrowserContext context)
    {
        _page = page;
        _browser = browser;
        _context = context;
    }

    [Given(@"I navigate to the example page")]
    public async Task GivenINavigateToTheExamplePage()
    {
        await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
    }

    [When(@"I type the name '([^']*)' into the name input")]
    public async Task WhenITypeTheNameIntoTheNameInput(string name)
    {
        await _page.FillAsync("#developer-name", name);
    }

    [Then(@"the name input should have the value '([^']*)'")]
    public async Task ThenTheNameInputShouldHaveTheValue(string expectedValue)
    {
        var value = await _page.InputValueAsync("#developer-name");
        value.Should().Be(expectedValue);
    }

    [When(@"I click the '([^']*)' checkbox")]
    public async Task WhenIClickTheCheckbox(string label)
    {
        await _page.CheckAsync($"label:has-text('{label}')");
    }

    [Then(@"the '([^']*)' checkbox should be checked")]
    public async Task ThenTheCheckboxShouldBeChecked(string label)
    {
        var isChecked = await _page.IsCheckedAsync($"label:has-text('{label}')");
        isChecked.Should().BeTrue();
    }

    [When(@"I press the '([^']*)' key")]
    public async Task WhenIPressTheKey(string key)
    {
        await _page.PressAsync("#developer-name", key);
    }

    [Then(@"the name input should have the value '([^']*)'")]
    public async Task ThenTheNameInputShouldHaveTheValueAfterKeyPress(string expectedValue)
    {
        var value = await _page.InputValueAsync("#developer-name");
        value.Should().Be(expectedValue);
    }

    [When(@"I drag the slider to '([^']*)'")]
    public async Task WhenIDragTheSliderTo(string value)
    {
        await _page.DragToAsync("#slider", $"#slider > span:has-text('{value}')");
    }

    [Then(@"the slider should be at '([^']*)'")]
    public async Task ThenTheSliderShouldBeAt(string value)
    {
        var sliderValue = await _page.InputValueAsync("#slider");
        sliderValue.Should().Be(value);
    }

    [When(@"I select '([^']*)' from the dropdown")]
    public async Task WhenISelectFromTheDropdown(string option)
    {
        await _page.SelectOptionAsync("#preferred-interface", new[] { option });
    }

    [Then(@"the dropdown should have '([^']*)' selected")]
    public async Task ThenTheDropdownShouldHaveSelected(string option)
    {
        var selectedOption = await _page.InputValueAsync("#preferred-interface");
        selectedOption.Should().Be(option);
    }

    [When(@"I fill the comments with '([^']*)'")]
    public async Task WhenIFillTheCommentsWith(string comments)
    {
        await _page.FillAsync("#comments", comments);
    }

    [Then(@"the comments should have the value '([^']*)'")]
    public async Task ThenTheCommentsShouldHaveTheValue(string expectedValue)
    {
        var value = await _page.InputValueAsync("#comments");
        value.Should().Be(expectedValue);
    }
}
