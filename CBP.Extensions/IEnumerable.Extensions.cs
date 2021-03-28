using System;
using System.Collections.Generic;
using System.Linq;

namespace CBP.Extensions
{
    public static class IEnumerableExtensions
    {
        const string ENUM_NULL_OR_EMPTY_ERROR = "enumerable should not be null or empty.";

        /// <summary>
        /// Determines whether the <paramref name="enumerable"/> is null or contains no elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return true;

            /* If this is a list, use the Count property for efficiency. 
             * The Count property is O(1) while IEnumerable.Count() is O(N). */
            return enumerable is ICollection<T> collection ? collection.Count == 0 : !enumerable.Any();
        }

        /// <summary>
        /// Determines whether <paramref name="enumerable"/> is not null and contains elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool IsNotNullAndHasItems<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return false;

            /* If this is a list, use the Count property for efficiency. 
            * The Count property is O(1) while IEnumerable.Count() is O(N). */
            return enumerable is ICollection<T> collection ? collection.Count != 0 : enumerable.Any();
        }

        public static void ForEach<T>(this IEnumerable<T> @enumerable, Action<T> mapFunction)
        {
            if (enumerable.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(enumerable), ENUM_NULL_OR_EMPTY_ERROR);

            if (enumerable is List<T> collection)
                collection.ForEach(mapFunction);
            else
            {
                foreach (var item in @enumerable)
                    mapFunction(item);
            }
        }

        /// <summary>
        /// Execute <paramref name="mapFunction"/> for each item of <typeparamref name="S"/> in <paramref name="enumerable"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="mapFunction"></param>
        public static void ForEachType<T, S>(this IEnumerable<T> @enumerable, Action<S> mapFunction) where S : T
        {
            enumerable.OfType<S>().ForEach(mapFunction);
        }

        /// <summary>
        /// Get count of all elements of <typeparamref name="S"/> in <paramref name="enumerable"/> of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static int Count<S, T>(this IEnumerable<T> enumerable) where S : T
        {
            return enumerable.OfType<S>().Count();
        }

        /// <summary>
        /// Get count with <paramref name="predicate"/> of all elements of <typeparamref name="S"/> in <paramref name="enumerable"/> of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static int Count<T, S>(this IEnumerable<T> enumerable, Func<S, bool> predicate)
        {
            return enumerable.OfType<S>().Count(predicate);
        }
    }
}
