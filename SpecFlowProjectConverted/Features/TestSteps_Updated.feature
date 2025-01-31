Feature: TestSteps Updated

  Scenario: Navigate to TestCafe example page
    Given I navigate to the TestCafe example page

  Scenario: Type the name 'Peter' in the name input
    When I type the name 'Peter' in the name input

  Scenario: Replace the name with 'Parker'
    When I replace the name with 'Parker'

  Scenario: Verify the name input value is 'Parker'
    Then the name input should have the value 'Parker'
