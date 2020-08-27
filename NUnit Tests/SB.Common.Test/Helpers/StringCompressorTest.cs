using NUnit.Framework;
using SB.Common.Helpers;
using System;
using System.Text;

namespace SB.Common.Test.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class StringCompressorTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void CompressDecompressTest()
        {
            var text = " asd  fdghfg d werwse uyiy uyui bn cvgbh dfgd fg";

            var bytes = Encoding.UTF8.GetBytes(text);
            var base64 = Convert.ToBase64String(bytes);

            var textLength = text.Length;
            var base64Length = base64.Length;

            var compressedText = StringCompressor.CompressString(text);
            var decompressedText = StringCompressor.DecompressString(compressedText);

            Assert.AreEqual(text, decompressedText);
        }
    }
}
