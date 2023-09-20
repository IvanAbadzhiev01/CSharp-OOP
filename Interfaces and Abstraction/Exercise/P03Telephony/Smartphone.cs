namespace Telephony
{
    public class Smartphone : ISmartphone
    {
        public string Browsing(string url)
        {
            bool containsInt = url.Any(char.IsDigit);
            if (containsInt)
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {url}!";
        }

        public string Calling(string number)
        {
            bool isIntString = number.All(char.IsDigit);
            if (!isIntString)
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {number}";
        }
    }
}
