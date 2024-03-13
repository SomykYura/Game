using SportsCarTuningSimulator.BLL.Cars.Details;

namespace SportsCarTuningSimulator.BLL.Cars
{
    public class Car
    {
        public string Name { get; private set; }
        public Dictionary<DetailType, Detail> Details { get { return _details; } }

        private readonly Dictionary<DetailType, Detail> _details = new();

        public Car(string name, Detail engine, Detail transmission, Detail chassis)
        {
            Name = name;
            _details.Add(engine.Type, engine);
            _details.Add(transmission.Type, transmission);
            _details.Add(chassis.Type, chassis);
        }

        public override string ToString()
        {
            return $"Car characteristics {Name}:\n" +
                $"Engine: {_details[DetailType.Engine].Name}\n" +
                $"Transmission: {_details[DetailType.Transmission].Name}\n" +
                $"Chassis: {_details[DetailType.Chassis].Name}\n" +
                $"Power: {GetHorsepower()} hp.";
        }

        public void InstallDetail(Detail newDetail)
        {
            if (_details.ContainsKey(newDetail.Type))
            {
                _details[newDetail.Type] = newDetail;
            }
        }

        public int GetHorsepower()
        {
            return _details.Values.Sum(detail => detail.Horsepower);
        }

        public static Car CreateStandardCar(string name = "Car")
        {
            var engine = new Detail(0, "Inline-4 Naturally Aspirated Engine", 0, 110, DetailClass.Basic, DetailType.Engine);
            var transmission = new Detail(0, "4-Speed Automatic Transmission", 0, 50, DetailClass.Basic, DetailType.Transmission);
            var chassis = new Detail(0, "Steel Frame Chassis", 0, 30, DetailClass.Basic, DetailType.Chassis);

            return new Car(name, engine, transmission, chassis);
        }
    }
}