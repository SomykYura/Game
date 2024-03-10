namespace SportsCarTuningSimulator.Menus.Composite
{
    public interface IMenuComponent
    {
        public string Title { get; }
        void Display();
        void Execute();
    }
}