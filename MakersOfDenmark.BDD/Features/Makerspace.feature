Feature: Makerspace
	In order to be sure a makerspace is created
	I want to create a makerspace and get it for validation

@mytag
Scenario: Create a makerspace
	Given the makerspacename test-makerspace
	Then I want to create a makerspace
	Then the name should be test-makerspace