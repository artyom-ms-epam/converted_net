using FluentAssertions;
using TechTalk.SpecFlow;
using System.Threading.Tasks;

[Binding]
public class TestSteps
{
    [Given(@"I navigate to the example page")]
    public async Task GivenINavigateToTheExamplePage()
    {
        await Page.GotoAsync("https://devexpress.github.io/testcafe/example/");
    }

    [When(@"I type the name 'Peter'")]
    public async Task WhenITypeTheNamePeter()
    {
        await Page.FillAsync("#developer-name", "Peter");
    }

    [Then(@"the name input should have 'Peter' as value")]
    public async Task ThenTheNameInputShouldHavePeterAsValue()
    {
        var value = await Page.GetAttributeAsync("#developer-name", "value");
        value.Should().Be("Peter");
    }

    // Add more step definitions here for each test case from the JavaScript file
}
