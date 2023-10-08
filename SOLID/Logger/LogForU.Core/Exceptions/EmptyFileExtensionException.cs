using System;

namespace LogForU.Core.Exceptions
{
    public class EmptyFileExtensionException : Exception
    {
        private const string DefaltMessage = "File extension cannot be null or whitespace";
        public EmptyFileExtensionException() : base(DefaltMessage)
        {

        }

        public EmptyFileExtensionException(string message) : base(message)
        {

        }
    }
}
