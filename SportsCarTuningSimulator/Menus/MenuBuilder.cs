using SportsCarTuningSimulator.Menus.Composite;
using SportsCarTuningSimulator.Output;

namespace SportsCarTuningSimulator.Menus
{
    public class MenuBuilder
    {
        private readonly Menu _menu;
        private readonly IPrintStrategy print;

        public MenuBuilder(string name, IPrintStrategy print)
        {
            _menu = new Menu(print, name);
            this.print = print;
        }

        public MenuBuilder AddMenuItem(string name, Action action)
        {
            _menu.Add(new MenuItem(print, name, action));
            return this;
        }

        public MenuBuilder AddSubMenu(string name, Action<MenuBuilder> buildAction)
        {
            var subMenuBuilder = new MenuBuilder(name, print);
            buildAction(subMenuBuilder);
            _menu.Add(subMenuBuilder.Build());
            return this;
        }

        public Menu Build()
        {
            return _menu;
        }
    }
}