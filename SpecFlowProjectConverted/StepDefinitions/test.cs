using NUnit.Framework;
using TechTalk.SpecFlow;
using FluentAssertions;
using System.Threading.Tasks;

namespace SpecFlowProjectConverted.StepDefinitions
{
    [Binding]
    public class TestSteps
    {
        private readonly Page _page = new Page();

        [Given(@"I navigate to the example page")]
        public async Task GivenINavigateToTheExamplePage()
        {
            await Page.GotoAsync("https://devexpress.github.io/testcafe/example/");
        }

        [When(@"I type text 'Peter' in the name input")]
        public async Task WhenITypeTextPeterInTheNameInput()
        {
            await _page.TypeTextAsync(_page.NameInput, "Peter");
        }

        [When(@"I replace text with 'Parker'")]
        public async Task WhenIReplaceTextWithParker()
        {
            await _page.TypeTextAsync(_page.NameInput, "Parker", new TypeTextOptions { Replace = true });
        }

        [When(@"I correct the last name with 'r'")]
        public async Task WhenICorrectTheLastNameWithR()
        {
            await _page.TypeTextAsync(_page.NameInput, "r", new TypeTextOptions { CaretPos = 2 });
        }

        [Then(@"the name input should have value 'Parker'")]
        public async Task ThenTheNameInputShouldHaveValueParker()
        {
            var value = await _page.GetValueAsync(_page.NameInput);
            value.Should().Be("Parker");
        }

        // Other tests converted similarly...
    }
}
