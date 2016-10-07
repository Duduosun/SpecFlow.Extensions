@web_max
@online
Feature: Test Table Collapse
	As a user
	I want to expand and collapse a table
	So that I know the framework can interact with changing elements

Scenario: Test Table Collapse
	Given I go to the table collapse page
	When I collapse the table
	Then I do not fail when I select a row

Scenario: Test Table Collapse Left Nav Menu
	Given I go to the table collapse page
	When I repeatly collapse the left nav menu