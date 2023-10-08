namespace LogForU.Exceptions
{
    public class InvalidReportLevelExceptions : Exception
    {
        private const string DefaltMessage = "Ivalid report level";
        public InvalidReportLevelExceptions() : base(DefaltMessage)
        {

        }

        public InvalidReportLevelExceptions(string message) : base(message)
        {

        }
    }
}
