using System;

namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ConstantDefaultValueAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ConstantDefaultValueAttribute(bool value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ConstantDefaultValueAttribute(byte value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ConstantDefaultValueAttribute(char value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ConstantDefaultValueAttribute(double value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ConstantDefaultValueAttribute(short value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ConstantDefaultValueAttribute(int value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ConstantDefaultValueAttribute(long value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ConstantDefaultValueAttribute(object? value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ConstantDefaultValueAttribute(float value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ConstantDefaultValueAttribute(string? value)
        {
            Value = value;
        }
    }
}