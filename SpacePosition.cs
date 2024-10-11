using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space
{
    public class SpacePosition
    {
        public int timestamp { get; set; }
        public string message { get; set; }
        public Iss_Position iss_position { get; set; }

        public override string ToString()
        {
            DateTime time = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime;
            return $"{message}, {time}, {iss_position}";
        }
    }

    public class Iss_Position
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public override string ToString()
        {
            return $"Lat: {latitude}, Lon: {longitude}";
        }
    }


    public class Astronauts
    {
        public Person[] people { get; set; }
        public int number { get; set; }
        public string message { get; set; }
        public override string ToString()
        {
            string display = $"{message}. There are {number} people in space.\n";
            foreach (Person person in people)
            {
                display += person.ToString();
            }
            return display;
        }
    }

    public class Person
    {
        public string craft { get; set; }
        public string name { get; set; }
        public override string ToString()
        {
            return $"{name}, on craft {craft};";
        }
    }

}
