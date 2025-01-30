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

    [Given(@"I navigate to the test page")]
    public async Task GivenINavigateToTheTestPage()
    {
        await _page.GoToAsync("https://devexpress.github.io/testcafe/example/");
    }

    [When(@"I type name '([^']*)' into the input field")]
    public async Task WhenITypeNameIntoTheInputField(string name)
    {
        await _page.TypeTextAsync(_page.NameInput, name);
    }

    [Then(@"the input field should contain '([^']*)'")]
    public async Task ThenTheInputFieldShouldContain(string expectedName)
    {
        var value = await _page.GetInputValueAsync(_page.NameInput);
        value.Should().Be(expectedName);
    }

    // Add more step definitions as needed
}

public class Page
{
    public string NameInput => "#developer-name";

    public async Task GoToAsync(string url)
    {
        // Implement navigation logic
    }

    public async Task TypeTextAsync(string selector, string text)
    {
        // Implement typing logic
    }

    public async Task<string> GetInputValueAsync(string selector)
    {
        // Implement value retrieval logic
        return string.Empty;
    }
}