namespace Stealer;
public class StartUp
{
    public static void Main(string[] args)
    {
        Spy spy = new Spy();
        //string result = spy.StealFieldInfo("Stealer.Hacker", new string[] { "username", "password" });
        string result = spy.AnalyzeAccessModifiers("Stealer.Hacker");
        Console.WriteLine(result);
    }
}