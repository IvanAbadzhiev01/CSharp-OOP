using System.Collections.Generic;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {

            List<IFile> files = new();
            files.Add(new File("Ivan", 180, 10));
            files.Add(new Music("Ivan", "Blest", 190, 10));
            files.Add(new Photo("Ivan", 100, 10));



            foreach (var file in files)
            {
                StreamProgressInfo progressInfo = new(file);

                System.Console.WriteLine(progressInfo.CalculateCurrentPercent());
            }

        }
    }
}
