using Newtonsoft.Json;
using RestSharp;

namespace Space
{
    internal class Program
    {
        static readonly string Space_URL = "http://api.open-notify.org/iss-now.json";
        static void Main(string[] args)
        {
            var client = new RestClient(Space_URL);
            var request = new RestRequest();
            var response = client.Execute(request);
            if (!string.IsNullOrWhiteSpace(response.Content))
            {
                string receivedJSON = response.Content;
                SpacePosition? issPosition = JsonConvert.DeserializeObject<SpacePosition>(receivedJSON);

                Console.WriteLine(issPosition?.message);
                Console.WriteLine(issPosition?.timestamp);
                Console.WriteLine(issPosition?.iss_position.latitude);
                Console.WriteLine(issPosition?.iss_position.longitude);
            }
        }
    }


    public class SpacePosition
    {
        public int timestamp { get; set; }
        public string message { get; set; }
        public Iss_Position iss_position { get; set; }
    }

    public class Iss_Position
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

}
