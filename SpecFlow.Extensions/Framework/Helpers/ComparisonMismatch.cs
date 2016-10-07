using System;
using System.Collections.Generic;

namespace SpecFlow.Extensions.PageObjects
{
    public class ComparisonMismatch
    {
        private List<string> _mismatches = new List<string>();
        public IReadOnlyList<string> Mismatches { get { return _mismatches; } }

        public int Errors { get { return Mismatches.Count; } }

        public bool IsExact { get { return Mismatches.Count == 0; } }

        public void Add(string message)
        {
            _mismatches.Add(message);
        }

        public bool IsTrue(bool expression, string message)
        {
            if (!expression)
            {
                _mismatches.Add(message);
            }
            return expression;
        }

        public bool IsFalse(bool expression, string message)
        {
            if (expression)
            {
                _mismatches.Add(message);
            }
            return expression;
        }

        public bool Compare<T>(T expected, T actual, string message)
        {
            return Compare<T>(expected, actual, (T a, T b) => (a.Equals(b)), message);
        }

        public bool Compare<T>(T expected, T actual, Func<T, T, bool> compareMethod, string message)
        {
            return CompareInternal<T>(expected, actual, compareMethod,
                string.Format("{0}: expected '{1}' but was '{2}'", message, expected.ToString(), actual.ToString()));
        }

        private bool CompareInternal<T>(T expected, T actual, Func<T, T, bool> compareMethod, string message)
        {
            bool isExact = compareMethod(expected, actual);
            if (!isExact)
            {
                _mismatches.Add(message);
            }
            return isExact;
        }
    }
}
