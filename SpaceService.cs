using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space
{
    public class SpaceService
    {
        static readonly string SpaceURL = "http://api.open-notify.org/";
        static readonly string ISSURL = SpaceURL + "iss-now.json";
        static readonly string AstronautsURL = SpaceURL + "astros.json";

        public static SpacePosition? GetCurrentISSPosition()
        {
            var client = new RestClient(ISSURL);
            var request = new RestRequest();
            var response = client.Execute(request);
            if (!string.IsNullOrWhiteSpace(response.Content))
            {
                string receivedJSON = response.Content;
                SpacePosition? issPosition = JsonConvert.DeserializeObject<SpacePosition>(receivedJSON);
                return issPosition;
            }
            return null;
        }

        public static Astronauts? GetCurrentAstronautsInSpace()
        {
            var client = new RestClient(AstronautsURL);
            var request = new RestRequest();
            var response = client.Execute(request);
            if (!string.IsNullOrWhiteSpace(response.Content))
            {
                string receivedJSON = response.Content;
                Astronauts? currentAstronauts = JsonConvert.DeserializeObject<Astronauts>(receivedJSON);
                return currentAstronauts;
            }
            return null;
        }
    }
}
