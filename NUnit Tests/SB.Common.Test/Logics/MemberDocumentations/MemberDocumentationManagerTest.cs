using NUnit.Framework;
using SB.Common.Logics.MemberDocumentations;
using SB.Common.Test.Logics.MemberDocumentations.Models;

namespace SB.Common.Test.Logics.MemberDocumentations
{
    /// <summary>
    /// 
    /// </summary>
    public class MemberDocumentationManagerTest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <test>test</test>
        /// <test2>test2</test2>
        /// <test3>test3</test3>
        public string TestProperty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void GetMemberDocumentationTest()
        {
            var property = GetType().GetProperty(nameof(TestProperty));
            var info = MemberDocumentationManager.GetMemberDocumentation<TestMemberDocumentationInfo>(property);
            
            Assert.AreEqual("test", info.Test);
            Assert.AreEqual("test2", info.Test2);
            Assert.AreEqual("test3", info.Test3);
        }
    }
}
