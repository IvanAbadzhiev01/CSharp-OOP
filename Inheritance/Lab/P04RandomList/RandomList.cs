using System.Globalization;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            string randomString = this[random.Next(0, Count)];
            this.Remove(randomString);


            return randomString;
        }


    }
}
