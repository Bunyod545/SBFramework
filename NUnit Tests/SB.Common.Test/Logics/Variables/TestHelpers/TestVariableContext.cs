using SB.Common.Logics.Variables;
using SB.Common.Logics.Variables.Attributes;

namespace SB.Common.Test.Logics.Variables.TestHelpers
{
    /// <summary>
    /// 
    /// </summary>
    [VariableService(typeof(TestVariableContextVariableService))]
    public class TestVariableContext
    {
        /// <summary>
        /// 
        /// </summary>
        public Variable<string> Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Variable<int> Age { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Variable<bool?> IsTest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void InitializeVariables()
        {
            VariableManager.Initialize(this);
        }
    }
}
