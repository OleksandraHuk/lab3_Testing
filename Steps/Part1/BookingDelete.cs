using System.Net;
using RestSharp;
using TechTalk.SpecFlow;
using lab3_Testing.Booking;

namespace lab3_Testing.Steps.Part1
{
    [Binding]
    public class BookingDelete
    {
        private BookingApi bookingApi;
        private RestResponse response;

        public int id;
        public BookingDelete()
        {
            bookingApi = new BookingApi();
            response = new RestResponse();
        }

        [Given(@"Create booking for deletion")]
        public void GivenCreateBookingForDeletion()
        {
            Creation c = new Creation();
            id = c.Create();
        }

        [When(@"I send a DELETE request to remove a booking")]
        public void WhenISendADELETERequestToRemoveABooking()
        {
            response = bookingApi.DeleteBooking(id);
        }

        [Then(@"the booking should be successfully deleted")]
        public void ThenTheBookingShouldBeSuccessfullyDeleted()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }
}