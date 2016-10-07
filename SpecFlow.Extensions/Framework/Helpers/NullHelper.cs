namespace SpecFlow.Extensions.Framework.Helpers
{
    public static class NullHelper
    {
        /* http://stackoverflow.com/questions/4958379/what-is-the-difference-between-null-and-system-dbnull-value
         * Have two representations of "null" is a bad design for no apparent benefit.
         *
         * I get it. Null and DBNull are not the same and are two completely different concepts.
         * That being said, I don't want test code to constantly check / handle this nuance every time.
         * To that end, null is null (invalid or nothing) which the test code will generally handle the same way
         *  (with rare exception, of course).
         */

        public static bool IsNull(object obj)
        {
            if (obj == null)
                return true;

            if (obj is System.DBNull)
                return true;

            return false;
        }
    }
}