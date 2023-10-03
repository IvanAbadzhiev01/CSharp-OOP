using System;
using System.Linq;
using System.Net.Http.Headers;

public class StartUp
{
    public static void Main(string[] args)
    {
        string[] inputCardData = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries);

        List<Card> cards = new();

        foreach (string card in inputCardData)
        {
            string[] cardData = card.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string cardFace = cardData[0].ToString();
            string cardSuits = cardData[1].ToString();
            try
            {
                Card curentCard = new(cardFace, cardSuits);

                cards.Add(curentCard);


            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine(string.Join(" ", cards));

    }
}

public class Card
{

    private string cardFaces;
    private string cardSuits;


    private readonly string[] validCardFaces = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

    private readonly string[] validCardSuits = new string[] { "S", "H", "D", "C" };

    public Card(string cardFaces, string cardSuits)
    {
        CardFaces = cardFaces;
        CardSuits = cardSuits;
    }

    public string CardFaces
    {
        get
        {
            return cardFaces;
        }
        private set
        {
            if (!validCardFaces.Contains(value))
            {
                throw new ArgumentException("Invalid card!");
            }
            cardFaces = value;
        }
    }
    public string CardSuits
    {
        get
        {
            return cardSuits;
        }
        private set
        {
            if (!validCardSuits.Contains(value))
            {
                throw new ArgumentException("Invalid card!");
            }
            cardSuits = value;
        }
    }

    public override string ToString()
    {
        Dictionary<string, char> keyValuePairs = new()
        {
            { "S", '\u2660'},
            {"H", '\u2665' },
            {"D", '\u2666' },
            {"C", '\u2663' }
        };

        return $"[{cardFaces}{keyValuePairs[cardSuits]}]";
    }
}