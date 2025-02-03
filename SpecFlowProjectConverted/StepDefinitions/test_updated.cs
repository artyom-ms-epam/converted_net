using FluentAssertions;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace SpecFlowProjectConverted.StepDefinitions
{
    [Binding]
    public class TestSteps
    {
        private readonly Page _page;

        public TestSteps(Page page)
        {
            _page = page;
        }

        [Given(@"I navigate to the TestCafe example page")]
        public async Task GivenINavigateToTheTestCafeExamplePage()
        {
            await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
        }

        [When(@"I type the name 'Peter' into the name input")]
        public async Task WhenITypeTheNamePeterIntoTheNameInput()
        {
            var nameInput = await _page.QuerySelectorAsync("#developer-name");
            await nameInput.TypeAsync("Peter");
        }

        [Then(@"the name input should contain 'Peter'")]
        public async Task ThenTheNameInputShouldContainPeter()
        {
            var nameInput = await _page.QuerySelectorAsync("#developer-name");
            var value = await nameInput.GetAttributeAsync("value");
            value.Should().Be("Peter");
        }

        // Add other converted steps here...
    }
}
