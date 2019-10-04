using System;

namespace SB.Common.Logics.Variables.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class VariableServiceAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public Type VariableServiceType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableServiceType"></param>
        public VariableServiceAttribute(Type variableServiceType)
        {
            VariableServiceType = variableServiceType;
        }
    }
}
