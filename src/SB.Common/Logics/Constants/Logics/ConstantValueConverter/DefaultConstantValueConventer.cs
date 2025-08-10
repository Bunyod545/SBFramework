using System;

namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultConstantValueConverter : IConstantValueConverter
    {
        /// <summary>
        /// 
        /// </summary>
        public ConstantSet Constant { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constant"></param>
        public DefaultConstantValueConverter(ConstantSet constant)
        {
            Constant = constant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsCanConvert(object value)
        {
            return value != null && Constant.ValueType != value.GetType();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public object? Convert(object value)
        {
            if (value == null)
                return null;

            var type = value.GetType();
            if (type != typeof(string))
                throw new Exception($"Cannot convert {Constant.ValueType} to {type}");

            var underlyingType = Nullable.GetUnderlyingType(Constant.ValueType);
            return StringConverter.ConvertToObject(underlyingType ?? Constant.ValueType, value.ToString());
        }
    }
}