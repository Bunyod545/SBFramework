using System;
using SB.Common.Logics.Variables.Logics.ValueConverter;

namespace SB.Common.Logics.Variables.Logics
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultVariableValueConverter : IVariableValueConverter
    {
        /// <summary>
        /// 
        /// </summary>
        public Variable Variable { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        public DefaultVariableValueConverter(Variable variable)
        {
            Variable = variable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsCanConvert(object value)
        {
            return value != null && Variable.ValueType != value.GetType();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public object Convert(object value)
        {
            if (value == null)
                return null;

            var type = value.GetType();
            if (type != typeof(string))
                throw new Exception($"Cannot convert {Variable.ValueType} to {type}");

            return StringConverter.ConvertToObject(Variable.ValueType, value.ToString());
        }
    }
}
