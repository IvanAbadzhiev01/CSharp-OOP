using System;

namespace LogForU.Core.Exceptions
{
    public class InvalidPathException : Exception
    {
        private const string DefaltMessage = "Path is invalid or empty";
        public InvalidPathException() : base(DefaltMessage)
        {

        }

        public InvalidPathException(string message) : base(message)
        {

        }
    }
}
