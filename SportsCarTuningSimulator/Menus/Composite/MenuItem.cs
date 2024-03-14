using SportsCarTuningSimulator.Output;

namespace SportsCarTuningSimulator.Menus.Composite
{
    public class MenuItem : IMenuComponent
    {
        private readonly IPrintStrategy print;
        private readonly Action _action;

        public string Title { get; }

        public MenuItem(IPrintStrategy print, string title, Action action)
        {
            this.print = print;
            Title = title;
            _action = action;
        }

        public void Display()
        {
            print.Print(Title);
        }

        public void Execute()
        {
            print.Clear();
            _action?.Invoke();
            print.WaitForUserInput();
        }
    }
}