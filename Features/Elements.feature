Feature: Elements


Background: User navigates to Elements page
When User enters URL
Then User clicks Elements icon


Scenario: Verifying Text Box feature
	When User clicks Text Box title
	Then User enters the following data in Text Box fields 
	| FieldData                     |
	| Viktor Gusev                  |
	| karage1625@bayxs.com          |
	| Lesi 22, Kiev, 34433, Ukraine |
	| The same as above             |
	When User clicks Submit button
	Then User verifies the following data is displayed in Table 
	| TableData                                      |
	| Name:Viktor Gusev                              |
	| Email:karage1625@bayxs.com					 |
	| Current Address :Lesi 22, Kiev, 34433, Ukraine |
	| Permananet Address :The same as above          |


  Scenario: Verify folder selection and output
    When User clicks Check Box title
	And User expands the folder Home
    And User selects the folder Desktop without expanding it
	And User expands Documents folder
	And User expands WorkSpace folder
	Then User selects Angular and Veu 
    When User expands the folder Office
    Then User clicks on each element in the Office folder one by one
    When User click toggle of the folder Downloads
    Then User clicks title of  Downloads folder (by clicking on its name)
    And the output should be "You have selected : desktop notes commands angular veu office public private classified general downloads wordFile excelFile"

Scenario: Verify Web Tables section
 When User clicks Web Tables title
 And User clicks Salary column 
 Then values in the column sorted in ascending order
 When User click Delete icon on the third row of the table
 Then Compliance are not displayed in Department column
