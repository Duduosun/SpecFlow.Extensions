@web
Feature: TestSlowGrid
	As a user
	I want to interact with grids that contain large data sets
	So that I know the framework can handle slow grids

Scenario: Test Slow Grid Search
	Given I go to the test slow grid search page
	Given I generate 1 million records
	When I search for 'Sue'
	Then there are 46
