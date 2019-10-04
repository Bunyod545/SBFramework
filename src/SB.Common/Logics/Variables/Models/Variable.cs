using System;
using SB.Common.Logics.Variables.Interfaces;
using SB.Common.Logics.Variables.Logics.VariableValue;

namespace SB.Common.Logics.Variables
{
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
        public Type ContextType { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public object ContextObject { get; internal set; }

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
        protected Variable()
        {
            VariableValueGetter = new DefaultVariableValueGetter(this);
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
            if (VariableService == null)
                throw new NotImplementedException(nameof(VariableService));

            VariableService.SetVariableValue(this, value);
        }
    }
}
