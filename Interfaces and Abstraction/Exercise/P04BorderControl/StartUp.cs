using static System.Net.Mime.MediaTypeNames;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {


            string command;

            List<IIdentifiable> identifiers = new List<IIdentifiable>();
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs.Length == 3) //Citizem
                {
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];

                    IIdentifiable citizen = new Citizen(name, age, id);
                    identifiers.Add(citizen);
                }
                else //Robot
                {
                    string model = cmdArgs[0];
                    string id = cmdArgs[1];
                    IIdentifiable robot = new Robot(model, id);
                    identifiers.Add(robot);
                }

            }

            string fakeId = Console.ReadLine();

            foreach (var person in identifiers)
            {
                string lastCharacters = person.Id.Substring(person.Id.Length - fakeId.Length);
                int id = int.Parse(lastCharacters);
                int convertFakeId = int.Parse(fakeId);
                if (id == convertFakeId)
                {
                    Console.WriteLine(person.Id);
                }
            }
        }

    }

}