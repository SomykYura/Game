namespace SportsCarTuningSimulator.BLL.Models
{
    public class Detail
    {
        public int Id { get; }
        public string Name { get; }
        public int Price { get; }
        public int Horsepower { get; }
        public DetailType Type { get; }
        public DetailClass Class { get; }

        public Detail(int id, string name, int price, int horsepower, DetailClass @class, DetailType type)
        {
            Id = id;
            Name = name;
            Price = price;
            Horsepower = horsepower;
            Class = @class;
            Type = type;
        }

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                $"Name: {Name},\n" +
                $"Class: {Class},\n" +
                $"Price: {Price},\n" +
                $"Horsepower: {Horsepower}";
        }
    }
}