﻿using SportsCarTuningSimulator.BLL.Models;

namespace SportsCarTuningSimulator.BLL.Services
{
    public class Shop
    {
        private List<Detail> _shopDetails = new();

        public Shop()
        {
            InitializeDetails();
        }

        public string GetAvailableDetailsText(Player player)
        {
            var detailsText = "Available details in the shop:\n";
            foreach (var detail in GetAvailableDetails(player))
            {
                detailsText += $"{detail}\n\n";
            }

            return detailsText;
        }

        public List<Detail> GetAvailableDetails(Player player)
        {
            var query = from details in _shopDetails
                        where player.Car.Details.Any(detail => detail.Key == details.Type
                            && (int)detail.Value.Class > (int)details.Class)
                        select details;

            var result = query.ToList();

            return result;
        }

        public List<Detail> GetDetailsByUserBudget(Player player)
        {
            var query = from details in _shopDetails
                        where player.Car.Details.Any(detail => detail.Key == details.Type
                            && (int)detail.Value.Class > (int)details.Class && details.Price <= player.Money)
                        select details;

            var result = query.ToList();

            return result;
        }

        public Detail BuyDetail(Player player, int detailId)
        {
            var detail = _shopDetails.First(detail => detail.Id == detailId) ?? throw new Exception("Detail with such ID not found.");
            if (player.Money < detail.Price)
            {
                throw new Exception("You don't have enough money to buy this detail.");
            }

            player.Money -= detail.Price;
            player.Car.InstallDetail(detail);

            return detail;
        }

        public void BuyRandomDetail(Player player)
        {
            var detailsByUserBudget = GetDetailsByUserBudget(player);
            if (detailsByUserBudget.Count == 0)
            {
                return;
            }

            int randomIndex = new Random().Next(0, detailsByUserBudget.Count);
            var detail = detailsByUserBudget[randomIndex];
            if (detail != null)
            {
                player.Money -= detail.Price;
                player.Car.InstallDetail(detail);
            }
        }

        public Detail GetDetailById(int detailId)
        {
            return _shopDetails.First(x => x.Id == detailId);
        }

        private void InitializeDetails()
        {
            _shopDetails = new List<Detail>()
            {
                new(1, "EcoBoost Turbocharged Engine", 1000, 300, DetailClass.Intermediate, DetailType.Engine),
                new(2, "6-Speed Automatic Transmission", 1100, 200, DetailClass.Intermediate, DetailType.Transmission),
                new(3, "Torsion Beam Rear Suspension", 800, 80, DetailClass.Intermediate, DetailType.Chassis),

                new(4, "V6 Twin-Turbo Engine", 3000, 400, DetailClass.Medium, DetailType.Engine),
                new(5, "7-Speed Dual-Clutch Transmission", 1200, 250, DetailClass.Medium, DetailType.Transmission),
                new(6, "Sport-Tuned Suspension with Magnetic Ride Control", 900, 90, DetailClass.Medium, DetailType.Chassis),

                new(7, "Turbocharged V8", 5000, 500, DetailClass.Premium, DetailType.Engine),
                new(8, "8-Speed Automatic Transmission with Launch Control", 1300, 300, DetailClass.Premium, DetailType.Transmission),
                new(9, "Carbon Fiber Monocoque Chassis", 1200, 100, DetailClass.Premium, DetailType.Chassis)
            };
        }
    }
}