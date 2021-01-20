using System;
using System.Collections;
using System.Collections.Generic;

namespace Verbess.Utils.Conditions
{
    /// <summary>
    /// Extension methods for the Collection.
    /// </summary>
    internal static class CollectionExtensions
    {
        internal static bool Contains<T>(IEnumerable<T> sequence, T value)
        {
            IEqualityComparer<T> comparer = EqualityComparer<T>.Default;

            foreach (T local in sequence)
            {
                if (comparer.Equals(local, value))
                {
                    return true;
                }
            }

            return false;
        }

        internal static bool Contains(IEnumerable sequence, object value)
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

        internal static bool ContainsAny<T>(IEnumerable<T> sequence, IEnumerable<T> values)
        {
            if (IsSequenceNullOrEmpty<T>(values))
            {
                return false;
            }

            if (IsSequenceNullOrEmpty<T>(sequence))
            {
                return false;
            }

            bool sequenceContainsNull;
            Dictionary<T, byte> set = ConvertToSet<T>(sequence, out sequenceContainsNull);

            foreach (T element in values)
            {
                if (element == null)
                {
                    if (sequenceContainsNull)
                    {
                        return true;
                    }
                }
                else
                {
                    if (set.ContainsKey(element))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        internal static bool ContainsAny(IEnumerable sequence, IEnumerable values)
        {
            if (IsSequenceNullOrEmpty(values))
            {
                return false;
            }

            if (IsSequenceNullOrEmpty(sequence))
            {
                return false;
            }

            bool sequenceContainsNull;
            Dictionary<object, byte> set = ConvertToSet(sequence, out sequenceContainsNull);

            foreach (object element in values)
            {
                if (element == null)
                {
                    if (sequenceContainsNull)
                    {
                        return true;
                    }
                }
                else
                {
                    if (set.ContainsKey(element))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        internal static bool ContainsAll<T>(IEnumerable<T> sequence, IEnumerable<T> values)
        {
            if (IsSequenceNullOrEmpty<T>(values))
            {
                return true;
            }

            if (IsSequenceNullOrEmpty<T>(sequence))
            {
                return false;
            }

            bool sequenceContainsNull;
            Dictionary<T, byte> set = ConvertToSet<T>(sequence, out sequenceContainsNull);

            foreach (T element in values)
            {
                if (element == null)
                {
                    if (!sequenceContainsNull)
                    {
                        return false;
                    }
                }
                else
                {
                    if (!set.ContainsKey(element))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        internal static bool ContainsAll(IEnumerable sequence, IEnumerable values)
        {
            if (IsSequenceNullOrEmpty(values))
            {
                return true;
            }

            if (IsSequenceNullOrEmpty(sequence))
            {
                return false;
            }

            bool sequenceContainsNull;
            Dictionary<object, byte> set = ConvertToSet(sequence, out sequenceContainsNull);

            foreach (object element in values)
            {
                if (element == null)
                {
                    if (!sequenceContainsNull)
                    {
                        return false;
                    }
                }
                else
                {
                    if (!set.ContainsKey(element))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        internal static bool SequenceHasLength(IEnumerable sequence, int numberOfElements)
        {
            if (sequence == null)
            {
                return numberOfElements == 0;
            }

            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                return collection.Count == numberOfElements;
            }

            IEnumerator enumerator = sequence.GetEnumerator();

            try
            {
                int lengthOfSequence = 0;

                while (enumerator.MoveNext())
                {
                    lengthOfSequence++;

                    if (lengthOfSequence > numberOfElements)
                    {
                        return false;
                    }
                }

                return lengthOfSequence == numberOfElements;
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

        internal static bool IsSequenceNullOrEmpty<TSource>(IEnumerable<TSource> sequence)
        {
            if (sequence == null)
            {
                return true;
            }

            ICollection<TSource> collection = sequence as ICollection<TSource>;

            if (collection != null)
            {
                return collection.Count == 0;
            }
            else
            {
                return IsSequenceNullOrEmpty((IEnumerable)sequence);
            }
        }

        internal static bool IsSequenceNullOrEmpty(IEnumerable sequence)
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
                return IsEnumerableEmpty(sequence);
            }
        }

        internal static bool SequenceIsShorterThan(IEnumerable sequence, int numberOfElements)
        {
            if (sequence == null)
            {
                return numberOfElements > 0;
            }

            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                return numberOfElements > collection.Count;
            }

            IEnumerator enumerator = sequence.GetEnumerator();

            try
            {
                int lengthOfSequence = 0;

                while (enumerator.MoveNext())
                {
                    lengthOfSequence++;

                    if (lengthOfSequence >= numberOfElements)
                    {
                        return false;
                    }
                }

                return numberOfElements > lengthOfSequence;
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

        internal static bool SequenceIsShorterOrEqual(IEnumerable sequence, int numberOfElements)
        {
            if (sequence == null)
            {
                return numberOfElements >= 0;
            }

            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                return numberOfElements >= collection.Count;
            }

            IEnumerator enumerator = sequence.GetEnumerator();
            try
            {
                int lengthOfSequence = 0;

                while (enumerator.MoveNext())
                {
                    lengthOfSequence++;

                    if (lengthOfSequence > numberOfElements)
                    {
                        return false;
                    }
                }

                return numberOfElements >= lengthOfSequence;
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

        internal static bool SequenceIsLongerThan(IEnumerable sequence, int numberOfElements)
        {
            if (sequence == null)
            {
                return numberOfElements < 0;
            }

            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                return collection.Count > numberOfElements;
            }

            IEnumerator enumerator = sequence.GetEnumerator();
            try
            {
                int lengthOfSequence = 0;

                while (enumerator.MoveNext())
                {
                    lengthOfSequence++;

                    if (lengthOfSequence > numberOfElements)
                    {
                        return true;
                    }
                }

                return lengthOfSequence > numberOfElements;
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

        internal static bool SequenceIsLongerOrEqual(IEnumerable sequence, int numberOfElements)
        {
            if (sequence == null)
            {
                return numberOfElements <= 0;
            }

            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                return collection.Count >= numberOfElements;
            }

            IEnumerator enumerator = sequence.GetEnumerator();
            try
            {
                int lengthOfSequence = 0;

                while (enumerator.MoveNext())
                {
                    lengthOfSequence++;

                    if (lengthOfSequence >= numberOfElements)
                    {
                        return true;
                    }
                }

                return lengthOfSequence >= numberOfElements;
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

        internal static int GetLength(IEnumerable sequence)
        {
            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                return collection.Count;
            }

            IEnumerator enumerator = sequence.GetEnumerator();

            try
            {
                int count = 0;

                while (enumerator.MoveNext())
                {
                    count++;
                }

                return count;
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

        private static bool IsEnumerableEmpty(IEnumerable sequence)
        {
            IEnumerator enumerator = sequence.GetEnumerator();

            try
            {
                return !enumerator.MoveNext();
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

        private static Dictionary<T, byte> ConvertToSet<T>(IEnumerable<T> sequence, out bool sequenceContainsNull)
        {
            sequenceContainsNull = false;

            int capacity = DetermineInitialCapacity<T>(sequence);

            Dictionary<T, byte> set = new Dictionary<T, byte>(capacity);

            foreach (T element in sequence)
            {
                if (element != null)
                {
                    const byte Dummy = 0;
                    set[element] = Dummy;
                }
                else
                {
                    sequenceContainsNull = true;
                }
            }

            return set;
        }

        private static int DetermineInitialCapacity<T>(IEnumerable<T> sequence)
        {
            ICollection<T> collection = sequence as ICollection<T>;

            if (collection != null)
            {
                return collection.Count;
            }
            else
            {
                return 0;
            }
        }

        private static Dictionary<object, byte> ConvertToSet(IEnumerable sequence, out bool sequenceContainsNull)
        {
            sequenceContainsNull = false;

            int capacity = DetermineInitialCapacity(sequence);

            Dictionary<object, byte> set = new Dictionary<object, byte>(capacity);

            foreach (object element in sequence)
            {
                if (element != null)
                {
                    const byte Dummy = 0;
                    set[element] = Dummy;
                }
                else
                {
                    sequenceContainsNull = true;
                }
            }

            return set;
        }

        private static int DetermineInitialCapacity(IEnumerable sequence)
        {
            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                return collection.Count;
            }
            else
            {
                return 0;
            }
        }
    }
}