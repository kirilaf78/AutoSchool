Feature: AlertsFrameAndWindows

Background:
	Given User enters URL
	And User clicks Alerts, Frame and Windows icon



Scenario: Clicking New Tab button
	Given User click Browser Windows
	When User click New Tab button
	Then 'This is a sample page' is displayed in new tab

Scenario: Clicking New Window button
	Given Browser Windows was clicked
	When User click New Window button
	Then 'This is a sample page' is displayed in new window
