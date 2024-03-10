namespace SportsCarTuningSimulator.BLL.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public int Experience { get; set; }
        public int Money { get; set; }
        public Car Car { get; set; }

        public Player(string name, int rating, int experience, int money, Car car)
        {
            Name = name;
            Rating = rating;
            Experience = experience;
            Money = money;
            Car = car;
        }

        public static Player[] GeneratePlayers(int count)
        {
            Player[] players = new Player[count];
            for (int i = 0; i < count; i++)
            {   
                string playerName = "Гравець " + (i + 1);
                Car standardCar = Car.CreateStandardCar();
                players[i] = new Player(playerName, 1, 0, 1000, standardCar);
            }

            return players;
        }
    }
}