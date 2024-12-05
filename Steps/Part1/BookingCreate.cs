using Newtonsoft.Json;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using lab3_Testing.Booking;
using NUnit.Framework.Legacy;

namespace lab3_Testing.Steps.Part1
{
    [Binding]
    public class BookingCreate
    {
        private RestClient client;
        private RestRequest request;
        private RestResponse response;
        private string baseUrl = "https://restful-booker.herokuapp.com/booking";
        private Details booking;

        [Given(@"I have the following booking details")]
        public void GivenIHaveTheFollowingBookingDetails(Table table)
        {
            booking = table.CreateInstance<Details>();
            booking.bookingdates = table.CreateInstance<Dates>();
            client = new RestClient(baseUrl);
            request = new RestRequest(baseUrl, Method.Post);
            request.AddJsonBody(booking);
            request.AddHeader("Accept", "application/json");
        }

        [When(@"I send a POST request to create a booking")]
        public void WhenISendAPOSTRequestToCreateABooking()
        {
            response = client.Execute(request);
        }

        [Then(@"the response should have a booking ID and the correct booking details")]
        public void ThenTheResponseShouldHaveABookingIDAndTheCorrectBookingDetails()
        {
            var createdBooking = JsonConvert.DeserializeObject<Response>(response.Content);
            ClassicAssert.IsNotNull(createdBooking.bookingid);
            Assert.That(booking.firstname, Is.EqualTo(createdBooking.booking.firstname));
        }
    }
}