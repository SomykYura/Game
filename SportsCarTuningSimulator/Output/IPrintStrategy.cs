namespace SportsCarTuningSimulator.Output
{
    public interface IPrintStrategy
    {
        void Print(string data);
        string WaitForUserInput();
        void Clear();
    }
}