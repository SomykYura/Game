#nullable disable
using SportsCarTuningSimulator.BLL.Builders;
using SportsCarTuningSimulator.BLL.Facades;
using SportsCarTuningSimulator.BLL.Models;
using SportsCarTuningSimulator.BLL.Services;
using SportsCarTuningSimulator.Menus;
using SportsCarTuningSimulator.Menus.Composite;
using SportsCarTuningSimulator.Output;
using SportsCarTuningSimulator.Shared;

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
        grandPriMenu.AddMenuItem(ResourceMenu.Race, () => _print.Print(gameFacade.StartRace()));
        grandPriMenu.AddMenuItem(ResourceMenu.ViewResults, () => _print.Print(gameFacade.GetRacesResults()));
        grandPriMenu.AddMenuItem(ResourceMenu.RestartGame, () => { gameFacade.RestartGame(); _print.Print(Resource.GameRestarted); });
    })
    .AddSubMenu(ResourceMenu.Car, carMenu =>
    {
        carMenu.AddMenuItem(ResourceMenu.ViewCarCharacteristics, () => _print.Print(gameFacade.GetCurrentPlayer().Car.ToString()));
        carMenu.AddSubMenu(ResourceMenu.Shop, shopMenu =>
        {
            shopMenu.AddMenuItem(ResourceMenu.AvailableDetails, () => _print.Print(gameFacade.GetShop().GetAvailableDetailsText(gameFacade.GetCurrentPlayer())));
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
        _print.Print("Enter the detail ID: ");
        if (int.TryParse(_print.WaitForUserInput(), out int detailId))
        {
            var detail = shop.BuyDetail(player, detailId);

            _print.Print($"You have successfully purchased {detail.Name}.");
        }
    }
    catch (Exception ex)
    {
        _print.Print(ex.ToString());
    }
}