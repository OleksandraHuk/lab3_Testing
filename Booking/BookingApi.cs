using RestSharp;

namespace lab3_Testing.Booking
{
    public class BookingApi
    {
        private RestClient client;
        private string baseUrl = "https://restful-booker.herokuapp.com/booking";

        public BookingApi()
        {
            client = new RestClient(baseUrl);
        }

        public RestResponse UpdateBooking(object bookingData, int id)
        {
            var request = new RestRequest($"{baseUrl}/{id}", Method.Put);
            request.AddJsonBody(bookingData);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");

            return client.Execute(request);
        }

        public RestResponse DeleteBooking(int id)
        {
            var request = new RestRequest($"{baseUrl}/{id}", Method.Delete);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");

            return client.Execute(request);
        }
    }
}
