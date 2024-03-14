using SportsCarTuningSimulator.BLL.Models;

namespace SportsCarTuningSimulator.Tests.Models
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void ToString_ReturnsCorrectString()
        {
            var engine = new Detail(1, "Engine", 1000, 300, DetailClass.Intermediate, DetailType.Engine);
            var transmission = new Detail(2, "Transmission", 500, 200, DetailClass.Intermediate, DetailType.Transmission);
            var chassis = new Detail(3, "Chassis", 800, 100, DetailClass.Intermediate, DetailType.Chassis);
            var car = new Car("MyCar", engine, transmission, chassis);
            string expected = "Car characteristics MyCar:\n" +
                              "Engine: Engine\n" +
                              "Transmission: Transmission\n" +
                              "Chassis: Chassis\n" +
                              "Power: 600 hp.";

            string actual = car.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InstallDetail_AddsNewDetail()
        {
            var transmission = new Detail(1, "Transmission", 1000, 300, DetailClass.Intermediate, DetailType.Transmission);
            var chassis = new Detail(1, "Chassis", 1000, 300, DetailClass.Intermediate, DetailType.Chassis);
            var engine = new Detail(1, "Engine", 1000, 300, DetailClass.Intermediate, DetailType.Engine);
            var newEngine = new Detail(1, "New Engine", 1500, 400, DetailClass.Medium, DetailType.Engine);
            var car = new Car("MyCar", engine, transmission, chassis);

            car.InstallDetail(newEngine);

            Assert.AreEqual("New Engine", car.Details[DetailType.Engine].Name);
            Assert.AreEqual(1500, car.Details[DetailType.Engine].Price);
            Assert.AreEqual(400, car.Details[DetailType.Engine].Horsepower);
        }

        [TestMethod]
        public void GetHorsepower_ReturnsTotalHorsepower()
        {
            var engine = new Detail(1, "Engine", 1000, 300, DetailClass.Intermediate, DetailType.Engine);
            var transmission = new Detail(2, "Transmission", 500, 200, DetailClass.Intermediate, DetailType.Transmission);
            var chassis = new Detail(3, "Chassis", 800, 100, DetailClass.Intermediate, DetailType.Chassis);
            var car = new Car("MyCar", engine, transmission, chassis);

            int totalHorsepower = car.GetHorsepower();

            Assert.AreEqual(600, totalHorsepower);
        }

        [TestMethod]
        public void CreateStandardCar_ReturnsCarWithStandardDetails()
        {
            var car = Car.CreateStandardCar("StandardCar");

            Assert.AreEqual("StandardCar", car.Name);
            Assert.AreEqual(3, car.Details.Count);
            Assert.IsTrue(car.Details.ContainsKey(DetailType.Engine));
            Assert.IsTrue(car.Details.ContainsKey(DetailType.Transmission));
            Assert.IsTrue(car.Details.ContainsKey(DetailType.Chassis));
        }
    }
}