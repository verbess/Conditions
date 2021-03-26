using System;
using System.Collections;
using System.Collections.Generic;

namespace Conditions.Utils
{
    /// <summary>
    /// An internal helper class with extension methods for converting an object to a string representation.
    /// </summary>
    internal static class ConvertExtensions
    {
        private const int MaximumOfRecursiveCalls = 10;

        public static string ConvertToString(this object value)
        {
            try
            {
                return ConvertToStringInternal(value, MaximumOfRecursiveCalls);
            }
            catch (InvalidOperationException)
            {
                return value.ToString();
            }
        }

        private static string ConvertToStringInternal(object value, int maximumOfRecursiveCalls)
        {
            if (value == null)
            {
                return "null";
            }

            if (maximumOfRecursiveCalls < 0)
            {
                throw new InvalidOperationException();
            }

            if ((value is String) || (value is Char))
            {
                return String.Concat("'", value, "'");
            }

            IEnumerable collection = value as IEnumerable;

            if (collection != null)
            {
                return ConvertCollectionToString(collection, maximumOfRecursiveCalls);
            }
            else
            {
                return value.ToString();
            }
        }

        private static string ConvertCollectionToString(IEnumerable collection, int maximumOfRecursiveCalls)
        {
            List<string> stringifiedElements = new List<string>();

            foreach (object o in collection)
            {
                maximumOfRecursiveCalls--;
                string stringifiedElement = ConvertToStringInternal(o, maximumOfRecursiveCalls);

                stringifiedElements.Add(stringifiedElement);
            }

            return String.Concat("{", String.Join(",", stringifiedElements.ToArray()), "}");
        }
    }
}