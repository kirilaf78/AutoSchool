Feature: Elements


Background:
	Given User enters URL
	And User clicks Elements icon

@TextBox
Scenario: Verifying Text Box section
	Given User clicks Text Box title
	When User enters the following data in Text Box fields
		| FieldData                     |
		| Viktor Gusev                  |
		| karage1625@bayxs.com          |
		| Lesi 22, Kiev, 34433, Ukraine |
		| The same as above             |
	And User clicks Submit button
	Then User verifies the following data is displayed in Table
		| TableData                                      |
		| Name:Viktor Gusev                              |
		| Email:karage1625@bayxs.com                     |
		| Current Address :Lesi 22, Kiev, 34433, Ukraine |
		| Permananet Address :The same as above          |

@CheckBox
Scenario: Verify folder selection and output of Check Box section
	Given User clicks Check Box title
	When User expands the folder Home
	And User selects the folder Desktop without expanding it
	And User expands Documents folder
	And User expands WorkSpace folder
	And User selects Angular and Veu
	And User expands the folder Office
	And User clicks on each element in the Office folder one by one
	And User click toggle of the folder Downloads
	And User clicks title of  Downloads folder (by clicking on its name)
	Then the output should be "You have selected : desktop notes commands angular veu office public private classified general downloads wordFile excelFile"

@WebTables1
Scenario: Verify Salary column of Web Tables section
	Given User navigates to Web Tables section
	When User clicks Salary column
	Then values in the column sorted in ascending order

@WebTables2
Scenario: Delete second row from Web Tables section and verify Compliance are not displayed
	Given User clicks Web Tables title
	When User click Delete icon on the second row of the table
	Then Compliance are not displayed in Department column

Scenario Outline: Clicking buttons and verifying messages
	Given User clicks Buttons
	When User clicks <buttonName> button
	Then "<text>" should be displayed
Examples:
	| buttonName      | text                          |
	| Double click me | You have done a double click  |
	| Right click me  | You have done a right click   |
	| Click me        | You have done a dynamic click |