Feature: Factorial
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the factorial of the number

Scenario: Calculate factorial of positive integer
	Given I navigate to factorial calculator
	And enter 5 into the calculator
	When I click Calculate! button
	Then the result should be 120

Scenario: Calculate factorial of negative integer
	Given I navigate to factorial calculator
	And enter -5 into the calculator
	When I click Calculate! button
	Then the result should be 1

Scenario: Calculate factorial of zero
	Given I navigate to factorial calculator
	And enter 0 into the calculator
	When I click Calculate! button
	Then the result should be 1

Scenario: Validate input
	Given I navigate to factorial calculator
	And enter <Input> into the calculator
	When I click Calculate! button
	Then the <Validation message> should be displayed

	Examples:
	| Input         | Validation message                     |
	| jane@doe.com  | Please enter an integer                |
	| 2@            | Please enter an integer                |
	|               | Please enter an integer                |
	| 1.1           | Please enter an integer                |
	| 4e4e4         | Please enter an integer                |
	| .             | Please enter an integer                |
	| 172           | Please enter an integer lower than 171 |
