using Newtonsoft.Json;
using RestSharp;

namespace lab3_Testing.Booking
{
    internal class Creation
    {
        private RestClient client;
        private RestRequest request;
        private string baseUrl = "https://restful-booker.herokuapp.com/booking";
        private Details booking = new Details
        {
            firstname = "Jim",
            lastname = "Brown",
            totalprice = 111,
            depositpaid = true,
            bookingdates = new Dates
            {
                checkin = "2018-01-01",
                checkout = "2019-01-01"
            }
        };

        public int Create()
        {
            client = new RestClient(baseUrl);
            request = new RestRequest(baseUrl, Method.Post);
            request.AddJsonBody(booking);
            request.AddHeader("Accept", "application/json");
            string jsonResponse = client.Execute(request).Content;
            Response bookingResponse = JsonConvert.DeserializeObject<Response>(jsonResponse);
            int id = bookingResponse.bookingid;
            return id;
        }
    }
}
