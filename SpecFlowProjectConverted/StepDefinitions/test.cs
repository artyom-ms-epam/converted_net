using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using Microsoft.Playwright;

[Binding]
public class TestSteps
{
    private readonly IPage _page;
    private readonly IBrowser _browser;
    private readonly IBrowserContext _context;

    public TestSteps()
    {
        var playwright = Playwright.CreateAsync().Result;
        _browser = playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }).Result;
        _context = _browser.NewContextAsync().Result;
        _page = _context.NewPageAsync().Result;
    }

    [Given(@"I navigate to the TestCafe example page")]
    public async Task GivenINavigateToTheTestCafeExamplePage()
    {
        await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
    }

    [When(@"I type 'Peter' in the name input")]
    public async Task WhenITypePeterInTheNameInput()
    {
        await _page.FillAsync("#developer-name", "Peter");
    }

    [When(@"I replace the name with 'Parker'")]
    public async Task WhenIReplaceTheNameWithParker()
    {
        await _page.FillAsync("#developer-name", "Parker");
    }

    [When(@"I correct the name to 'Parker'")]
    public async Task WhenICorrectTheNameToParker()
    {
        await _page.FillAsync("#developer-name", "Parker");
    }

    [Then(@"the name input should have 'Parker'")]
    public async Task ThenTheNameInputShouldHaveParker()
    {
        var value = await _page.InputValueAsync("#developer-name");
        value.Should().Be("Parker");
    }

    // Other steps can be added similarly for the remaining tests
}