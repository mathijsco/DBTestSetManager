using System;
using System.Collections.Generic;

namespace DatabaseTestSetManager
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null) throw new ArgumentNullException("collection");
            if (action == null) throw new ArgumentNullException("action");

            foreach (var item in collection)
                action(item);
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T, int> action)
        {
            if (collection == null) throw new ArgumentNullException("collection");
            if (action == null) throw new ArgumentNullException("action");

            var index = 0;
            foreach (var item in collection)
                action(item, index++);
        }

        public static int? FindIndex<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            if (collection == null) throw new ArgumentNullException("collection");
            if (predicate == null) throw new ArgumentNullException("predicate");

            int rv = 0;
            foreach (var item in collection)
            {
                if (predicate(item))
                    return rv;
                rv++;
            }
            return null;
        }
    }
}
