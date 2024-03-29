﻿namespace SportsCarTuningSimulator.BLL.Models
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

        public string GetResultsTable()
        {
            var resultText = $"Race results for '{RaceTrack.Name}':\n" +
                    "| Participant | Position | Prize Money |\n" +
                    "|-------------|----------|------------|\n";
            foreach (var result in _results.OrderBy(x => x.Value))
            {
                var participant = Participants.First(player => player.Id == result.Key);

                resultText += $"| {participant.Name,-12} | {result.Value,-8} | {CalculatePrizeMoney(result.Value),-11} |\n";
            }

            return resultText;
        }

        public Dictionary<int, int> GetResults()
        {
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