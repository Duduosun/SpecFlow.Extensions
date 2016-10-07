using System;

namespace SpecFlow.Extensions.Framework.Exceptions
{
    // denotes "to be implemented" code that is out-of-scope in the previous or current testing activity
    public class NotImplementedByTestException : NotImplementedException
    {
        public NotImplementedByTestException()
            : base()
        {
        }

        public NotImplementedByTestException(string message)
            : base(message)
        {
        }
    }
}