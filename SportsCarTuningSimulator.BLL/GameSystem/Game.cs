using SportsCarTuningSimulator.BLL.Models;
using SportsCarTuningSimulator.BLL.Races;

namespace SportsCarTuningSimulator.BLL.GameSystem
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

        public void StartRace()
        {
            var incompleteRace = _grandPrixes.Races.FirstOrDefault(race => !race.IsCompleted);
            if (incompleteRace != null)
            {
                incompleteRace.RunRace();
                BuyRandomCompetitorDetails();
            }
            else
            {
                PrintResults();
            }
        }

        private void BuyRandomCompetitorDetails()
        {
            _rivals.ForEach(player => _shop.BuyRandomDetail(player));
        }

        public void PrintResults()
        {
            foreach (var race in _grandPrixes.Races)
            {
                race.DisplayResults();
            }
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