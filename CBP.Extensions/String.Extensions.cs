using System;

namespace CBP.Extensions
{
    public static class StringExtensions
    {
        const string STRING_NULL_ERROR = "string should not be null";

        public static string Truncate(this string value, int maxChars)
        {
            if (value.IsNull())
                throw new ArgumentNullException(nameof(value), STRING_NULL_ERROR);

            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }
    }
}