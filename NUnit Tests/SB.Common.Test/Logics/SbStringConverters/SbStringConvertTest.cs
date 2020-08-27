using NUnit.Framework;
using SB.Common.Logics.SbStringConverters;
using SB.Common.Test.Logics.SbStringConverters.Models;

namespace SB.Common.Test.Logics.SbStringConverters
{
    /// <summary>
    /// 
    /// </summary>
    public class SbStringConvertTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void SerializeTest()
        {
            var obj = new SbStringTestModel();
            obj.Id = 5;
            obj.Name = "Test";

            var objText = SbStringConvert.Serialize(obj);
            Assert.AreEqual("5;Test;", objText);
        }
    }
}
