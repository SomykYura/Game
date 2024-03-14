using SportsCarTuningSimulator.Output;
using SportsCarTuningSimulator.Shared;

namespace SportsCarTuningSimulator.Menus.Composite
{
    public class Menu : IMenuComponent
    {
        private readonly List<IMenuComponent> _components = new();
        private readonly IPrintStrategy _print;

        public List<IMenuComponent> Components { get { return _components; } }

        public string Title { get; }

        public Menu(IPrintStrategy print, string title)
        {
            _print = print;
            Title = title;
        }

        public void Add(IMenuComponent component)
        {
            _components.Add(component);
        }

        public void Display()
        {
            _print.Clear();
            _print.Print(Title);
            for (int i = 0; i < _components.Count; i++)
            {
                _print.Print($"{i + 1}. " + _components[i].Title);
            }

            _print.Print(ResourceMenu.Exit);
        }

        public void Execute()
        {
            while (true)
            {
                Display();

                _print.Print(ResourceMenu.ChooseOption);

                if (!int.TryParse(_print.WaitForUserInput(), out int choice) || choice < 0 || choice > _components.Count)
                {
                    continue;
                }

                if (choice == 0)
                    break;

                if (_components[choice - 1] is MenuItem menuItem)
                {
                    menuItem.Execute();
                }
                else if (_components[choice - 1] is Menu submenu)
                {
                    submenu.Execute();
                }
                _print.Print(Resource.PressButton);
            }
        }
    }
}