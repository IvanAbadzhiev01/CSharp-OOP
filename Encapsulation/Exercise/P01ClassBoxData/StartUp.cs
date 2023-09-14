using System.Net.Http.Headers;

namespace Box
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new(length, width, height);
                double sf = box.SurfaceArea();
                double lsa = box.LateralSurfaceArea();
                double v = box.Volume();
                Console.WriteLine($"Surface Area - {sf:f2}");
                Console.WriteLine($"Lateral Surface Area - {lsa:f2}");
                Console.WriteLine($"Volume - {v:f2}");
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }


        }
    }

}