using System;
using NUnit.Framework;
using SB.Common.Logics.ExceptionTree;

namespace SB.Common.Test.Logics.ExceptionTree
{
    /// <summary>
    /// 
    /// </summary>
    public class ExceptionTreeBuilderTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void GetMemberDocumentationTest()
        {
            var exception = GetException();
            var builder = new ExceptionTreeBuilder();

            var rootNode = builder.Build(exception);
            Assert.AreEqual("Test Exception", rootNode.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Exception GetException()
        {
            try
            {
                throw new Exception("Test Exception");
            }
            catch (Exception e)
            {
                return e;
            }
        }
    }
}
