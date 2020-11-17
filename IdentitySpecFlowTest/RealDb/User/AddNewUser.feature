Feature: AddNewUser
Add new user as with user role

@mytag
Scenario: AddNewUser
	Given new user info
	|FirstName|LastName|PhoneNumber  |UserName|Email			   |NationalCode|BirthDate |Password|
	|FirstName|LastName|+983952888888|UserName|mehdi@4294@yahoo.com|1111111111	|1988/12/12|1		|

	When AddedNewUser
	Then Finish
