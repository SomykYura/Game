using SportsCarTuningSimulator.BLL.Models;

namespace SportsCarTuningSimulator.BLL.Races
{
    public class Race
    {
        public string Name { get; set; }
        public Track RaceTrack { get; set; }
        public List<Player> Participants { get; set; }
        public bool IsCompleted { get { return _results.Count != 0; } }
        // Створи окремий клас результату (playerId, position, points)
        private Dictionary<int, int> _results = new Dictionary<int, int>();

        public Race(string name, Track raceTrack, List<Player> players)
        {
            Name = name;
            RaceTrack = raceTrack;
            Participants = players;
        }

        public void RunRace()
        {
            var maxHorsepower = Participants.Max(player => player.Car.Horsepower);
            foreach (var player in Participants)
            {
                player.Luck = new Random().Next(0, player.Car.Horsepower + 1) * 100 / maxHorsepower;
            }

            var sortedPlayers = Participants.OrderByDescending(player => player.Car.Horsepower)
                .ThenByDescending(player => player.Luck)
                .ToList();

            for (int i = 0; i < sortedPlayers.Count; i++)
            {
                _results.Add(sortedPlayers[i].Id, i + 1);
            }

            foreach (var participant in Participants)
            {
                participant.Money += CalculatePrizeMoney(_results.Single(result => result.Key == participant.Id).Value);
            }

            DisplayResults();
            // нарахуй очки гравцям, якщо без очків визначай на основі списку позицій (Чим менше середнє тим краще і місце ближче до переможця)
        }

        public void DisplayResults()
        {
            Console.WriteLine($"Результати гонки '{RaceTrack.Name}':");
            Console.WriteLine("| Учасник | Місце |");
            Console.WriteLine("|------------|-------|");

            foreach (var result in _results)
            {
                Console.WriteLine($"| {Participants.First(player => player.Id == result.Key).Name, -11} | {result.Value, -5} |");
            }
        }

        private int CalculatePrizeMoney(int position)
        {
            return position switch
            {
                1 => 3000,
                2 => 2000,
                3 => 1000,
                4 => 800,
                5 => 500,
                _ => 100,
            };
        }

        private int CalculatePrizePoints(int position)
        {
            return position switch
            {
                1 => 3,
                2 => 2,
                3 => 1,
                _ => 0
            };
        }
    }
}