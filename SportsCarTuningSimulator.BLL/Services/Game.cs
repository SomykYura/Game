using SportsCarTuningSimulator.BLL.Models;

namespace SportsCarTuningSimulator.BLL.Services
{
    public class Game
    {
        private readonly GrandPrix _grandPrixes;
        private Player _player;
        private List<Player> _rivals;
        private Shop _shop;

        public Game(Player player, int rivalsCount)
        {
            _player = player;
            _rivals = Player.GeneratePlayers(rivalsCount);
            _shop = new Shop();
            _grandPrixes = InitializeRaces();
            BuyRandomCompetitorDetails();
        }

        public string StartRace()
        {
            var incompleteRace = _grandPrixes.Races.FirstOrDefault(race => !race.IsCompleted);
            if (incompleteRace != null)
            {
                incompleteRace.RunRace();
                BuyRandomCompetitorDetails();

                return incompleteRace.GetResultsTable();
            }
            else
            {
                return GetResultsTable();
            }
        }

        private void BuyRandomCompetitorDetails()
        {
            _rivals.ForEach(player => _shop.BuyRandomDetail(player));
        }

        public string GetRacesResults()
        {
            var resultText = string.Empty;
            foreach (var race in _grandPrixes.Races)
            {
                resultText += $"{race.GetResultsTable()}\n";
            }

            return resultText;
        }

        public void Restart()
        {
            _player = Player.GeneratePlayer(_player.Name);
            _rivals = Player.GeneratePlayers(_rivals.Count);
            _shop = new Shop();
            _grandPrixes.Reset();
        }

        public Shop GetShop()
        {
            return _shop;
        }

        public Player GetCurrentPlayer()
        {
            return _player;
        }

        private string GetResultsTable()
        {
            var resultText = $"Grand pri results:\n" +
                "|   Player   | Position |\n" +
                "|------------|----------|\n";

            var playersResults = new Dictionary<string, int>();
            foreach (var player in GetPlayers())
            {
                var sumPositions = _grandPrixes.Races.Sum(race => race.GetResults().Single(result => result.Key == player.Id).Value);

                playersResults.Add(player.Name, sumPositions);
            }

            var results = playersResults.OrderBy(result => result.Value);
            for (int i = 1; i <= playersResults.Count; i++)
            {
                var result = results.ToArray()[i - 1];

                resultText += $"| {result.Key, -10} | {i, -10} |\n";
            }

            return resultText;
        }

        private GrandPrix InitializeRaces()
        {
            var players = GetPlayers();
            var grandPrix = new GrandPrix();
            grandPrix.AddRace(new Race("Race 1", new Track("Nürburgring"), players));
            grandPrix.AddRace(new Race("Race 2", new Track("Mosport Park"), players));
            grandPrix.AddRace(new Race("Race 3", new Track("Nivelles-Baulers"), players));
            grandPrix.AddRace(new Race("Race 4", new Track("Rouen-Les-Essarts"), players));
            grandPrix.AddRace(new Race("Race 5", new Track("Sebring Raceway"), players));

            return grandPrix;
        }

        private List<Player> GetPlayers()
        {
            var playerList = new List<Player> { _player };
            playerList.AddRange(_rivals);

            return playerList;
        }
    }
}