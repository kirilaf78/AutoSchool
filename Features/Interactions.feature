﻿Feature: Interactions

Background:
	Given User types URL
	And Widgets icon is clicked

Scenario: Verifying value of selected squares
    Given User navigates to Selectable section
	When User clicks Grid tab
	And User clicks  One, Three, Five, Seven and Nine
	Then value of selected squares is One, Three, Five, Seven and Nine