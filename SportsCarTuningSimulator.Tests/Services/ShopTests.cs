using SportsCarTuningSimulator.BLL.Models;
using SportsCarTuningSimulator.BLL.Services;
#nullable disable

namespace SportsCarTuningSimulator.Tests.Services
{
    [TestClass]
    public class ShopTests
    {
        private Shop _shop;
        private Player _player;

        [TestInitialize]
        public void Setup()
        {
            _shop = new Shop();
            _player = new Player(0, "Gamer", 0, Car.CreateStandardCar());
        }

        [TestMethod]
        public void BuyDetail_EnoughMoney_PlayerHasDetail()
        {
            int initialMoney = 2000;
            _player.Money = initialMoney;
            int detailId = 1;

            var boughtDetail = _shop.BuyDetail(_player, detailId);

            Assert.IsNotNull(boughtDetail);
            Assert.AreEqual(initialMoney - boughtDetail.Price, _player.Money);
            Assert.IsTrue(_player.Car.Details.Any(d => d.Value.Id == detailId));
        }

        [TestMethod]
        public void BuyDetail_NotEnoughMoney_ExceptionThrown()
        {
            _player.Money = 100;
            int detailId = 7; // Detail costs 5000

            Assert.ThrowsException<Exception>(() => _shop.BuyDetail(_player, detailId));
        }

        [TestMethod]
        public void GetAvailableDetails_PlayerWithNoDetails_EmptyList()
        {
            _player.Car.Details.Clear();

            var availableDetails = _shop.GetAvailableDetails(_player);

            Assert.IsFalse(availableDetails.Any());
        }

        [TestMethod]
        public void GetDetailsByUserBudget_PlayerWithEnoughMoney_CorrectDetailsReturned()
        {
            _player.Money = 2000;

            var detailsByUserBudget = _shop.GetDetailsByUserBudget(_player);

            Assert.IsTrue(detailsByUserBudget.All(d => d.Price <= _player.Money));
        }
    }
}