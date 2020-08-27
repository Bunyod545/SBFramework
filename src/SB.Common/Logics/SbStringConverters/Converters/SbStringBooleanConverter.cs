using SB.Common.Logics.SbStringConverters.Builders;
using System;

namespace SB.Common.Logics.SbStringConverters.Converters
{
    /// <summary>
    /// 
    /// </summary>
    public class SbStringBooleanConverter : ISbStringConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sbStringBuilder"></param>
        /// <param name="value"></param>
        public void Serialize(SbStringBuilder sbStringBuilder, object value)
        {
            if (value == null)
            {
                sbStringBuilder.AppendEmptyValue();
                return;
            }

            var booleanValue = (bool)value;
            sbStringBuilder.AppendValue(booleanValue ? "1" : "0");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public object Deserialize(Type type, string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return bool.Parse(value);
        }
    }
}
