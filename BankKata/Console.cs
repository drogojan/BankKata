namespace BankKata
{
    public class Console : IConsole
    {
        public void PrintLine(string line)
        {
            System.Console.WriteLine(line);
        }
    }
}