using System;
using System.Collections;
using System.Collections.Generic;

namespace Verbess.Utils.Conditions
{
    /// <summary>
    /// An internal helper class with extension methods for converting an object to a string representation.
    /// </summary>
    internal static class StringifyExtensions
    {
        private const int MaximumNumberOfRecursiveCalls = 10;

        /// <summary>
        /// Transforms an object into a string representation that can be used to represent it's value in an
        /// exception message. When the value is a null reference, the string "null" will be returned, when 
        /// the specified value is a string or a char, it will be surrounded with single quotes.
        /// </summary>
        /// <param name="value">The value to be transformed.</param>
        /// <returns>A string representation of the supplied <paramref name="value"/>.</returns>
        public static string Stringify(this object value)
        {
            try
            {
                return StringifyCore(value, MaximumNumberOfRecursiveCalls);
            }
            catch (InvalidOperationException)
            {
                return value.ToString();
            }
        }

        private static string StringifyCore(object value, int maximumNumberOfRecursiveCalls)
        {
            if (value == null)
            {
                return "null";
            }

            if (maximumNumberOfRecursiveCalls < 0)
            {
                throw new InvalidOperationException();
            }

            if ((value is string) || (value is char))
            {
                return String.Concat("'", value, "'");
            }

            IEnumerable collection = value as IEnumerable;

            if (collection != null)
            {
                return StringifyCollection(collection, maximumNumberOfRecursiveCalls);
            }
            else
            {
                return value.ToString();
            }
        }

        private static string StringifyCollection(IEnumerable collection, int maximumNumberOfRecursiveCalls)
        {
            List<string> stringifiedElements = new List<string>();

            foreach (object o in collection)
            {
                string stringifiedElement = StringifyCore(o, maximumNumberOfRecursiveCalls - 1);

                stringifiedElements.Add(stringifiedElement);
            }

            return String.Concat("{", String.Join(",", stringifiedElements.ToArray()), "}");
        }
    }
}