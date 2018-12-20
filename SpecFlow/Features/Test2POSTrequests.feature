Feature: Test2POSTrequests


@PostRequestPositive
Scenario: POST call positive scenario
	Given I build a good Endpoint for a POST call
	When I make a good POST request
	Then I receive a 201 status code for a POST call

@PostRequestNegative
Scenario: POST call negative scenario: status code 400 Bad Request
	Given I build a good Endpoint for a POST call
	When I make a bad POST request
	Then I receive a 400 status code for a POST call

	@PostRequestNegative
Scenario: POST call negative scenario: status code 401 Bad Request
	Given I build a bad Endpoint for a POST call
	When I make a good POST request
	Then I receive a 401 status code for a POST call