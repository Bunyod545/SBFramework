using System;

namespace SB.Common.Logics.Variables.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class VariableTableAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public Type TableType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableType"></param>
        public VariableTableAttribute(Type tableType)
        {
            TableType = tableType;
        }
    }
}
