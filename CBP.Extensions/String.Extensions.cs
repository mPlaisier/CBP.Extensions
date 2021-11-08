using System;

namespace CBP.Extensions
{
    public static class StringExtensions
    {
        const string STRING_NULL_ERROR = "string should not be null";
        const string STRING_EMPTY_ERROR = "string cannot be empty";

        public static string Truncate(this string value, int maxChars)
        {
            if (value.IsNull())
                throw new ArgumentNullException(nameof(value), STRING_NULL_ERROR);

            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }

        public static string FirstCharToUpper(this string input)
        {
            return input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException(STRING_EMPTY_ERROR, nameof(input)),
                _ => input[0].ToString().ToUpper() + input[1..]
            };
        }
    }
}