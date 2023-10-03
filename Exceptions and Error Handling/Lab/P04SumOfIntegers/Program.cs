using System.Xml.Linq;

string[] elementsInput = Console.ReadLine()
    .Split();
int sumOfValidInteger = 0;

foreach (var element in elementsInput)
{
    try
    {
        if (int.TryParse(element, out int number))
        {
            sumOfValidInteger += number;
            Console.WriteLine($"Element '{element}' processed - current sum: {sumOfValidInteger}");
        }
        else
        {

            int intpars = int.Parse(element);

        }
    }
    catch (FormatException)
    {
        Console.WriteLine($"The element '{element}' is in wrong format!");
        Console.WriteLine($"Element '{element}' processed - current sum: {sumOfValidInteger}");
    }
    catch (OverflowException)
    {
        Console.WriteLine($"The element '{element}' is out of range!");
        Console.WriteLine($"Element '{element}' processed - current sum: {sumOfValidInteger}");
    }


}



Console.WriteLine($"The total sum of all integers is: {sumOfValidInteger}");

