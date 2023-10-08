namespace LogForU.Exceptions
{
    public class InvaidAppenderType : Exception
    {
        private const string DefaltMessage = "Ivalid appender type";
        public InvaidAppenderType() : base(DefaltMessage)
        {

        }

        public InvaidAppenderType(string message) : base(message)
        {

        }
    }
}
