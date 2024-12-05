using Newtonsoft.Json;
using RestSharp;
using TechTalk.SpecFlow;
using lab3_Testing.Booking;
using System.Net;

namespace lab3_Testing.Steps.Part1
{
    [Binding]
    public class BookingUpdate
    {
        private BookingApi bookingApi;
        private RestResponse response;
        private Details bookingData;

        public int id;
        public BookingUpdate()
        {
            bookingApi = new BookingApi();
            response = new RestResponse();
        }

        [Given(@"Create booking for updating")]
        public void GivenCreateBookingForUpdating()
        {
            Creation c = new Creation();
            id = c.Create();
        }

        [Given(@"I have valid booking details")]
        public void GivenIHaveValidBookingDetails()
        {
            bookingData = new Details
            {
                firstname = "James",
                lastname = "Brown",
                totalprice = 111,
                depositpaid = true,
                bookingdates = new Dates
                {
                    checkin = "2018-01-01",
                    checkout = "2019-01-01"
                }
            };
        }

        [When(@"I send a PUT request to update the booking")]
        public void WhenISendAPUTRequestToUpdateTheBooking()
        {
            response = bookingApi.UpdateBooking(bookingData, id);
        }

        [Then(@"the booking should be updated with the new details")]
        public void ThenTheBookingShouldBeUpdatedWithTheNewDetails()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Console.WriteLine("Response Content: " + response.Content);
            var updatedBooking = JsonConvert.DeserializeObject<Details>(response.Content);
            Assert.That(bookingData.firstname, Is.EqualTo(updatedBooking.firstname));
            Assert.That(bookingData.lastname, Is.EqualTo(updatedBooking.lastname));
            Assert.That(bookingData.totalprice, Is.EqualTo(updatedBooking.totalprice));
            Assert.That(bookingData.depositpaid, Is.EqualTo(updatedBooking.depositpaid));
            Assert.That(bookingData.bookingdates.checkin, Is.EqualTo(updatedBooking.bookingdates.checkin));
            Assert.That(bookingData.bookingdates.checkout, Is.EqualTo(updatedBooking.bookingdates.checkout));
            Assert.That(bookingData.additionalneeds, Is.EqualTo(updatedBooking.additionalneeds));
        }
    }
}