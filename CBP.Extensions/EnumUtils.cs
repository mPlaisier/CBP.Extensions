using System;
using System.Collections.Generic;
using System.Linq;

namespace CBP.Extensions
{
    public static class EnumUtil
    {
        public static IEnumerable<T> GetValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}