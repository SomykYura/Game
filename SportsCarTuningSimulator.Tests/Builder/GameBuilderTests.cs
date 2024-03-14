using SportsCarTuningSimulator.BLL.Builders;
using SportsCarTuningSimulator.BLL.Models;

namespace SportsCarTuningSimulator.Tests.Builder
{
    [TestClass]
    public class GameBuilderTests
    {
        [TestMethod]
        public void Build_NoPlayerProvided_ThrowsException()
        {
            var gameBuilder = new GameBuilder();

            Assert.ThrowsException<InvalidOperationException>(() => gameBuilder.Build());
        }

        [TestMethod]
        public void Build_ZeroRivalsCount_ThrowsException()
        {
            var gameBuilder = new GameBuilder().WithPlayer(new Player(1, "Test Player", 0, Car.CreateStandardCar()));

            Assert.ThrowsException<InvalidOperationException>(() => gameBuilder.Build());
        }

        [TestMethod]
        public void Build_ValidInputs_CreatesGame()
        {
            var player = new Player(1, "Test Player", 0, Car.CreateStandardCar());
            int rivalsCount = 3;
            var gameBuilder = new GameBuilder().WithPlayer(player).WithRivalsCount(rivalsCount);

            var game = gameBuilder.Build();

            Assert.IsNotNull(game);
        }
    }
}