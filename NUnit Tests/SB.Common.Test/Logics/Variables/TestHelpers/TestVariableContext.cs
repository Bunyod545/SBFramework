using SB.Common.Logics.Variables;
using SB.Common.Logics.Variables.Attributes;
using System.ComponentModel;

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
        [DefaultValue(TestVaariableContextConstants.TestDefaultValue)]
        public Variable<int> DefaultValueTest { get; set; }

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
