using System.Collections.Generic;

namespace Conditions.Utils
{
    internal static class DefaultComparer<T>
    {
        private static readonly Comparer<T> defaultComparer;

        public static Comparer<T> Default
        {
            get
            {
                return defaultComparer;
            }
        }

        static DefaultComparer()
        {
            defaultComparer = Comparer<T>.Default;
        }
    }
}