using System;
namespace CBP.Extensions
{
    public static class ClassExtensions
    {
        /// <summary>
        /// Checks if the object is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>Returns true if the object is null</returns>
        public static bool IsNull<T>(this T obj) where T : class
        {
            return obj == null;
        }

        /// <summary>
        /// Checks if the object is not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>Returns true is the object is not null</returns>
        public static bool IsNotNull<T>(this T obj) where T : class
        {
            return obj != null;
        }

        /// <summary>
        /// Throw ArgumentNullException if object is null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ThrowIfNull<T>(this T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
    }
}
