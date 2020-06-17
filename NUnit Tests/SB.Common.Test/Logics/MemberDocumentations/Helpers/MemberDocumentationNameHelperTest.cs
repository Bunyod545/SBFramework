using System;
using System.Reflection;
using NUnit.Framework;
using SB.Common.Logics.MemberDocumentations;

namespace SB.Common.Test.Logics.MemberDocumentations.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class MemberDocumentationNameHelperTest
    {
        /// <summary>
        /// 
        /// </summary>
        private string _testField;

        /// <summary>
        /// 
        /// </summary>
        public string TestProperty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler TestEvent;

        /// <summary>
        /// 
        /// </summary>
        public MemberDocumentationNameHelperTest()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestTypeName()
        {
            var type = GetType();
            Assert.NotNull(type);

            var fieldDocName = MemberDocumentationNameHelper.GetNodeName(type);
            var expected = "T:SB.Common.Test.Logics.MemberDocumentations.Helpers.MemberDocumentationNameHelperTest";
            Assert.AreEqual(expected, fieldDocName);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestFieldName()
        {
            var field = GetType().GetField(nameof(_testField), BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(field);

            var fieldDocName = MemberDocumentationNameHelper.GetNodeName(field);
            var expected = "F:SB.Common.Test.Logics.MemberDocumentations.Helpers.MemberDocumentationNameHelperTest._testField";
            Assert.AreEqual(expected, fieldDocName);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestPropertyName()
        {
            var property = GetType().GetProperty(nameof(TestProperty));
            Assert.NotNull(property);

            var fieldDocName = MemberDocumentationNameHelper.GetNodeName(property);
            var expected = "P:SB.Common.Test.Logics.MemberDocumentations.Helpers.MemberDocumentationNameHelperTest.TestProperty";
            Assert.AreEqual(expected, fieldDocName);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestEventName()
        {
            var testEvent = GetType().GetEvent(nameof(TestEvent));
            Assert.NotNull(testEvent);

            var fieldDocName = MemberDocumentationNameHelper.GetNodeName(testEvent);
            var expected = "E:SB.Common.Test.Logics.MemberDocumentations.Helpers.MemberDocumentationNameHelperTest.TestEvent";
            Assert.AreEqual(expected, fieldDocName);
        }
    }
}
