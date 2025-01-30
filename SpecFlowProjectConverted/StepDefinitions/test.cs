using FluentAssertions;
using TechTalk.SpecFlow;
using Microsoft.Playwright;

namespace SpecFlowProjectConverted.StepDefinitions
{
    [Binding]
    public class TestSteps
    {
        private readonly IPage _page;

        public TestSteps(IPage page)
        {
            _page = page;
        }

        [Given(@"I navigate to the test page")]
        public async Task GivenINavigateToTheTestPage()
        {
            await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
        }

        [When(@"I type text '([^']*)' into the input field")]
        public async Task WhenITypeTextIntoTheInputField(string text)
        {
            await _page.FillAsync("#developer-name", text);
        }

        [Then(@"the input field should contain '([^']*)'")]
        public async Task ThenTheInputFieldShouldContain(string expectedText)
        {
            var value = await _page.InputValueAsync("#developer-name");
            value.Should().Be(expectedText);
        }

        [When(@"I click the populate button")]
        public async Task WhenIClickThePopulateButton()
        {
            await _page.ClickAsync("#populate");
        }

        [Then(@"the confirmation dialog should appear with text '([^']*)'")]
        public async Task ThenTheConfirmationDialogShouldAppearWithText(string expectedText)
        {
            var dialog = await _page.WaitForEventAsync(PageEvent.Dialog);
            dialog.Message.Should().Be(expectedText);
            await dialog.AcceptAsync();
        }

        [When(@"I select '([^']*)' from the interface select dropdown")]
        public async Task WhenISelectFromTheInterfaceSelectDropdown(string option)
        {
            await _page.SelectOptionAsync("#preferred-interface", new[] { option });
        }

        [Then(@"the interface select dropdown should have '([^']*)' selected")]
        public async Task ThenTheInterfaceSelectDropdownShouldHaveSelected(string expectedOption)
        {
            var value = await _page.InputValueAsync("#preferred-interface");
            value.Should().Be(expectedOption);
        }

        [When(@"I fill the comments with '([^']*)'")]
        public async Task WhenIFillTheCommentsWith(string comments)
        {
            await _page.FillAsync("#comments", comments);
        }

        [Then(@"the comments should contain '([^']*)'")]
        public async Task ThenTheCommentsShouldContain(string expectedComments)
        {
            var value = await _page.InputValueAsync("#comments");
            value.Should().Be(expectedComments);
        }
    }
}
