using System.Data;
using System.Text.Json;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Space
{
    internal class Program
    {

        static Timer UpdateTimer = new Timer(5000);
        static readonly string PositionsFile = "SpacePositions.json";
        static readonly string AstronautsFile = "CurrentAstronauts.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Checking for current astronauts in space");
            CheckAstronauts();
           
            Console.WriteLine("Checking Position every 5 seconds(ish).");
            UpdateTimer.Elapsed += UpdateISSPosition;
            UpdateTimer.Enabled = true;

            Console.ReadLine();
        }

        private static void UpdateISSPosition(object sender, ElapsedEventArgs e)
        {
            SpacePosition? currentISSPositon = SpaceService.GetCurrentISSPosition();
            if (currentISSPositon != null)
            {
                string positionJSON = JsonSerializer.Serialize(currentISSPositon) + "\n";
                File.AppendAllText(PositionsFile, positionJSON);
                Console.WriteLine(currentISSPositon);
            }
        }
        
        private static void CheckAstronauts()
        {
            Astronauts? currentAstronauts = SpaceService.GetCurrentAstronautsInSpace();
            if (currentAstronauts != null)
            {
                File.WriteAllText(AstronautsFile, currentAstronauts.ToString());
                Console.WriteLine(currentAstronauts);
            }
        }
    }

    class TimerState
    {
        public int Counter;
    }
    

}
