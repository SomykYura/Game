using SportsCarTuningSimulator.BLL.Models;
using SportsCarTuningSimulator.BLL.Services;
#nullable disable

namespace SportsCarTuningSimulator.Tests.Services
{
    [TestClass]
    public class GameTests
    {
        private Game _game;
        private Player _player;
        private List<Player> _rivals;

        [TestInitialize]
        public void Setup()
        {
            _player = new Player(1, "Player1", 0, Car.CreateStandardCar());
            _rivals = new List<Player>
            {
                new(2, "Rival1", 0, Car.CreateStandardCar()),
                new(3, "Rival2", 0, Car.CreateStandardCar()),
                new(4, "Rival3", 0, Car.CreateStandardCar())
            };
            _game = new Game(_player, _rivals.Count);
        }

        [TestMethod]
        public void StartRace_FirstRace_ResultTableReturned()
        {
            var result = _game.StartRace();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetRacesResults_AllRacesCompleted_ResultTextReturned()
        {
            RunAllRaces();

            var result = _game.GetRacesResults();

            Assert.IsNotNull(result);
        }

        private void RunAllRaces()
        {
            for (int i = 0; i < 5; i++)
            {
                _game.StartRace();
            }
        }
    }
}