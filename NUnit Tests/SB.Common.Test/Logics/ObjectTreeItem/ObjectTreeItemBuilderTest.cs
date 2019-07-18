using System;
using NUnit.Framework;
using SB.Common.Logics.ObjectTreeItem;

namespace SB.Common.Test.Logics.ObjectTreeItem
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectTreeItemBuilderTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void BuildExceptionNodes()
        {
            var exception = GetException();
            var node = ObjectTreeItemBuilder<ExceptionTreeItemNode>.Create().Build(exception);
        }

        private Exception GetException()
        {
            try
            {
                throw new ArgumentException("Test");
            }
            catch (Exception e)
            {
                return e;
            }
        }
    }
}
