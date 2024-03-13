namespace SportsCarTuningSimulator.BLL.Cars.Details
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
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }

            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative.", nameof(price));
            }

            if (horsepower < 0)
            {
                throw new ArgumentException("Horsepower cannot be negative.", nameof(horsepower));
            }

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