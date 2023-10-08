using LogForU.IO.Interfaces;

namespace LogForU.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();

    }
}
