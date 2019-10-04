using System;
using SB.Common.Logics.Variables.Logics.ValueConverter;

namespace SB.Common.Logics.Variables.Logics.VariableValue
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultVariableValueGetter : IVariableValueGetter
    {
        /// <summary>
        /// 
        /// </summary>
        public IVariableValueConverter ValueConverter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Variable Variable { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        public DefaultVariableValueGetter(Variable variable)
        {
            Variable = variable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object GetVariableValue()
        {
            if(Variable.VariableService == null)
                throw new NotImplementedException(nameof(Variable.VariableService));

            var value = Variable.VariableService.GetVariableValue(Variable);
            if (ValueConverter.IsCanConvert(Variable, value))
                return ValueConverter.Convert(Variable, value);

            return value;
        }
    }
}