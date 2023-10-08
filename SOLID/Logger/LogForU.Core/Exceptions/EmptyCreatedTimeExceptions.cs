using System;

namespace LogForU.Core.Exceptions
{
    public class EmptyCreatedTimeExceptions : Exception
    {
        private const string DefaltMessage = "Created time of message cannot be null or whitespace";
        public EmptyCreatedTimeExceptions() : base(DefaltMessage)
        {

        }

        public EmptyCreatedTimeExceptions(string message) : base(message)
        {

        }
    }
}
