Feature: Email Feature

Background:
	Given I login to mail.ru

Scenario: Message move to spam
	Given I mark message as spam
	When I navigate to spam folder
	Then The message should be in spam

Scenario: Flag message
	Given I get inbox messages
	When I toggle message flag
	When I navigate to flaged messages folder
	Then The message should be in flag folder
	When I toggle message flag
	Then The message should not be in flag folder

Scenario: Sent message several users
	Given I entered message data
	When I send the message
	Then Message notification should appear
	When I navigate to sent messages folder
	Then The message should be in sent messages folder