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

    [Given("I navigate to the example page")]
    public async Task GivenINavigateToTheExamplePage()
    {
        await _page.GoToAsync("https://devexpress.github.io/testcafe/example/");
    }

    [When("I type the name 'Peter' into the name input")]
    public async Task WhenITypeTheNamePeterIntoTheNameInput()
    {
        await _page.TypeTextAsync(_page.NameInput, "Peter");
    }

    [Then("the name input should contain 'Parker'")]
    public async Task ThenTheNameInputShouldContainParker()
    {
        var value = await _page.GetValueAsync(_page.NameInput);
        value.Should().Be("Parker");
    }

    // Add similar methods for each test case in the JavaScript file
}

public class Page
{
    public async Task GoToAsync(string url)
    {
        // Implementation for navigating to a URL
    }

    public async Task TypeTextAsync(object element, string text)
    {
        // Implementation for typing text into an element
    }

    public async Task<string> GetValueAsync(object element)
    {
        // Implementation for getting the value of an element
        return "";
    }

    // Add properties and methods for each element and action in the JavaScript file
}