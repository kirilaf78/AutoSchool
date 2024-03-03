Feature: Forms


Background:
	Given User types URL
	And User clicks Forms icon

Scenario: Verifying data in the modal
	Given User navigates to Practice Form section
	When User enters the following data
		| firstName | lastName | email          | mobileNumber | address              |
		| Sasha     | Usikova  | saus@gmail.com | 1445565729   | 20300, Uman, Ukraine |
	And User checks 'Female' radio button
	And User enters date of birth '2006'
	And User enters subjects Maths and Physics
	And User checks Reading and Music checkboxes
	And User selects Uttar Pradesh State and Merrut City
	And User clicks Submit button
	Then the following values are displayed in the modal
		| Values               |
		| Sasha Usikova        |
		| saus@gmail.com       |
		| Female               |
		| 1445565729           |
		| 06 March,1998        |
		| Maths, Physics       |
		| Reading, Music       |
		| 20300, Uman, Ukraine |
		| Uttar Pradesh Merrut |
