using NUnit.Framework;
using SB.Common.Logics.Summary;

namespace SB.Common.Test.Logics.Summary
{
    /// <summary>
    /// Summary manager text
    /// </summary>
    public class SummaryManagerTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void ClassSummaryText()
        {
            var summary = SummaryManager.GetSummary(typeof(SummaryManagerTest));
            Assert.AreEqual(summary, "\n            Summary manager text\n            ");
        }
    }
}
