namespace SportsCarTuningSimulator.BLL.Models
{
    class Shop
    {
        // Перерахування для типу деталі
        public enum DetailType
        {
            Engine,
            Transmission,
            Chassis
        }

        // Перерахування для класу деталі
        public enum DetailClass
        {
            Premium,    // Преміум
            Standard,   // Стандартний
            Basic       // Базовий
        }

        // Клас деталі
        class Detail
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public int Horsepower { get; set; }
            public DetailType Type { get; set; }
            public DetailClass Class { get; set; }

            public Detail(string name, int price, int horsepower, DetailType type, DetailClass @class)
            {
                Name = name;
                Price = price;
                Horsepower = horsepower;
                Type = type;
                Class = @class;
            }
        }

        private List<Detail> details;

        public Shop()
        {
            details = new List<Detail>();

            // Додавання деталей до магазину
            details.Add(new Detail("Двигун", 1000, 200, DetailType.Engine, DetailClass.Premium));
            details.Add(new Detail("Трансмісія", 800, 150, DetailType.Transmission, DetailClass.Standard));
            details.Add(new Detail("Шасі", 1200, 100, DetailType.Chassis, DetailClass.Basic));

            // Додавання інших деталей до магазину
            details.Add(new Detail("Двигун", 900, 180, DetailType.Engine, DetailClass.Standard));
            details.Add(new Detail("Двигун", 700, 120, DetailType.Engine, DetailClass.Basic));
            details.Add(new Detail("Трансмісія", 700, 120, DetailType.Transmission, DetailClass.Basic));
            details.Add(new Detail("Трансмісія", 1000, 180, DetailType.Transmission, DetailClass.Standard));
            details.Add(new Detail("Шасі", 1500, 200, DetailType.Chassis, DetailClass.Premium));
            details.Add(new Detail("Шасі", 1000, 150, DetailType.Chassis, DetailClass.Standard));
        }

        // Метод для відображення доступних деталей в магазині
        public void DisplayAvailableDetails()
        {
            Console.WriteLine("Доступні деталі в магазині:");
            foreach (var detail in details)
            {
                Console.WriteLine($"Назва: {detail.Name}, Тип: {detail.Type}, Клас: {detail.Class}, Ціна: {detail.Price}, Кількість кінських сил: {detail.Horsepower}");
            }
        }

        public bool BuyDetail(string detailName)
        { 
            foreach (var detail in details)
            {
                if (detail.Name.ToLower() == detailName.ToLower())
                {
                    return true; 
                }
            }

            return false;
        }
    }
}