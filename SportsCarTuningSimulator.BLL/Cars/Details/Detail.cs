namespace SportsCarTuningSimulator.BLL.Cars.Details
{
    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Horsepower { get; set; }
        public DetailType Type { get; set; }
        public DetailClass Class { get; set; }

        public Detail(int id, string name, int price, int horsepower, DetailClass @class, DetailType type)
        {
            Id = id;
            Name = name;
            Price = price;
            Horsepower = horsepower;
            Class = @class;
            Type = type;
        }

        // Це хуйня потрібно міняти деталь повністю
        public void Update(Detail newDetail)
        {
            Id = newDetail.Id;
            Name = newDetail.Name;
            Price = newDetail.Price;
            Horsepower = newDetail.Horsepower;
            Class = newDetail.Class;
            Type = newDetail.Type;
        }
    }
}