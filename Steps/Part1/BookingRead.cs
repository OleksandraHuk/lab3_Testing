using Newtonsoft.Json;
using NUnit.Framework.Legacy;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace lab3_Testing.Steps.Part1
{
    [Binding]
    public class BookingRead
    {
        private RestClient client;
        private RestRequest request;
        private RestResponse response;

        [Given(@"I want to retrieve a list of booking IDs")]
        public void GivenIWantToRetrieveAListOfBookingIDs()
        {
            client = new RestClient("https://restful-booker.herokuapp.com/");
            request = new RestRequest("booking", Method.Get);
        }

        [When(@"I send a GET request to ""(.*)""")]
        public void WhenISendAGETRequestTo(string resource)
        {
            response = client.Execute(request);
        }

        [Then(@"I should receive a response with status code 200")]
        public void ThenIShouldReceiveAResponseWithStatusCode()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Then(@"I should receive a list of booking IDs")]
        public void ThenIShouldReceiveAListOfBookingIDs()
        {
            var bookings = JsonConvert.DeserializeObject<List<Dictionary<string, int>>>(response.Content);
            ClassicAssert.IsNotNull(bookings);
            ClassicAssert.IsTrue(bookings.All(b => b.ContainsKey("bookingid")));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}