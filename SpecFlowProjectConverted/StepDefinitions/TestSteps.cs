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
        private readonly PageModel _pageModel;

        public TestSteps(IPage page)
        {
            _page = page;
            _pageModel = new PageModel(page);
        }

        [Given(@"I navigate to the TestCafe example page")]
        public async Task GivenINavigateToTheTestCafeExamplePage()
        {
            await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
        }

        [When(@"I type the name 'Peter' in the input field")]
        public async Task WhenITypeTheNamePeterInTheInputField()
        {
            await _pageModel.NameInput.FillAsync("Peter");
        }

        [When(@"I replace the name with 'Parker'")]
        public async Task WhenIReplaceTheNameWithParker()
        {
            await _pageModel.NameInput.FillAsync("Parker");
        }

        [When(@"I correct the name to 'Parker'")]
        public async Task WhenICorrectTheNameToParker()
        {
            await _pageModel.NameInput.PressAsync("ArrowLeft");
            await _pageModel.NameInput.TypeAsync("r");
        }

        [Then(@"the input field should contain 'Parker'")]
        public async Task ThenTheInputFieldShouldContainParker()
        {
            var value = await _pageModel.NameInput.InputValueAsync();
            value.Should().Be("Parker");
        }

        // Additional steps for other tests go here...
    }
}

public class PageModel
{
    private readonly IPage _page;

    public PageModel(IPage page)
    {
        _page = page;
    }

    public ILocator NameInput => _page.Locator("#developer-name");
    public ILocator FeatureList => _page.Locator(".column.col-2 label");
    public ILocator Slider => _page.Locator("#slider");
    public ILocator TriedTestCafeCheckbox => _page.Locator("#tried-test-cafe");
    public ILocator PopulateButton => _page.Locator("#populate");
    public ILocator SubmitButton => _page.Locator("#submit-button");
    public ILocator Results => _page.Locator("#article-header");
    public ILocator InterfaceSelect => _page.Locator("#preferred-interface");
    public ILocator InterfaceSelectOption => _page.Locator("#preferred-interface option");
    public ILocator CommentsTextArea => _page.Locator("#comments");
}
