using System;
using System.Text;

namespace SpecFlow.Extensions.Framework.ExtensionMethods
{
    public static class StringRandomize
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string digits = "1234567890";
        private static Random _random = new Random();

        public static string FeatureHash { get; set; }
        public static string ScenarioHash { get; set; }
        public static string TesterHash { get; set; }

        public static string Randomize(this string original, uint hashLength = 4, string hashDelimit = "-")
        {
            return original.RandomizeSelector(AppendFullHash, hashLength, hashDelimit);
        }

        public static string RandomizeNoTimestamp(this string original, uint hashLength = 4, string hashDelimit = "-")
        {
            return original.RandomizeSelector(AppendShortHash, hashLength, hashDelimit);
        }

        public static string RandomizeHashOnly(this string original, uint hashLength = 4, string hashDelimit = "-")
        {
            return original.RandomizeSelector(AppendHashOnly, hashLength, hashDelimit);
        }

        private static string RandomizeSelector(this string original, Func<string, uint, string, string> randomize, uint hashLength, string hashDelimit)
        {
            if (string.IsNullOrEmpty(original))
            {
                return randomize(original, hashLength, hashDelimit);
            }
            else if (original.HasHash(hashLength, hashDelimit))
            {
                return original.RandomizeHash(hashLength, hashDelimit);
            }
            else
            {
                return randomize(original, hashLength, hashDelimit);
            }
        }

        private static string AppendFullHash(this string original, uint hashLength, string hashDelimit)
        {
            return string.Format("{1}{2}{0}{3}{0}{4}", hashDelimit, original, GenerateTesterTestHash(hashDelimit), DateTime.Now.ToString("yyyyMMddHHmmssfff"), GenerateRandomHash(hashLength));
        }

        private static string AppendShortHash(this string original, uint hashLength, string hashDelimit)
        {
            return string.Format("{1}{2}{0}{3}", hashDelimit, original, GenerateTesterTestHash(hashDelimit), GenerateRandomHash(hashLength));
        }

        private static string AppendHashOnly(this string original, uint hashLength, string hashDelimit)
        {
            return string.Format("{1}{0}{2}", hashDelimit, original, GenerateRandomHash(hashLength));
        }

        private static string GenerateTesterTestHash(string hashDelimit)
        {
            string hash = string.Empty;
            if (!string.IsNullOrEmpty(TesterHash))
            {
                hash = string.Format("{1}{0}{2}", hashDelimit, hash, TesterHash);
            }
            if (!string.IsNullOrEmpty(FeatureHash))
            {
                hash = string.Format("{1}{0}{2}", hashDelimit, hash, FeatureHash);
            }
            if (!string.IsNullOrEmpty(ScenarioHash))
            {
                hash = string.Format("{1}{0}{2}", hashDelimit, hash, ScenarioHash);
            }
            return hash;
        }

        private static string RandomizeHash(this string hashString, uint hashLength, string hashDelimit)
        {
            return hashString.Substring(0, (hashString.Length - (hashString.Length - hashString.LastIndexOf(hashDelimit)) + 1)) + GenerateRandomHash(hashLength);
        }

        public static string GenerateRandomHash(uint hashLength = 4)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashLength; i++)
            {
                sb.Append(chars[_random.Next(chars.Length)]);
            }
            return sb.ToString();
        }

        public static string GenerateRandomNumber(uint length = 10)
        {
            if (length == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(digits[_random.Next(digits.Length - 1)]);
            for (int i = 1; i < length; i++)
            {
                sb.Append(digits[_random.Next(digits.Length)]);
            }
            return sb.ToString();
        }

        private static bool HasHash(this string hashString, uint hashLength, string hashDelimit)
        {
            return hashString.Contains(hashDelimit) && (hashString.LastIndexOf(hashDelimit) + hashDelimit.Length + hashLength == hashString.Length);
        }
    }
}