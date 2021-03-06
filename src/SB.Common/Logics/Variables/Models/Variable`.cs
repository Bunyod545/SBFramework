﻿namespace SB.Common.Logics.Variables
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Variable<T> : Variable
    {
        /// <summary>
        /// 
        /// </summary>
        public T Value { get => (T)GetVariableValue(); set => SetValue(value); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(T value)
        {
            SetVariableValue(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T GetValue()
        {
            return (T)GetVariableValue();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        public static implicit operator T(Variable<T> variable)
        {
            return variable.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Variable Clone(object context)
        {
            var clone = new Variable<T>();
            clone.Name = Name;
            clone.PropertyInfo = PropertyInfo;
            clone.ValueType = ValueType;
            clone.ContextType = ContextType;
            clone.ContextObject = context;
            clone.DefaultValue = DefaultValue;
            clone.TableType = TableType;
            clone.VariableService = VariableService;

            return clone;
        }
    }
}
