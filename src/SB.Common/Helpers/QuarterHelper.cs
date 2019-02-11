using System;

namespace SB.Common.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class QuarterHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public const int MonthCountInQuarter = 3;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetQuarterBegin(DateTime date)
        {
            var quarterNumber = GetQuarterNumber(date);
            var month = quarterNumber * MonthCountInQuarter - 2;
            return new DateTime(date.Year, month, 1).StartOfMonth();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetQuarterEnd(DateTime date)
        {
            var quarterNumber = GetQuarterNumber(date);
            var month = quarterNumber * 3;
            return new DateTime(date.Year, month, 1).EndOfMonth();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetQuarterNumber(DateTime date)
        {
            if (date.Month < 4)
                return 1;

            if (date.Month < 7)
                return 2;

            return date.Month < 10 ? 3 : 4;
        }
    }
}
