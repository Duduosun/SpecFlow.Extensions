using System;

namespace SpecFlow.Extensions.Framework.Exceptions
{
    // denotes an invalid test case or impossible usage, aka "DO NOT TEST"
    public class InvalidTestException : NotSupportedException
    {
        public InvalidTestException()
            : base()
        {
        }

        public InvalidTestException(string message)
            : base(message)
        {
        }
    }
}