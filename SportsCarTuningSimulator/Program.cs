using SportsCarTuningSimulator.BLL;
using SportsCarTuningSimulator.BLL.GameSystem;
using SportsCarTuningSimulator.BLL.Models;
using SportsCarTuningSimulator.Menus;
using SportsCarTuningSimulator.Menus.Composite;
using SportsCarTuningSimulator.Output;
using SportsCarTuningSimulator.Shared;
#nullable disable


//1. Доведи до ладу те що є
//2. Можливо збереження стану гри
//3. Кнопка нова гра

IPrintStrategy _print = null;

try
{
    _print = new ConsolePrintStrategy();

    var game = new GameBuilder()
        .WithPlayer(Player.GeneratePlayer("Gamer"))
        .WithRivalsCount(9)
        .Build();

    Menu rootMenu = BuildMenu(new GameFacade(game));
    rootMenu.Execute();
}
catch (Exception)
{
    Console.WriteLine(Resource.ReportToSupport);
}

Menu BuildMenu(GameFacade gameFacade)
{
    var builder = new MenuBuilder(ResourceMenu.MainMenu, _print);
    builder.AddSubMenu(ResourceMenu.GrandPrix, grandPriMenu =>
    {
        grandPriMenu.AddMenuItem(ResourceMenu.Race, () => gameFacade.StartRace());
        grandPriMenu.AddMenuItem(ResourceMenu.ViewResults, () => gameFacade.PrintResults());
        grandPriMenu.AddMenuItem(ResourceMenu.RestartGame, () => gameFacade.RestartGame());
    })
    .AddSubMenu(ResourceMenu.Car, carMenu =>
    {
        carMenu.AddMenuItem(ResourceMenu.ViewCarCharacteristics, () => _print.Print(gameFacade.GetCurrentPlayer().Car.ToString()));
        carMenu.AddSubMenu(ResourceMenu.Shop, shopMenu =>
        {
            shopMenu.AddMenuItem(ResourceMenu.AvailableDetails, () => gameFacade.GetShop().PrintAvailableDetails(gameFacade.GetCurrentPlayer()));
            shopMenu.AddMenuItem(ResourceMenu.BuyDetail, () => BuyDetail(gameFacade.GetCurrentPlayer(), gameFacade.GetShop()));
            shopMenu.AddMenuItem(ResourceMenu.ViewCarCharacteristics, () => _print.Print(gameFacade.GetCurrentPlayer().Car.ToString()));
        });
    })
    .AddMenuItem(ResourceMenu.AboutPlayer, () => _print.Print(gameFacade.GetCurrentPlayer().ToString()))
    .AddMenuItem(ResourceMenu.AboutGame, () => _print.Print(Resource.AboutGame));

    return builder.Build();
}

void BuyDetail(Player player, Shop shop)
{
    try
    {
        if (int.TryParse(_print.WaitForUserInput(), out int detailId))
        {
            var detail = shop.BuyDetail(player, detailId);

            _print.Print($"Ви успішно купили {detail.Name}.");
        }
    }
    catch (Exception ex)
    {
        _print.Print(ex.ToString());
    }
}