using SportsCarTuningSimulator.BLL.Models;

namespace SportsCarTuningSimulator.Tests.Models
{
    [TestClass]
    public class DetailTests
    {
        [TestMethod]
        public void ToString_ReturnsCorrectString()
        {
            var detail = new Detail(1, "Test Detail", 100, 200, DetailClass.Basic, DetailType.Engine);
            string expected = $"Id: 1\n" +
                              $"Name: Test Detail,\n" +
                              $"Class: Basic,\n" +
                              $"Price: 100,\n" +
                              $"Horsepower: 200";

            string result = detail.ToString();

            Assert.AreEqual(expected, result);
        }
    }
}