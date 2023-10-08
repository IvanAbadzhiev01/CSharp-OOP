using System;

namespace LogForU.Core.Exceptions
{
    public class EmptyFileNameException : Exception
    {
        private const string DefaltMessage = "File name cannot be null or whitespace";
        public EmptyFileNameException() : base(DefaltMessage)
        {

        }

        public EmptyFileNameException(string message) : base(message)
        {

        }
    }
}
