using SportsCarTuningSimulator.Menus;
using SportsCarTuningSimulator.Menus.Composite;

class Program
{
    static void Main(string[] args)
    {
        MenuBuilder builder = new MenuBuilder("Головне меню");
        builder.AddSubMenu("Grand pri", subMenu =>
        {
            subMenu.AddMenuItem("Реєстрацiя учасникiв", () => Console.WriteLine("Ви обрали Реєстрацiя учасникiв"));
            subMenu.AddMenuItem("Проведення квалiфiкацiї", () => Console.WriteLine("Ви обрали Проведення квалiфiкацiї"));
            subMenu.AddMenuItem("Гонка", () => Console.WriteLine("Ви обрали Гонка"));
            subMenu.AddMenuItem("Подивитися результати", () => Console.WriteLine("Ви обрали Подивитися результати"));
        })
        .AddSubMenu("Car", subMenu =>
        {
            subMenu.AddMenuItem("Переглянути поточні характеристики автомобіля", () => Console.WriteLine("Ви обрали Переглянути поточні характеристики автомобіля"));
            subMenu.AddSubMenu("Shop", shopMenu =>
            {
                shopMenu.AddMenuItem("Купити новий двигун", () => Console.WriteLine("Ви обрали Купити новий двигун"));
                shopMenu.AddMenuItem("Купити поліпшену трансмісію", () => Console.WriteLine("Ви обрали Купити поліпшену трансмісію"));
                shopMenu.AddMenuItem("Купити вдосконалене шасі", () => Console.WriteLine("Ви обрали Купити вдосконалене шасі"));
                shopMenu.AddMenuItem("Переглянути поточні характеристики автомобіля", () => Console.WriteLine("Ви обрали Переглянути поточні характеристики автомобіля"));
            });
        })
        .AddMenuItem("About game", () => Console.WriteLine("Ви обрали About game"));

        Menu rootMenu = builder.Build();
        rootMenu.Execute();
    }
}