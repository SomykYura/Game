using SportsCarTuningSimulator.BLL.Models;

namespace SportsCarTuningSimulator.Tests.Models
{
    [TestClass]
    public class GrandPrixTests
    {
        [TestMethod]
        public void AddRace_AddsRaceToList()
        {
            var grandPrix = new GrandPrix();
            var race = new Race("Test Race", new Track("Test Track"), new List<Player>());

            grandPrix.AddRace(race);

            Assert.IsTrue(grandPrix.Races.Contains(race));
        }

        [TestMethod]
        public void AddRace_NullRace_ThrowsException()
        {
            var grandPrix = new GrandPrix();

            Assert.ThrowsException<ArgumentNullException>(() => grandPrix.AddRace(null));
        }

        [TestMethod]
        public void Reset_ClearsResultsOfAllRaces()
        {
            var grandPrix = new GrandPrix();
            var race1 = new Race("Test Race 1", new Track("Test Track 1"), Player.GeneratePlayers(1));
            var race2 = new Race("Test Race 2", new Track("Test Track 2"), Player.GeneratePlayers(1));
            grandPrix.AddRace(race1);
            grandPrix.AddRace(race2);
            race1.RunRace();
            race2.RunRace();

            grandPrix.Reset();

            foreach (var race in grandPrix.Races)
            {
                Assert.IsFalse(race.IsCompleted);
            }
        }
    }
}