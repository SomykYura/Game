using SportsCarTuningSimulator.BLL;
using SportsCarTuningSimulator.BLL.Models;
using SportsCarTuningSimulator.Menus;
using SportsCarTuningSimulator.Menus.Composite;
using SportsCarTuningSimulator.Output;

class Program
{

    //1. Доведи до ладу те що є
    //2. Можливо збереження стану гри
    //3. Кнопка нова гра
    
    private static IPrintStrategy _print;

    static void Main(string[] args)
    {
        _print = new ConsolePrintStrategy();

        Menu rootMenu = BuildMenu(_print, new Game(Player.GeneratePlayer("Gamer"), 9));
        rootMenu.Execute();
    }

    private static Menu BuildMenu(IPrintStrategy print, Game game)
    {
        var builder = new MenuBuilder("Головне меню", print);
        builder.AddSubMenu("Grand pri", grandPriMenu =>
        {
            grandPriMenu.AddMenuItem("Гонка", () => game.StartRace());
            grandPriMenu.AddMenuItem("Подивитися результати", () => game.PrintResults());
        })
        .AddSubMenu("Car", carMenu =>
        {
            carMenu.AddMenuItem("Переглянути поточнi характеристики автомобiля", () => game.GetPlayers().First(x => x.Id == game._player.Id).Car.DisplayCharacteristics());
            carMenu.AddSubMenu("Shop", shopMenu =>
            {
                shopMenu.AddMenuItem("Display available details", () => game._shop.PrintAvailableDetails(game._player));
                shopMenu.AddMenuItem("Buy detail", () => BuyDetail(game._player, game._shop));
                shopMenu.AddMenuItem("Переглянути поточнi характеристики автомобiля", () => game.GetPlayers().First(x => x.Id == game._player.Id).Car.DisplayCharacteristics());
            });
        })
        .AddMenuItem("Про гравця", () => game._player.DisplayPlayerInfo())
        .AddMenuItem("About game", () =>  print.Print("Ви обрали About game"));

        return builder.Build();
    }

    private static void BuyDetail(Player player, Shop shop)
    {
        try
        {
            if (int.TryParse(_print.WaitForUserInput(), out int detailId))
            {
                var detail = shop.BuyDetail(player, detailId);

                _print.Print($"Ви успішно купил {detail.Name}.");
            }
        }
        catch (Exception ex) 
        {
            _print.Print(ex.ToString());
        }
    }
}