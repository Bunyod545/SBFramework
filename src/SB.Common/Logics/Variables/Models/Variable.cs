using System;
using System.Reflection;
using SB.Common.Logics.Variables.Interfaces;
using SB.Common.Logics.Variables.Logics;
using SB.Common.Logics.Variables.Logics.ValueConverter;
using SB.Common.Logics.Variables.Logics.VariableValue;

namespace SB.Common.Logics.Variables
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="variable"></param>
    public delegate void VariableValueChangeHandler(Variable variable);

    /// <summary>
    /// 
    /// </summary>
    public abstract class Variable
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public PropertyInfo PropertyInfo { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public Type ValueType { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public Type ContextType { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public object ContextObject { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public object DefaultValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type TableType { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public IVariableService VariableService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IVariableValueGetter VariableValueGetter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IVariableValueSetter VariableValueSetter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IVariableValueConverter VariableValueConverter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public event VariableValueChangeHandler ValueChange;

        /// <summary>
        /// 
        /// </summary>
        protected Variable()
        {
            VariableValueGetter = new DefaultVariableValueGetter(this);
            VariableValueSetter = new DefaultVariableValueSetter(this);
            VariableValueConverter = new DefaultVariableValueConverter(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual object GetVariableValue()
        {
            if (VariableValueGetter == null)
                throw new NotImplementedException(nameof(VariableValueGetter));

            return VariableValueGetter.GetVariableValue();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public virtual void SetVariableValue(object value)
        {
            if (VariableValueSetter == null)
                throw new NotImplementedException(nameof(VariableValueSetter));

            VariableValueSetter.SetVariableValue(value);
            OnValueChange();
        }

        /// <summary>
        /// 
        /// </summary>
        protected void OnValueChange()
        {
            ValueChange?.Invoke(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract Variable Clone(object context);
    }
}
