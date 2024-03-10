using SportsCarTuningSimulator.Menus.Composite;

namespace SportsCarTuningSimulator.Menus
{
    public class MenuBuilder
    {
        private readonly Menu _menu;

        public MenuBuilder(string name)
        {
            _menu = new Menu(name);
        }

        public MenuBuilder AddMenuItem(string name, Action action)
        {
            _menu.Add(new MenuItem(name, action));
            return this;
        }

        public MenuBuilder AddSubMenu(string name, Action<MenuBuilder> buildAction)
        {
            var subMenuBuilder = new MenuBuilder(name);
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