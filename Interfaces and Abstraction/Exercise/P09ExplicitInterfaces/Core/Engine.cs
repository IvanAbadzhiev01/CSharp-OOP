using ExplicitInterfaces.Core.Interfaces;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;

namespace ExplicitInterfaces.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = cmdArgs[0];
                string country = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);


                IResident resident = new Citizen(name, age, country);
                IPerson person = new Citizen(name, age, country);

                Console.WriteLine($"{person.GetName()}");
                Console.WriteLine($"{resident.GetName()}");

            }
        }
    }
}
