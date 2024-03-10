namespace SportsCarTuningSimulator.BLL.Models
{
    public class Car
    {
        public string Name { get; set; }
        public Engine Engine { get; set; }
        public Transmission Transmission { get; set; }
        public Chassis Chassis { get; set; }
        public int Horsepower { get { return CalculateTotalHorsepower(); }  }

        public Car(Engine engine, Transmission transmission, Chassis chassis)
        {
            Engine = engine;
            Transmission = transmission;
            Chassis = chassis;
        }

        public int CalculateTotalHorsepower()
        {
            return Engine.Horsepower + Transmission.Horsepower + Chassis.Horsepower;
        }

        public static Car CreateStandardCar()
        {
            Engine standardEngine = new Engine("Standard Engine", 100, DetailClass.Basic);
            Transmission standardTransmission = new Transmission("Standard Transmission", 80, DetailClass.Basic);
            Chassis standardChassis = new Chassis("Standard Chassis", 120, DetailClass.Basic);

            return new Car(standardEngine, standardTransmission, standardChassis);
        }
    }

    public enum DetailClass
    {
        Premium,    // Преміум
        Standard,   // Стандартний
        Basic       // Базовий
    }

    public class Engine
    {
        public DetailClass DetailClass { get; set; }
        public string Name { get; set; }
        public int Horsepower { get; private set; }

        public Engine(string name, int horsepower, DetailClass detailClass)
        {
            DetailClass = detailClass;
            Name = name;
            Horsepower = horsepower;
        }

        public void Upgrade(int horsepower)
        {
            Horsepower += horsepower;
            Console.WriteLine("Двигун успішно покращено!");
        }
    }

    public class Transmission
    {
        public DetailClass DetailClass { get; set; }
        public string Info { get; private set; }
        public int Horsepower { get; private set; }

        public Transmission(string info, int speed, DetailClass detailClass)
        {
            Info = info;
            Horsepower = speed;
            DetailClass = detailClass;
        }

        public void Upgrade(int horsepower)
        {
            Horsepower += horsepower;
            Console.WriteLine("Трансмісія успішно покращено!");
        }
    }

    public class Chassis
    {
        public DetailClass DetailClass { get; set; }
        public string Info { get; private set; }
        public int Horsepower { get; private set; }

        public Chassis(string info, int horsepower, DetailClass detailClass)
        {
            Info = info;
            Horsepower = horsepower;
            DetailClass = detailClass;
        }

        public void Upgrade(int horsepower)
        {
            Horsepower += horsepower;
            Console.WriteLine("Шасі успішно покращено!");
        }
    }
}