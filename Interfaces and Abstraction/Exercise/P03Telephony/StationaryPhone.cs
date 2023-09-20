namespace Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public string Dialing(string number)
        {
            bool isIntString = number.All(char.IsDigit);
            if (!isIntString)
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Dialing... {number}";
        }
    }
}
