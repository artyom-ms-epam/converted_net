using FluentAssertions;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using Microsoft.Playwright;

[Binding]
public class TestSteps
{
    private readonly ScenarioContext _scenarioContext;
    private IPage _page;
    private IBrowser _browser;

    public TestSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given("I navigate to the example page")]
    public async Task GivenINavigateToTheExamplePage()
    {
        var playwright = await Playwright.CreateAsync();
        _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        var context = await _browser.NewContextAsync();
        _page = await context.NewPageAsync();
        await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
    }

    [When("I type the name 'Peter'")]
    public async Task WhenITypeTheNamePeter()
    {
        await _page.FillAsync("#developer-name", "Peter");
    }

    [Then("the name input should have the value 'Peter'")]
    public async Task ThenTheNameInputShouldHaveTheValuePeter()
    {
        var value = await _page.InputValueAsync("#developer-name");
        value.Should().Be("Peter");
    }

    // Add the remaining tests here following the same pattern
}
