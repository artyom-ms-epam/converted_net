Feature: Test Updated

  Scenario: Navigate to the example page and type a name
    Given I navigate to the example page
    When I type the name 'Peter' in the input field
    When I replace the name with 'Parker'
    Then the input field should contain 'Parker'
