namespace SportsCarTuningSimulator.Menus.Composite
{
    public class MenuItem : IMenuComponent
    {
        private readonly Action _action;

        public string Title { get; }

        public MenuItem(string title, Action action)
        {
            Title = title;
            _action = action;
        }

        public void Display()
        {
            Console.WriteLine(Title);
        }

        public void Execute()
        {
            Console.Clear();
            _action?.Invoke();
            Console.ReadKey();
        }
    }
}