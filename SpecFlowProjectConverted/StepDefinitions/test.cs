using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using Microsoft.Playwright;

[Binding]
public class TestSteps
{
    private readonly IPage _page;

    public TestSteps(IPage page)
    {
        _page = page;
    }

    [Given(@"I navigate to the example page")]
    public async Task GivenINavigateToTheExamplePage()
    {
        await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
    }

    [When(@"I type the name 'Peter'")]
    public async Task WhenITypeTheNamePeter()
    {
        await _page.FillAsync("#developer-name", "Peter");
    }

    [When(@"I replace the name with 'Paker'")]
    public async Task WhenIReplaceTheNameWithPaker()
    {
        await _page.FillAsync("#developer-name", "Paker");
    }

    [When(@"I correct the name to 'Parker'")]
    public async Task WhenICorrectTheNameToParker()
    {
        await _page.FillAsync("#developer-name", "Parker");
    }

    [Then(@"the name should be 'Parker'")]
    public async Task ThenTheNameShouldBeParker()
    {
        var value = await _page.InputValueAsync("#developer-name");
        value.Should().Be("Parker");
    }

    // Add similar methods for other tests
}
