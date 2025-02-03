Feature: Test example page navigation and input

  Scenario: Navigate to example page and input name
    Given I navigate to the example page
    When I type 'Peter' into the name input
    And I replace it with 'Parker'
    Then the name input should contain 'Parker'
