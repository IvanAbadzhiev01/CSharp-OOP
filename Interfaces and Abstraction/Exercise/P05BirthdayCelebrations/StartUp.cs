using static System.Net.Mime.MediaTypeNames;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {


            string command;

            List<IBirthable> birthables = new List<IBirthable>();
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = cmdArgs[0];
                switch (type)
                {
                    case "Citizen":
                        string nameCitizen = cmdArgs[1];
                        int ageCitizen = int.Parse(cmdArgs[2]);
                        string idCitizen = cmdArgs[3];
                        string birdthDateCitizen = cmdArgs[4];
                        IBirthable citizen = new Citizen(nameCitizen, ageCitizen, idCitizen, birdthDateCitizen);
                        birthables.Add(citizen);
                        break;
                    case "Pet":
                        string namePet = cmdArgs[1];
                        string birdthDatePet = cmdArgs[2];
                        IBirthable pet = new Pet(namePet, birdthDatePet);
                        birthables.Add(pet);
                        break;
                    default:
                        break;
                }


            }
            int yearBirthDate = int.Parse(Console.ReadLine());

            foreach (var person in birthables)
            {
                string lastCharacters = person.Birthdate.Substring(person.Birthdate.Length - 4);
                int id = int.Parse(lastCharacters);
                // int convertFakeId = int.Parse(fakeId);
                if (id == yearBirthDate)
                {
                    Console.WriteLine(person.Birthdate);
                }
            }

        }

    }
}