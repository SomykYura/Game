using SportsCarTuningSimulator.BLL.Models;
using SportsCarTuningSimulator.BLL.Services;

namespace SportsCarTuningSimulator.BLL.Facades
{
    public class GameFacade
    {
        private readonly Game _game;

        public GameFacade(Game game)
        {
            _game = game;
        }

        public Player GetCurrentPlayer() => _game.GetCurrentPlayer();
        public Shop GetShop() => _game.GetShop();
        public string StartRace() => _game.StartRace();
        public string GetRacesResults() => _game.GetRacesResults();
        public void RestartGame() => _game.Restart();
    }
}