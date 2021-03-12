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
            return string.Format("€ {0:0,0.00}", amount);
        }
    }
}
