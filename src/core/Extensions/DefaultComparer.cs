using System.Collections.Generic;

namespace Verbess.Utils.Conditions
{
    public static class DefaultComparer<T>
    {
        private static readonly Comparer<T> defaultComparer;

        public static Comparer<T> Default
        {
            get => defaultComparer;
        }

        static DefaultComparer()
        {
            defaultComparer = Comparer<T>.Default;
        }
    }
}