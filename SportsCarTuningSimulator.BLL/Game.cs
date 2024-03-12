using SportsCarTuningSimulator.BLL.Models;
using SportsCarTuningSimulator.BLL.Races;

namespace SportsCarTuningSimulator.BLL
{
    public class Game
    {
        public GrandPrix _grandPrixes = new GrandPrix("Гранд прі Україна");
        public readonly Player _player;
        public readonly List<Player> _rivals;
        public readonly Shop _shop;

        public Game(Player player, int rivalsCount)
        {
            _player = player;
            _rivals = Player.GeneratePlayers(rivalsCount).ToList();
            var _players = GetPlayers();
            _shop = new Shop();

            _grandPrixes.AddRace(new Race("Race 1", new Track("Nürburgring"), _players));
            _grandPrixes.AddRace(new Race("Race 2", new Track("Mosport Park"), _players));
            _grandPrixes.AddRace(new Race("Race 3", new Track("Nivelles-Baulers"), _players));
            _grandPrixes.AddRace(new Race("Race 4", new Track("Rouen-Les-Essarts"), _players));
            _grandPrixes.AddRace(new Race("Race 5", new Track("Sebring Raceway"), _players));

            BuyRandomCompetitorDetails();
        }

        public List<Player> GetPlayers() 
        {
            var playerList = new List<Player>() { _player }; 
            playerList.AddRange(_rivals);

            return playerList;
        }

        public void StartRace()
        {
            if (_grandPrixes.Races.Any(race => !race.IsCompleted))
            {
                _grandPrixes.Races.First(race => !race.IsCompleted).RunRace();
                BuyRandomCompetitorDetails();
            }
            else
            {
                PrintResults();
            }
        }

        // Можливо потрібно буде купляти на всі бабки тобто декілька деталей
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
    }
}