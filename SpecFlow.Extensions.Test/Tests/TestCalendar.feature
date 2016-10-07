@web
Feature: TestCalendar
	As a user
	I want to interact with a calendar web app
	So that I know the framework can handle modals that transition and switch

Scenario: Test Calendar Drop Down Month
	Given I go to the test calendar page
	When I select the mini calendar month drop down
	When I select a date in the mini calendar
	When I select the mini calendar month drop down

Scenario: Test Calendar Modal
	Given I go to the test calendar page
	When I add an event
	When I add an event

Scenario: Test Calendar Switch Modals
	Given I go to the test calendar page
	When I add a detailed event
	When I add a detailed event

Scenario: Test Calendar Page Refresh
	Given I go to the test calendar page
	When I select theme 'Neptune'
	When I select theme 'Classic'
