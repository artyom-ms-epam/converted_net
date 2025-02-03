namespace SpecFlowProjectConverted.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            // Implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            // Example implementation
            ScenarioContext.Current["firstNumber"] = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            // Implement arrange (precondition) logic

            // Example implementation
            ScenarioContext.Current["secondNumber"] = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            // Implement act (action) logic

            // Example implementation
            var firstNumber = ScenarioContext.Current["firstNumber"];
            var secondNumber = ScenarioContext.Current["secondNumber"];
            ScenarioContext.Current["result"] = firstNumber + secondNumber;
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            // Implement assert (verification) logic

            // Example implementation
            var actualResult = ScenarioContext.Current["result"];
            if (actualResult != result)
            {
                throw new Exception($"Expected {result} but got {actualResult}");
            }
        }
    }
}
