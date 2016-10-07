using System;

namespace SpecFlow.Extensions.Framework.ExtensionMethods
{
    public static class ByteArrayExtension
    {
        public static string ToHexadecimalDelimitedString(this Array array)
        {
            if (array is byte[])
            {
                return string.Format("0x{0}", BitConverter.ToString((byte[])array));
            }
            throw new NotSupportedException(array.GetType().Name);
        }

        public static string ToHexadecimalString(this Array array)
        {
            if (array is byte[])
            {
                return ToHexadecimalDelimitedString(array).Replace("-", string.Empty);
            }
            throw new NotSupportedException(array.GetType().Name);
        }
    }
}