Feature: TestFeature

Scenario Outline: Add two numbers
	Given I have entered firstNumber into the calculator
	And I have also entered secondNumber into the calculator
	When I press add
	Then the result should be sum on the screen

Scenarios:
		| description | firstNumber | secondNumber | sum |
		| 1 plus 2    | 1           | 2            | 3   |