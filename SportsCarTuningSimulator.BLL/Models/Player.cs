namespace SportsCarTuningSimulator.BLL.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
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

        public static List<Player> GeneratePlayers(int count)
        {
            var players = new List<Player>();
            for (int i = 0; i < count; i++)
            {
                string playerName = $"{nameof(Player)} {i + 1}";
                Car standardCar = Car.CreateStandardCar();

                players.Add(new Player(i + 2, playerName, 1000, standardCar));
            }

            return players;
        }

        public override string ToString()
        {
            return $"Player ID: {Id}\n" +
               $"Name: {Name}\n" +
               $"Money: {Money}\n" +
               $"\n{Car}";
        }
    }
}