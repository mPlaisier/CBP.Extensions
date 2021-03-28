using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CBP.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Find the Index of a certain item with a <paramref name="predicate"/> in <paramref name="collection"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int FindIndex<T>(this Collection<T> collection, Func<T, bool> predicate) where T : class
        {
            if (collection.IsNullOrEmpty())
                return -1;

            var item = collection.FirstOrNull(predicate);
            return collection.IndexOf(item);
        }

        /// <summary>
        /// Adds <paramref name="enumerable"/> at <paramref name="index"/> in <paramref name="collection"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="index"></param>
        /// <param name="enumerable"></param>
        public static void InsertRange<T>(this Collection<T> collection, int index, IEnumerable<T> enumerable)
        {
            if (collection.IsNull())
                throw new ArgumentNullException(nameof(collection));
            if (enumerable.IsNull())
                throw new ArgumentNullException(nameof(enumerable));

            int currentIndex = index;
            var changedItems = collection is List<T> ? (List<T>)enumerable : new List<T>(enumerable);
            foreach (var i in changedItems)
            {
                collection.Insert(currentIndex, i);
                currentIndex++;
            }
        }

        /// <summary>
        /// Adds <paramref name="enumerable"/> at <paramref name="index"/> of the <paramref name="collection"/>. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="index"></param>
        /// <param name="enumerable"></param>
        public static void InsertRange<T>(this ObservableCollection<T> collection, int index, IEnumerable<T> enumerable)
        {
            if (collection.IsNull())
                throw new ArgumentNullException(nameof(collection));
            if (enumerable.IsNull())
                throw new ArgumentNullException(nameof(enumerable));

            int currentIndex = index;
            var changedItems = new List<T>(enumerable);
            foreach (var i in changedItems)
            {
                collection.Insert(currentIndex, i);
                currentIndex++;
            }
        }

        /// <summary>
        /// Removes the first occurence of each item of <paramref name="enumerable"/> in <paramref name="collection"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="enumerable"></param>
        public static void RemoveRange<T>(this Collection<T> collection, IEnumerable<T> enumerable)
        {
            if (collection.IsNull())
                throw new ArgumentNullException(nameof(collection));
            if (enumerable.IsNull())
                throw new ArgumentNullException(nameof(enumerable));

            //fix error when enumerable is from the Collection
            //Error: Collection was modified; enumeration operation may not execute
            foreach (var item in enumerable.ToList())
                collection.Remove(item);
        }
    }
}