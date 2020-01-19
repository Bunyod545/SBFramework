using System;
using NUnit.Framework;

namespace SB.Common.Test.Extensions.System
{
    /// <summary>
    /// 
    /// </summary>
    public class DateTimeExtensionsTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void BeginOfDay()
        {
            var dateTime = DateTime.Now;
            var exceptedResult = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);

            Assert.AreEqual(exceptedResult, dateTime.BeginOfDay());
        }
    }
}