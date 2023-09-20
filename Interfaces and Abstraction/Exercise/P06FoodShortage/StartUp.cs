using static System.Net.Mime.MediaTypeNames;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();
            for (int i = 0; i < n; i++)
            {
                string[] date = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (date.Length == 4)
                {
                    string name = date[0];
                    int age = int.Parse(date[1]);
                    string id = date[2];
                    string birdDate = date[3];
                    IBuyer citizen = new Citizen(name, age, id, birdDate);
                    buyers.Add(citizen);

                }
                else
                {
                    string name = date[0];
                    int age = int.Parse(date[1]);
                    string group = date[2];
                    IBuyer rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);

                }
            }
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var p in buyers)
                {
                    if (p.Name == command)
                    {
                        p.BuyFood();
                    }
                }
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }

    }
}