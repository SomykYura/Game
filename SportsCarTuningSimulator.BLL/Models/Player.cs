using SportsCarTuningSimulator.BLL.Cars;
using SportsCarTuningSimulator.BLL.Cars.Details;

namespace SportsCarTuningSimulator.BLL.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; } = 0;
        public int Money { get; set; }
        public Car Car { get; set; }
        public int Luck { get; internal set; }

        public Player(int id, string name, int money, Car car)
        {
            Id = id;
            Name = name;
            Money = money;
            Car = car;
        }

        public static Player GeneratePlayer(string name)
        {
            return new Player(1, name, 1000, Car.CreateStandardCar());
        }

        public static Player[] GeneratePlayers(int count)
        {
            Player[] players = new Player[count];
            for (int i = 0; i < count; i++)
            {   
                string playerName = "Гравець " + (i + 1);
                Car standardCar = Car.CreateStandardCar();
                players[i] = new Player(i + 2, playerName, 1000, standardCar);
            }

            return players;
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"Player ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Money: {Money}");
            Console.WriteLine("\nCar Info:");
            Console.WriteLine($"Name: {Car.Name}");
            Console.WriteLine($"Engine: {Car.GetDetailByType(DetailType.Engine).Name}, Power: {Car.GetDetailByType(DetailType.Engine).Horsepower} hp");
            Console.WriteLine($"Transmission: {Car.GetDetailByType(DetailType.Transmission).Name}, Power: {Car.GetDetailByType(DetailType.Transmission).Horsepower} hp");
            Console.WriteLine($"Chassis: {Car.GetDetailByType(DetailType.Chassis).Name}, Power: {Car.GetDetailByType(DetailType.Chassis).Horsepower} hp");
        }
    }
}