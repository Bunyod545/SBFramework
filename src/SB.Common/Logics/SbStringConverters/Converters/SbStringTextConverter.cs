using SB.Common.Helpers;
using SB.Common.Logics.SbStringConverters.Builders;
using System;

namespace SB.Common.Logics.SbStringConverters.Converters
{
    /// <summary>
    /// 
    /// </summary>
    public class SbStringTextConverter : ISbStringConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sbStringBuilder"></param>
        /// <param name="value"></param>
        public void Serialize(SbStringBuilder sbStringBuilder, object value)
        {
            var textValue = value as string;
            if (string.IsNullOrEmpty(textValue))
            {
                sbStringBuilder.AppendEmptyValue();
                return;
            }

            if (textValue.Contains(Strings.Semicolon))
                throw new FormatException("Cannot convert value, don`t use semicolon (;) on value!");

            sbStringBuilder.AppendValue(textValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public object Deserialize(Type type, string value)
        {
            return value;
        }
    }
}
