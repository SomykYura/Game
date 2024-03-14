using SportsCarTuningSimulator.BLL.Models;

namespace SportsCarTuningSimulator.Tests.Models
{
    [TestClass]
    public class RaceTests
    {
        private readonly List<Player> _participants;

        public RaceTests()
        {
            _participants = new List<Player>
            {
                new(1, "Player 1", 0,
                    new Car("Car 1",
                        new Detail(1, "Engine", 100, 200, DetailClass.Basic, DetailType.Engine),
                        new Detail(2, "Transmission", 200, 150, DetailClass.Basic, DetailType.Transmission),
                        new Detail(2, "Chassis", 200, 150, DetailClass.Basic, DetailType.Chassis))
                    ),
                new(2, "Player 2", 0,
                    new Car("Car 2",
                        new Detail(3, "Engine", 200, 300, DetailClass.Basic, DetailType.Engine),
                        new Detail(4, "Transmission", 200, 150, DetailClass.Basic, DetailType.Transmission),
                        new Detail(2, "Chassis", 200, 150, DetailClass.Basic, DetailType.Chassis))),
                new(3, "Player 3", 0,
                    new Car("Car 3",
                        new Detail(5, "Engine", 300, 400, DetailClass.Basic, DetailType.Engine),
                        new Detail(6, "Transmission", 200, 150, DetailClass.Basic, DetailType.Transmission),
                        new Detail(2, "Chassis", 200, 150, DetailClass.Basic, DetailType.Chassis)))
            };
        }

        [TestMethod]
        public void RunRace_CalculatesResults()
        {
            var track = new Track("Test Track");
            var race = new Race("Test Race", track, _participants);

            race.RunRace();

            var results = race.GetResults();
            Assert.AreEqual(3, results.Count);
            Assert.IsTrue(results.ContainsKey(1));
            Assert.IsTrue(results.ContainsKey(2));
            Assert.IsTrue(results.ContainsKey(3));
        }

        [TestMethod]
        public void GetResultsTable_ReturnsCorrectFormat()
        {
            var track = new Track("Test Track");
            var race = new Race("Test Race", track, _participants);
            race.RunRace();

            string resultsTable = race.GetResultsTable();

            string[] lines = resultsTable.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(6, lines.Length);
        }

        [TestMethod]
        public void ClearResults_ClearsResults()
        {
            var track = new Track("Test Track");
            var race = new Race("Test Race", track, _participants);
            race.RunRace();

            race.ClearResults();

            Assert.AreEqual(0, race.GetResults().Count);
        }
    }
}