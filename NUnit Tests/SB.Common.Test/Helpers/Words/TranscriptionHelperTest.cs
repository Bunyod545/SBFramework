using NUnit.Framework;
using SB.Common.Helpers.Words;
using System.Collections.Generic;
using System.Linq;

namespace SB.Common.Test.Helpers.Words
{
    /// <summary>
    /// 
    /// </summary>
    public class TranscriptionHelperTest
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<string, string> expects = new Dictionary<string, string>
        {
            { "Привет", "privet" },
            { "Мир", "mir" },
            { "АПРЕЛЬ", "aprel" },
            { "ҚЎРҒОШЫН", "qo'rg'oshin" },
            { "Ящил", "yashil" },
            { "цемент", "sement" }
        };

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TranslateTest()
        {
            var expectsList = expects.ToList();
            expectsList.ForEach(f => TranslateTestElement(f.Key, f.Value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        private void TranslateTestElement(string value, string expected)
        {
            var result = TranscriptionHelper.Translate(value);
            Assert.AreEqual(expected, result);
        }
    }
}
