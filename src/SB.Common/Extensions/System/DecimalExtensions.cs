using SBCommon.Helpers;
using System.Globalization;

namespace SBCommon.Extensions.System
{
    /// <summary>
    /// 
    /// </summary>
    public static class DecimalExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToStringN(this decimal number)
        {
            var info = new NumberFormatInfo();
            info.NumberDecimalSeparator = Strings.Point;
            info.NumberGroupSeparator = Strings.WhiteSpace;

            return number.ToString("N", info).RemoveZeros();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberText"></param>
        /// <returns></returns>
        private static string RemoveZeros(this string numberText)
        {
            while (numberText.Contains(Strings.Point) && numberText.EndsWith(Strings.Zero))
                numberText = numberText.RemoveLastChar();

            if (numberText.EndsWith(Strings.Point))
                numberText = numberText.RemoveLastChar();

            return numberText;
        }
    }
}
