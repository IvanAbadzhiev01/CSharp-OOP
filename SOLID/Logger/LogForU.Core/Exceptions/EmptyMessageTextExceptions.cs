
using System;

namespace LogForU.Core.Exceptioms
{
    public class EmptyMessageTextExceptions : Exception
    {
        private const string DefaltMessage = "Message text cannot be null or whitespace";

        public EmptyMessageTextExceptions() : base(DefaltMessage)
        {

        }

        public EmptyMessageTextExceptions(string text) : base(text)
        {

        }


    }
}
