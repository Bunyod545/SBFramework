using NUnit.Framework;
using SB.Common.Test.Logics.Variables.TestHelpers;

namespace SB.Common.Test.Logics.Variables
{
    /// <summary>
    /// 
    /// </summary>
    public class VariableManagerTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void InitializeTest()
        {
            var context = new TestVariableContext();
            context.InitializeVariables();

            Assert.NotNull(context.Name);
            Assert.NotNull(context.Age);

            context.Name.SetValue("");
        }
    }
}
