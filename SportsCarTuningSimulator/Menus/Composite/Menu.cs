namespace SportsCarTuningSimulator.Menus.Composite
{
    public class Menu : IMenuComponent
    {
        private readonly List<IMenuComponent> _components = new List<IMenuComponent>();

        public List<IMenuComponent> Components { get { return _components; } }

        public string Title { get; }

        public Menu(string title)
        {
            Title = title;
        }

        public void Add(IMenuComponent component)
        {
            _components.Add(component);
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(Title);
            for (int i = 0; i < _components.Count; i++)
            {
                Console.WriteLine($"{i + 1}. " + _components[i].Title);
            }

            Console.WriteLine("0. Вихiд");
        }

        public void Execute()
        {
            Console.WriteLine($"Ви обрали підменю: {Title}");
            while (true)
            {
                Display();

                Console.WriteLine("Виберіть опцію (або введіть 0 для виходу з Під меню / Програми):");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > _components.Count)
                {
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    continue;
                }

                if (choice == 0)
                    break;

                if (_components[choice - 1] is MenuItem menuItem)
                {
                    menuItem.Execute();
                    if (menuItem.ToString() == "Вийти з Під меню / Програми")
                        break;
                }
                else if (_components[choice - 1] is Menu submenu)
                {
                    submenu.Execute();
                }
            }
        }
    }
}