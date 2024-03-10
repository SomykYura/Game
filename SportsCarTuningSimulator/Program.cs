using SportsCarTuningSimulator.Menus;
using SportsCarTuningSimulator.Menus.Composite;
using SportsCarTuningSimulator.Output;

class Program
{
    static void Main(string[] args)
    {
        var console = new ConsolePrintStrategy();

        Menu rootMenu = BuildMenu(console);
        rootMenu.Execute();
    }

    private static Menu BuildMenu(IPrintStrategy print)
    {
        var builder = new MenuBuilder("Головне меню", print);
        builder.AddSubMenu("Grand pri", subMenu =>
        {
            subMenu.AddMenuItem("Реєстрацiя учасникiв", () => print.Print("Ви обрали Реєстрацiя учасникiв"));
            subMenu.AddMenuItem("Проведення квалiфiкацiї", () => print.Print("Ви обрали Проведення квалiфiкацiї"));
            subMenu.AddMenuItem("Гонка", () =>  print.Print("Ви обрали Гонка"));
            subMenu.AddMenuItem("Подивитися результати", () =>  print.Print("Ви обрали Подивитися результати"));
        })
        .AddSubMenu("Car", subMenu =>
        {
            subMenu.AddMenuItem("Переглянути поточні характеристики автомобіля", () =>  print.Print("Ви обрали Переглянути поточні характеристики автомобіля"));
            subMenu.AddSubMenu("Shop", shopMenu =>
            {
                shopMenu.AddMenuItem("Купити новий двигун", () =>  print.Print("Ви обрали Купити новий двигун"));
                shopMenu.AddMenuItem("Купити поліпшену трансмісію", () =>  print.Print("Ви обрали Купити поліпшену трансмісію"));
                shopMenu.AddMenuItem("Купити вдосконалене шасі", () =>  print.Print("Ви обрали Купити вдосконалене шасі"));
                shopMenu.AddMenuItem("Переглянути поточні характеристики автомобіля", () =>  print.Print("Ви обрали Переглянути поточні характеристики автомобіля"));
            });
        })
        .AddMenuItem("About game", () =>  print.Print("Ви обрали About game"));

        return builder.Build();
    }
}