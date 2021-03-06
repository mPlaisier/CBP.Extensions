using System;

namespace CBP.Extensions
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// Returns a decimal with 2 decimal values.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string DefaultFormat(this decimal amount)
        {
            return "€ " + amount.ToString("#,0.00");
        }

        /// <summary>
        /// Returns a decimal with 2 decimal values. Choose if the amount should be negative or positive.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="shouldBeNegative"></param>
        /// <returns></returns>
        public static string DefaultFormat(this decimal amount, bool shouldBeNegative)
        {
            return shouldBeNegative
                       ? DefaultNegativeFormat(amount)
                       : DefaultFormat(Math.Abs(amount));
        }

        /// <summary>
        /// Returns a negative decimal with 2 decimal values. 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string DefaultNegativeFormat(this decimal amount)
        {
            return "€ -" + Math.Abs(amount).ToString("#,0.00");
        }
    }
}
