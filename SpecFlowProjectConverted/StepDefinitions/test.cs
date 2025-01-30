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
        await page.GoToAsync("https://devexpress.github.io/testcafe/example/");
    }

    [When(@"I type the name 'Peter'")]
    public async Task WhenITypeTheNamePeter()
    {
        await page.TypeTextAsync(page.NameInput, "Peter");
    }

    [When(@"I replace the name with 'Parker'")]
    public async Task WhenIReplaceTheNameWithParker()
    {
        await page.TypeTextAsync(page.NameInput, "Parker", true);
    }

    [When(@"I correct the name to 'Parker'")]
    public async Task WhenICorrectTheNameToParker()
    {
        await page.TypeTextAsync(page.NameInput, "r", 2);
    }

    [Then(@"the name input should be 'Parker'")]
    public async Task ThenTheNameInputShouldBeParker()
    {
        var value = await page.GetValueAsync(page.NameInput);
        value.Should().Be("Parker");
    }

    // Additional steps for other tests can be added here following the same pattern.
}
