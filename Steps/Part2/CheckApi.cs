using Newtonsoft.Json;
using NUnit.Framework.Legacy;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace lab3_Testing.Steps.Part2
{
    [Binding]
    public class GeoLocationSteps
    {
        private readonly RestClient _client;
        private RestRequest _request;
        private RestResponse _response;

        public GeoLocationSteps()
        {
            _client = new RestClient("https://api.country.is/");
        }

        [Given(@"I have a valid IPv4 address '(.*)'")]
        public void GivenIHaveAValidIPvAddress(string ipv4Address)
        {
            _request = new RestRequest(ipv4Address);
        }

        [Given(@"I have a valid IPv6 address '(.*)'")]
        public void GivenIHaveAValidIPv6Address(string ipv6Address)
        {
            _request = new RestRequest(ipv6Address);
        }

        [When(@"I query the GeoLocation API")]
        public void WhenIQueryTheGeoLocationAPI()
        {
            _response = _client.Execute(_request);
        }

        [Then(@"I should receive the country code '(.*)'")]
        public void ThenIShouldReceiveTheCountryCode(string expectedCountryCode)
        {
            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(_response.Content);
            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(expectedCountryCode, result["country"]);
        }

        [Then(@"I should receive a valid country code")]
        public void ThenIShouldReceiveAValidCountryCode()
        {
            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(_response.Content);
            ClassicAssert.NotNull(result);
            ClassicAssert.IsTrue(result.ContainsKey("country"));
        }

        [Then(@"I should receive an error response")]
        public void ThenIShouldReceiveAnErrorResponse()
        {
            // Check if the response indicates an error. 
            // Depending on the API you might check for a specific status code, 
            // content message, or if the response is null.
            ClassicAssert.IsFalse(_response.IsSuccessful, "The response was successful but should have been an error.");
            Assert.That(_response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest)
                .Or.EqualTo(HttpStatusCode.NotFound)
                .Or.EqualTo(HttpStatusCode.InternalServerError), "The status code was not an expected error code.");
        }
    }
}