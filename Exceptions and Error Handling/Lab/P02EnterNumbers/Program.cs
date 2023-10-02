List<int> numbers = new();
int start = 1;
int end = 100;
while (numbers.Count < 10)
{
    try
    {
        start = ReadNumber(start, end);

    }
    catch (ArgumentException ex)
    {

        Console.WriteLine(ex.Message);
    }
    catch (FormatException fx)
    {
        Console.WriteLine(fx.Message);
    }
}
Console.WriteLine(string.Join(", ", numbers));



int ReadNumber(int start, int end)
{
    string input = Console.ReadLine();

    if (int.TryParse(input, out int number))
    {

        if (number > start && number < end)
        {
            numbers.Add(number);

        }
        else
        {
            throw new ArgumentException($"Your number is not in range {start} - 100!");
        }

    }
    else
    {
        throw new FormatException("Invalid Number!");
    }


    return number;
}