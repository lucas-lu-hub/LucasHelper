using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Adds an item to the collection if it's not already in the collection.
        /// </summary>
        /// <param name="source">The collection</param>
        /// <param name="item">Item to check and add</param>
        /// <typeparam name="T">Type of the items in the collection</typeparam>
        /// <returns>Returns True if added, returns False if not.</returns>
        public static bool AddIfNotContains<T>(this ICollection<T> source, T item)
        {
            if (source.Contains(item))
            {
                return false;
            }
            source.Add(item);
            return true;
        }

        /// <summary>
        /// Adds items to the collection if it's not already in the collection.
        /// </summary>
        /// <param name="source">The collection</param>
        /// <param name="items">Items to check and add</param>
        /// <typeparam name="T">Type of the items in the collection</typeparam>
        /// <returns>Returns add success count.</returns>
        public static int AddRangeIfNotContains<T>(this ICollection<T> source, ICollection<T> items)
        {
            var result = 0;
            foreach(var item in items)
            {
                if (source.Contains(item))
                {
                    continue;
                }

                source.Add(item);
                result++;
            }
            return result;
        }

        /// <summary>
        /// Remove items from source
        /// </summary>
        /// <typeparam name="T">Type of the items in the collection</typeparam>
        /// <param name="source">The collection</param>
        /// <param name="items">target items</param>
        public static void RemoveRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                source.Remove(item);
            }
        }

        public static bool IsNullOrEmpty<T>(this ICollection<T> list)
        {
            return list == null || list.Count == 0;
        }

        public static bool HasValue<T>(this ICollection<T> list)
        {
            return list != null && list.Count > 0;
        }


        /// <summary>
        /// Solves the problem that <see cref="List{T}"/> has no index in its loop processing
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="handler"></param>
        public static void ForEach<T>(this List<T> source, Action<T, int> handler)
        {
            int idx = 0;
            foreach (var item in source)
                handler(item, idx++);
        }
    }
}
