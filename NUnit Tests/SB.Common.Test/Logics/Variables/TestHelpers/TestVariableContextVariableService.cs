using System.Collections.Generic;
using SB.Common.Logics.Variables;
using SB.Common.Logics.Variables.Interfaces;

namespace SB.Common.Test.Logics.Variables.TestHelpers
{
    /// <summary>
    /// 
    /// </summary>
    public class TestVariableContextVariableService : IVariableService
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<string, object> VariableObjects = new Dictionary<string, object>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public object GetVariableValue(Variable variable)
        {
           return VariableObjects.GetValueOrDefault(variable.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        public void SetVariableValue(Variable variable, object value)
        {
            VariableObjects.TryAdd(variable.Name, value);
        }
    }
}
