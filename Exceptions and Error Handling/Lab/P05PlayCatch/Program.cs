public class Program
{
    public static void Main(string[] args)
    {
        List<int> inputNumber = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList<int>();

        // Console.WriteLine("Kurec");
        int erorCount = 0;
        while (true)
        {
            // Console.WriteLine("vtori kurec  po golqm....................................");
            try
            {
                if (erorCount == 3)
                {
                    break;
                }

                ProcesCommand(inputNumber);
            }
            catch (ArgumentOutOfRangeException)
            {
                erorCount++;
                Console.WriteLine("The index does not exist!");
            }
            catch (FormatException)
            {
                erorCount++;
                Console.WriteLine("The variable is not in the correct format!");
            }

        }

        Console.WriteLine(string.Join(", ", inputNumber));
    }
    static void ProcesCommand(List<int> inputNumber)
    {
        string[] command = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string cmdType = command[0];
        switch (cmdType)
        {
            case "Replace":
                int index = int.Parse(command[1]);
                int element = int.Parse(command[2]);
                inputNumber.RemoveAt(index);
                inputNumber.Insert(index, element);
                return;
            case "Print":
                int startIndex = int.Parse(command[1]);
                int endIndex = int.Parse(command[2]);
                List<int> curent = new();
                for (int i = startIndex; i <= endIndex; i++)
                {
                    curent.Add(inputNumber[i]);
                }
                Console.WriteLine(string.Join(", ", curent));

                return;
            case "Show":
                int indexToShow = int.Parse(command[1]);
                Console.WriteLine(inputNumber[indexToShow]);
                return;
            default:
                break;
        }


    }
}
