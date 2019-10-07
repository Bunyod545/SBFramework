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
        public void VariablesTest()
        {
            var context = new TestVariableContext();
            context.InitializeVariables();

            var test =context.IsTest.Value;
            var age = context.Age.Value;
            var name = context.Name.Value;

            Assert.NotNull(context.Name);
            Assert.NotNull(context.Age);

            context.Name.SetValue(TestVaariableContextConstants.TestName);
            context.Age.SetValue(TestVaariableContextConstants.TestAge);

            Assert.AreEqual(context.Name.GetValue(), TestVaariableContextConstants.TestName);
            Assert.AreEqual(context.Age.GetValue(), TestVaariableContextConstants.TestAge);
        }
    }
}
