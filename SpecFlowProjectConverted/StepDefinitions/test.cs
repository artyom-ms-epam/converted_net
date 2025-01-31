using FluentAssertions;
using TechTalk.SpecFlow;
using System.Threading.Tasks;

namespace SpecFlowProjectConverted.StepDefinitions
{
    [Binding]
    public class TestStepDefinitions
    {
        private readonly Page _page;

        public TestStepDefinitions(Page page)
        {
            _page = page;
        }

        [Given(@"I am on the example page")]
        public async Task GivenIAmOnTheExamplePage()
        {
            await _page.GoToAsync("https://devexpress.github.io/testcafe/example/");
        }

        [When(@"I type 'Peter' into the name input")]
        public async Task WhenITypePeterIntoTheNameInput()
        {
            await _page.TypeTextAsync(_page.NameInput, "Peter");
        }

        [When(@"I replace it with 'Parker'")]
        public async Task WhenIReplaceItWithParker()
        {
            await _page.TypeTextAsync(_page.NameInput, "Parker", true);
        }

        [When(@"I correct it to 'Parker'")]
        public async Task WhenICorrectItToParker()
        {
            await _page.TypeTextAsync(_page.NameInput, "r", 2);
        }

        [Then(@"the name input should be 'Parker'")]
        public async Task ThenTheNameInputShouldBeParker()
        {
            var value = await _page.GetInputValueAsync(_page.NameInput);
            value.Should().Be("Parker");
        }

        // Additional step definitions for other tests...
    }
}