Feature: TestCafe Example Page

  Scenario: Navigate to TestCafe example page and type name
    Given I navigate to the TestCafe example page
    When I type the name 'Peter' into the name input
    Then the name input should contain 'Peter'