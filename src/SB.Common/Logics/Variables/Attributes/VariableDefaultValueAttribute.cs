using System;
using System.ComponentModel;

namespace SB.Common.Logics.Variables.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    public class VariableDefaultValueAttribute : DefaultValueAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public VariableDefaultValueAttribute(bool value) : base(value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public VariableDefaultValueAttribute(byte value) : base(value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public VariableDefaultValueAttribute(char value) : base(value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public VariableDefaultValueAttribute(double value) : base(value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public VariableDefaultValueAttribute(short value) : base(value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public VariableDefaultValueAttribute(int value) : base(value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public VariableDefaultValueAttribute(long value) : base(value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public VariableDefaultValueAttribute(object value) : base(value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public VariableDefaultValueAttribute(float value) : base(value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public VariableDefaultValueAttribute(string value) : base(value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public VariableDefaultValueAttribute(Type type, string value) : base(type, value)
        {
        }
    }
}
