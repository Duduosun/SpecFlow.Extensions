@web
Feature: TestSlowSelect
	As a user
	I want to interact with a select element that contains many options
	So that I know the framework selects quickly

Scenario: Test Slow Select
	Given I go to the test select page
	When I select 'PASteelton'
	Then it took less than a second

Scenario: Test Slow Select NgOption
	Given I go to the test select ngOption page
	When I select 'PASteelton'
	Then it took less than a second
