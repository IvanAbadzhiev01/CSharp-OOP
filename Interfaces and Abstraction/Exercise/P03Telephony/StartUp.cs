namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] phoneNumber = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] sites = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ISmartphone smartphone = new Smartphone();
            IStationaryPhone stationaryPhone = new StationaryPhone();
            foreach (var number in phoneNumber)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        string message = smartphone.Calling(number);
                        Console.WriteLine(message);
                    }
                    else if (number.Length == 7)
                    {
                        string message = stationaryPhone.Dialing(number);
                        Console.WriteLine(message);
                    }
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }


            }


            foreach (var site in sites)
            {
                try
                {
                    string massage = smartphone.Browsing(site);

                    Console.WriteLine(massage);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}