Feature: Booking CRUD operations

Scenario: Creating a new booking
  Given I have the following booking details
    | firstname | lastname | totalprice | depositpaid | checkin      | checkout     | additionalneeds |
    | Jim       | Brown    | 111        | true        | 2018-01-01   | 2019-01-01   | Breakfast       |
  When I send a POST request to create a booking
  Then the response should have a booking ID and the correct booking details

Scenario: Get a list of booking IDs
  Given I want to retrieve a list of booking IDs
  When I send a GET request to "/booking"
  Then I should receive a response with status code 200
  And I should receive a list of booking IDs

Scenario: Updating a booking with valid details
  Given Create booking for updating
  And I have valid booking details
  When I send a PUT request to update the booking
  Then the booking should be updated with the new details

Scenario: Deleting a booking
   Given Create booking for deletion
   When I send a DELETE request to remove a booking
   Then the booking should be successfully deleted
