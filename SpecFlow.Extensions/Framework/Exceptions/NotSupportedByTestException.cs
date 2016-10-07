using System;

namespace SpecFlow.Extensions.Framework.Exceptions
{
    // denotes a code path or outcome that is intentionally not supported
    public class NotSupportedByTestException : NotSupportedException
    {
        public NotSupportedByTestException()
            : base()
        {
        }

        public NotSupportedByTestException(string message)
            : base(message)
        {
        }
    }
}