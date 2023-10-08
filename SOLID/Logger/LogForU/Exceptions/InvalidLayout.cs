namespace LogForU.Exceptions
{
    public class InvalidLayout : Exception
    {
        private const string DefaltMessage = "Ivalid layout";
        public InvalidLayout() : base(DefaltMessage)
        {

        }

        public InvalidLayout(string message) : base(message)
        {

        }
    }
}
