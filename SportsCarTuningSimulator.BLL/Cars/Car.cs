using SportsCarTuningSimulator.BLL.Cars.Details;

namespace SportsCarTuningSimulator.BLL.Cars
{
    public class Car
    {
        public string Name { get; set; }
        public List<Detail> Details { get; set; }
        public int Horsepower { get { return GetHorsepower(); } }

        public Car(string name, List<Detail> details)
        {
            Name = name;
            Details = details;
        }

        public void DisplayCharacteristics()
        {
            Console.WriteLine($"Характеристики автомобiля {Name}:");
            Console.WriteLine($"Двигун: {GetDetailByType(DetailType.Engine).Name}");
            Console.WriteLine($"Трансмiсiя: {GetDetailByType(DetailType.Transmission).Name}");
            Console.WriteLine($"Шасi: {GetDetailByType(DetailType.Chassis).Name}");
            Console.WriteLine($"Потужнiсть: {Horsepower} к.с.");
        }

        public void InstallDetail(Detail newDetail)
        {
            foreach (Detail detail in Details) 
            {
                if (detail.Type == newDetail.Type)
                {
                    detail.Update(newDetail); 
                    break; 
                }
            }
        }

        public Detail GetDetailByType(DetailType type)
        { 
            return Details.First(detail => detail.Type == type);
        }

        public int GetHorsepower()
        {
            return Details.Sum(detail => detail.Horsepower);
        }

        public static Car CreateStandardCar()
        {
            var engine = new Detail(0, "Inline-4 Naturally Aspirated Engine", 0, 110, DetailClass.Basic, DetailType.Engine);
            var transmission = new Detail(0, "4-Speed Automatic Transmission", 0, 50, DetailClass.Basic, DetailType.Transmission);
            var chassis = new Detail(0, "Steel Frame Chassis", 0, 30, DetailClass.Basic, DetailType.Chassis);

            return new Car("", new List<Detail> { engine, transmission, chassis });
        }
    }
}