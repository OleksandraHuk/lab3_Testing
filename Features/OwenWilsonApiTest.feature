Feature: GeoLocation API

  In order to obtain the country information of a user
  As an application that requires geolocation
  I want to query the GeoLocation API with an IP address

  Scenario: Query GeoLocation API with a valid IPv4 address
    Given I have a valid IPv4 address '46.211.9.101'
    When I query the GeoLocation API
    Then I should receive the country code 'UA'

  Scenario: Query GeoLocation API with a US-based IPv4 address
    Given  I have a valid IPv4 address '8.8.8.8'
    When I query the GeoLocation API
    Then I should receive the country code 'US'

  Scenario: Query GeoLocation API with a Germany-based IPv4 address
    Given I have a valid IPv4 address '78.46.94.13'
    When I query the GeoLocation API
    Then I should receive the country code 'DE'

  Scenario: Query GeoLocation API with a Japan-based IPv4 address
    Given I have a valid IPv4 address '160.16.213.210'
    When I query the GeoLocation API
    Then I should receive the country code 'JP'

  Scenario: Query GeoLocation API with a non-existent IPv4 address
    Given I have a valid IPv4 address '0.0.0.0'
    When I query the GeoLocation API
    Then I should receive an error response