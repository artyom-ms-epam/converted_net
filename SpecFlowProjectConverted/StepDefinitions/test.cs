using System;
using TechTalk.SpecFlow;
using FluentAssertions;
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

        [Given(@"I navigate to the example page")]
        public async Task GivenINavigateToTheExamplePage()
        {
            await _page.GotoAsync("https://devexpress.github.io/testcafe/example/");
        }

        [When(@"I type the name Peter Parker")]
        public async Task WhenITypeTheNamePeterParker()
        {
            await _page.FillAsync("#developer-name", "Peter Parker");
        }

        [Then(@"the name field should contain Peter Parker")]
        public async Task ThenTheNameFieldShouldContainPeterParker()
        {
            var value = await _page.InputValueAsync("#developer-name");
            value.Should().Be("Peter Parker");
        }

        [When(@"I click the labels and check their states")]
        public async Task WhenIClickTheLabelsAndCheckTheirStates()
        {
            var labels = await _page.QuerySelectorAllAsync("label");
            foreach (var label in labels)
            {
                await label.ClickAsync();
                var checkbox = await label.QuerySelectorAsync("input[type='checkbox']");
                (await checkbox.IsCheckedAsync()).Should().BeTrue();
            }
        }

        [When(@"I type and edit text using the keyboard")]
        public async Task WhenITypeAndEditTextUsingTheKeyboard()
        {
            await _page.FillAsync("#developer-name", "Peter Parker");
            await _page.ClickAsync("#developer-name", new ClickOptions { Position = new Position { X = 5, Y = 0 } });
            await _page.PressAsync("#developer-name", "Backspace");
            var value = await _page.InputValueAsync("#developer-name");
            value.Should().Be("Pete Parker");
            await _page.PressAsync("#developer-name", "Home Right . Delete Delete Delete");
            value = await _page.InputValueAsync("#developer-name");
            value.Should().Be("P. Parker");
        }

        [When(@"I move the slider")]
        public async Task WhenIMoveTheSlider()
        {
            var initialOffset = await _page.EvaluateAsync<int>("document.querySelector('#slider').offsetLeft");
            await _page.ClickAsync("#tried-test-cafe");
            await _page.DragAndDropAsync("#slider", "#slider + span");
            var newOffset = await _page.EvaluateAsync<int>("document.querySelector('#slider').offsetLeft");
            newOffset.Should().BeGreaterThan(initialOffset);
        }

        [When(@"I select text and delete it")]
        public async Task WhenISelectTextAndDeleteIt()
        {
            await _page.FillAsync("#developer-name", "Test Cafe");
            await _page.SelectTextAsync("#developer-name", new SelectTextOptions { Start = 7, End = 1 });
            await _page.PressAsync("#developer-name", "Delete");
            var value = await _page.InputValueAsync("#developer-name");
            value.Should().Be("Tfe");
        }

        [When(@"I handle native confirmation dialog")]
        public async Task WhenIHandleNativeConfirmationDialog()
        {
            _page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            await _page.ClickAsync("#populate");
            var dialogHistory = await _page.EvaluateAsync<string[]>("window.dialogHistory");
            dialogHistory[0].Should().Be("Reset information before proceeding?");
            await _page.ClickAsync("#submit-button");
            var resultText = await _page.InnerTextAsync("#article-header");
            resultText.Should().Contain("Peter Parker");
        }

        [When(@"I pick an option from the select menu")]
        public async Task WhenIPickAnOptionFromTheSelectMenu()
        {
            await _page.ClickAsync("#preferred-interface");
            await _page.ClickAsync("#preferred-interface option[value='Both']");
            var value = await _page.InputValueAsync("#preferred-interface");
            value.Should().Be("Both");
        }

        [When(@"I fill out the form")]
        public async Task WhenIFillOutTheForm()
        {
            await _page.FillAsync("#developer-name", "Bruce Wayne");
            await _page.ClickAsync("#macos");
            await _page.ClickAsync("#tried-test-cafe");
            await _page.FillAsync("#comments", "It's...");
            await Task.Delay(500);
            await _page.FillAsync("#comments", "It's...
good");
            await Task.Delay(500);
            await _page.SelectTextAsync("#comments", new SelectTextOptions { Start = 1, End = 0 });
            await _page.PressAsync("#comments", "Delete");
            await _page.FillAsync("#comments", "awesome!!!");
            await Task.Delay(500);
            await _page.ClickAsync("#submit-button");
            var resultText = await _page.InnerTextAsync("#article-header");
            resultText.Should().Contain("Bruce Wayne");
        }
    }
}