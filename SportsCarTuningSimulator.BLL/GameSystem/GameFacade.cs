using SportsCarTuningSimulator.BLL.Models;

namespace SportsCarTuningSimulator.BLL.GameSystem
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
        public void StartRace() => _game.StartRace();
        public void PrintResults() => _game.PrintResults();
        public void RestartGame() => _game.Restart();
    }
}