Feature: Test Feature

  Scenario: Navigate to TestCafe example page
    Given I navigate to the TestCafe example page

  Scenario: Type the name Peter
    When I type the name Peter

  Scenario: Replace the name with Parker
    When I replace the name with Parker

  Scenario: Correct the name to Parker
    When I correct the name to Parker
    Then the name should be Parker

  Scenario: Click all feature labels
    When I click all feature labels

  Scenario: Type the name Peter Parker and edit it using the keyboard
    When I type the name Peter Parker and edit it using the keyboard

  Scenario: Move the slider to 9
    When I move the slider to 9

  Scenario: Type Test Cafe and delete part of it using selection
    When I type Test Cafe and delete part of it using selection

  Scenario: Handle the native confirmation dialog
    When I handle the native confirmation dialog

  Scenario: Pick Both from the select dropdown
    When I pick Both from the select dropdown

  Scenario: Fill the form with Bruce Wayne's information
    When I fill the form with Bruce Wayne's information
