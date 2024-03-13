using SportsCarTuningSimulator.BLL.Models;

namespace SportsCarTuningSimulator.BLL.Races
{
    public class Race
    {
        public string Name { get; }
        public Track RaceTrack { get; }
        public IReadOnlyList<Player> Participants { get; }
        public bool IsCompleted { get { return _results.Count != 0; } }

        private readonly Dictionary<int, int> _results = new();

        public Race(string name, Track raceTrack, IReadOnlyList<Player> participants)
        {
            Name = name;
            RaceTrack = raceTrack;
            Participants = participants;
        }

        public void RunRace()
        {
            var maxHorsepower = Participants.Max(player => player.Car.GetHorsepower());
            foreach (var player in Participants)
            {
                player.Luck = new Random().Next(0, player.Car.GetHorsepower() + 1) * 100 / maxHorsepower;
            }

            var sortedPlayers = Participants.OrderByDescending(player => player.Car.GetHorsepower())
                .ThenByDescending(player => player.Luck)
                .ToList();

            for (int i = 0; i < sortedPlayers.Count; i++)
            {
                _results.Add(sortedPlayers[i].Id, i + 1);
                sortedPlayers[i].Money += CalculatePrizeMoney(i + 1);
            }
        }

        public void DisplayResults()
        {
            Console.WriteLine($"Race Results for '{RaceTrack.Name}':");
            Console.WriteLine("| Participant | Position | Prize Money");
            Console.WriteLine("|-------------|----------|------------|");

            foreach (var result in _results)
            {
                var participant = Participants.First(player => player.Id == result.Key);
                Console.WriteLine($"| {participant.Name,-12} | {result.Value,-8} | {CalculatePrizeMoney(result.Value),-11} |");
            }
        }

        public Dictionary<int, int> GetResults()
        {
            if (_results.Count == 0)
            {
                throw new InvalidOperationException("Race results are not available yet.");
            }

            return new Dictionary<int, int>(_results);
        }

        public void ClearResults()
        {
            _results.Clear();
        }

        private static int CalculatePrizeMoney(int position)
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
    }
}