using LogForU.IO.Interfaces;

namespace LogForU.IO
{
    public class ConsoleWrite : IWriter
    {
        public void Write(string value) => Console.WriteLine(value);

    }
}
