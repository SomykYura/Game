namespace SportsCarTuningSimulator.Output
{
    public class ConsolePrintStrategy : IPrintStrategy
    {
        public void Print(string data)
        {
            Console.WriteLine(data);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public string WaitForUserInput()
        {
            return Console.ReadLine()!;
        }
    }
}