using System.Collections.Generic;

namespace Conditions.Utils
{
    internal static class DefaultComparer<T>
    {
        private static readonly Comparer<T> _defaultComparer;

        public static Comparer<T> Default
        {
            get
            {
                return _defaultComparer;
            }
        }

        static DefaultComparer()
        {
            _defaultComparer = Comparer<T>.Default;
        }
    }
}