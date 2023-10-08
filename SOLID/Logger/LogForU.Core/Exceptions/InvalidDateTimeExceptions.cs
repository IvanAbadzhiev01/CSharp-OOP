
using System;

namespace LogForU.Core.Exceptioms
{
    public class InvalidDateTimeExceptions : Exception
    {
        private const string DefaltMessage = "Invalid DateTime format";

        public InvalidDateTimeExceptions() : base(DefaltMessage)
        {

        }

        public InvalidDateTimeExceptions(string text) : base(text)
        {

        }

    }
}
