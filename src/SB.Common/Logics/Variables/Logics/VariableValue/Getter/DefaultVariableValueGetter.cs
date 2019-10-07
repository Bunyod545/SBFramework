using System;

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
        public Variable Variable { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public Type ValueType => Variable.ValueType;

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
            if (Variable.VariableService == null)
                throw new NotImplementedException(nameof(Variable.VariableService));

            var value = Variable.VariableService.GetVariableValue(Variable);
            if (value == null)
                return GetNullValueOrDefault();

            return Variable.VariableValueConverter.IsCanConvert(value) ? Variable.VariableValueConverter.Convert(value) : value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual object GetNullValueOrDefault()
        {
            if (ValueType.IsClass || ValueType.IsNullable())
                return null;

            if (ValueType.IsValueType)
                return Activator.CreateInstance(ValueType);

            return null;
        }
    }
}