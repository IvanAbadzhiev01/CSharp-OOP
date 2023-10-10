using System;

namespace AuthorProblem
{
    [Author("Ivan")]
    public class StartUp
    {
        [Author("GoShow")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
