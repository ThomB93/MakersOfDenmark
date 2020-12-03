Feature: Returning events with a specific user
	As a consumer of the MakersOfDenmark API
	I want to be able to see my previously attended events
	So I can use this information to determine future participation
	

Scenario: An existing user yields the right HTTP status code
    Given the userId 
    When I request the locations corresponding to these codes
    Then the response has status code 200