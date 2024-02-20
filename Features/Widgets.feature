Feature: Widgets

Background:
	Given User enters URL
	And User clicks Widgets icon

Scenario: Verify Auto Complete suggestions after typing 'g'
    Given User navigates to Auto Complete section
    When User enters 'g' in the Type multiple color names field 
    Then There are three suggestions displayed with each containing the letter 'g'

Scenario: Verify remaining colors after adding and removing colors
    Given User navigates to Auto Complete section
    When User enters the colors: Red, Yellow, Green, Blue, and Purple
    And User removes Yellow and Purple
    Then Only Red, Green, and Blue are displayed in the field

Scenario: Verify Progress Bar functionality
    Given User navigates to Progress Bar section
    When User clicks on Start and waits for the progress to reach 100%
    Then The button label changes to Reset
    And User clicks on Reset
    Then The button label changes back to Start
    And The progress bar value is reset to 0%

