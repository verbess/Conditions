using System;
using System.Collections;
using System.Collections.Generic;

namespace Conditions.Utils
{
    internal static class CollectionHelpers
    {
        public static bool IsNullOrEmpty<T>(IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                return true;
            }

            ICollection<T> collection = sequence as ICollection<T>;

            if (collection != null)
            {
                return collection.Count == 0;
            }
            else
            {
                int count;

                return IsEnumerableEmpty<T>(sequence, out count);
            }
        }

        public static bool IsNullOrEmpty(IEnumerable sequence)
        {
            if (sequence == null)
            {
                return true;
            }

            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                return collection.Count == 0;
            }
            else
            {
                int count;
                return IsEnumerableEmpty(sequence, out count);
            }
        }

        public static bool Contains<T>(IEnumerable<T> sequence, T value)
        {
            IEqualityComparer<T> comparer = EqualityComparer<T>.Default;

            foreach (T element in sequence)
            {
                if (comparer.Equals(element, value))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool Contains(IEnumerable sequence, object value)
        {
            Comparer<object> comparer = Comparer<object>.Default;

            foreach (object element in sequence)
            {
                if (comparer.Compare(element, value) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsEnumerableEmpty(IEnumerable sequence, out int count)
        {
            IEnumerator enumerator = sequence.GetEnumerator();
            count = 0;

            try
            {
                if (!enumerator.MoveNext())
                {
                    return true;
                }
                else
                {
                    while (enumerator.MoveNext())
                    {
                        count++;
                    }

                    return false;
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;

                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }

        private static bool IsEnumerableEmpty<T>(IEnumerable<T> sequence, out int count)
        {
            IEnumerator<T> enumerator = sequence.GetEnumerator();
            count = 0;

            try
            {
                if (!enumerator.MoveNext())
                {
                    return true;
                }
                else
                {
                    while (enumerator.MoveNext())
                    {
                        count++;
                    }

                    return false;
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;

                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }
    }
}