using FluentAssertions;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace SpecFlowProjectConverted.StepDefinitions
{
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

        [Given("I navigate to the example page")]
        public async Task GivenINavigateToTheExamplePage()
        {
            await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
        }

        [When("I type the name 'Peter' into the name input")]
        public async Task WhenITypeTheNamePeterIntoTheNameInput()
        {
            await _page.FillAsync("#developer-name", "Peter");
        }

        [Then("the name input should contain 'Peter'")]
        public async Task ThenTheNameInputShouldContainPeter()
        {
            var value = await _page.InputValueAsync("#developer-name");
            value.Should().Be("Peter");
        }

        // Add more step definitions for each test case in the original JavaScript file
    }
}
