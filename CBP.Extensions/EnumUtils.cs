using System;
using System.Collections.Generic;
using System.Linq;

namespace CBP.Extensions
{
    public static class EnumUtil
    {
        /// <summary>
        /// Get list of all enum values of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        /// <summary>
        /// Get list of all enum values of <typeparamref name="T"/> Except the Unkown value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetValuesExceptUnknown<T>() where T : Enum
        {
            var values = Enum.GetValues(typeof(T)).Cast<T>().Where(x => !x.ToString().Equals("Unknown"));

            return values;
        }
    }
}