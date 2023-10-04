Dictionary<int, double> keyValuePairs = new();



ReadBankAcount();

string command;
while ((command = Console.ReadLine()) != "End")
{
    string[] cmdArgs = command.Split();
    string cmdType = cmdArgs[0];
    int accountNumber = int.Parse(cmdArgs[1]);
    double sum = double.Parse(cmdArgs[2]);

    try
    {
        if (!keyValuePairs.ContainsKey(accountNumber))
        {
            throw new ArgumentException("Invalid account!");
        }

        switch (cmdType)
        {
            case "Deposit":
                keyValuePairs[accountNumber] += sum;
                Console.WriteLine($"Account {accountNumber} has new balance: {keyValuePairs[accountNumber]:F2}");
                Console.WriteLine("Enter another command");
                break;
            case "Withdraw":
                if (keyValuePairs[accountNumber] - sum < 0)
                {
                    throw new InvalidOperationException("Insufficient balance!");
                }
                keyValuePairs[accountNumber] -= sum;
                Console.WriteLine($"Account {accountNumber} has new balance: {keyValuePairs[accountNumber]:F2}");
                Console.WriteLine("Enter another command");
                break;
            default:
                throw new ArgumentException("Invalid command!");

        }
    }
    catch (ArgumentException ax)
    {

        Console.WriteLine(ax.Message);
        Console.WriteLine("Enter another command");
    }
    catch (InvalidOperationException ix)
    {
        Console.WriteLine(ix.Message);
        Console.WriteLine("Enter another command");
    }



}

void ReadBankAcount()
{
    string[] inputBankAcount = Console.ReadLine()
        .Split(",");

    foreach (string account in inputBankAcount)
    {
        string[] accountData = account.Split("-");

        int accountNumber = int.Parse(accountData[0]);
        double balance = double.Parse(accountData[1]);

        keyValuePairs[accountNumber] = balance;
    }
}