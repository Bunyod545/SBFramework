using System;

namespace SB.Common.Logics.Variables.Logics.VariableValue
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultVariableValueSetter : IVariableValueSetter
    {
        /// <summary>
        /// 
        /// </summary>
        public Variable Variable { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        public DefaultVariableValueSetter(Variable variable)
        {
            Variable = variable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetVariableValue(object value)
        {
            if (Variable.VariableService == null)
                throw new NotImplementedException(nameof(Variable.VariableService));

            Variable.VariableService.SetVariableValue(Variable, value);
        }
    }
}
