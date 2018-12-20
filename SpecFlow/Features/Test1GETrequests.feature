Feature: Test1GETrequests


@GetRequestPositive
Scenario: GET call positive scenario: status code 200
	Given I build a good Endpoint for GET call
	When I make a good GET request
	Then I receive a 200 status code for a GET call


@GetRequestNegative
Scenario: GET call negative scenario: status code 400 Bad Request
	Given I build a good Endpoint for a GET call
	When I make a bad GET request
	Then I receive a 400 status code for a GET call

@GetRequestNegative
Scenario: GET call negative scenario: status code 401 Unauthorized
	Given I build a bad Endpoint for a GET call
	When I make a good GET request
	Then I receive a 401 bad status code for a GET call






