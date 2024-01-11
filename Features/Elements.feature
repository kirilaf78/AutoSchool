Feature: Elements


Background: User navigates to Elements page
Given User opens browser 
When User enters URL
And User clicks Elements icon
Then Elements page is displayed 

@TextBox
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


@CheckBox
  Scenario: Verify folder selection and output
    Given User expands the folder "Home"
    And User selects the folder "Desktop" without expanding it
    And User chooses "Angular" and "Veu" from the "WorkSpace" folder
    When User expands the folder "Office"
    Then User clicks on each element in the "Office" folder one by one
    When User click toggle of the folder "Downloads"
    Then User selects the entire "Downloads" folder (by clicking on its name)
    And the output should be "You have selected : desktop notes commands angular veu office public private classified general downloads wordFile excelFile"


