using ExplicitInterfaces.Core;
using ExplicitInterfaces.Core.Interfaces;

namespace ExplicitInterfaces;
public class StartUp
{
    public static void Main(string[] aegs)
    {
        IEngine engine = new Engine();
        engine.Run();
    }
}