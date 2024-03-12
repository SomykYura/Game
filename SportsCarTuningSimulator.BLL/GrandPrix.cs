using SportsCarTuningSimulator.BLL.Races;

namespace SportsCarTuningSimulator.BLL
{
    public class GrandPrix
    {
        public string Name { get; set; }
        public List<Race> Races { get; private set; }

        public GrandPrix(string name)
        {
            Races = new List<Race>();
            Name = name;
        }

        public void AddRace(Race race)
        {
            Races.Add(race);
        }

        public void DisplayRaces()
        {
            Console.WriteLine("Список гонок:");
            foreach (var race in Races)
            {
                Console.WriteLine($"Назва: {race.Name}");
            }
        }
    }
}