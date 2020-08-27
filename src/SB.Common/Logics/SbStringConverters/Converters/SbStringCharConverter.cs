using SB.Common.Helpers;
using SB.Common.Logics.SbStringConverters.Builders;
using System;

namespace SB.Common.Logics.SbStringConverters.Converters
{
    /// <summary>
    /// 
    /// </summary>
    public class SbStringCharConverter : ISbStringConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sbStringBuilder"></param>
        /// <param name="value"></param>
        public void Serialize(SbStringBuilder sbStringBuilder, object value)
        {
            var charValue = value as char?;
            if (charValue == null)
            {
                sbStringBuilder.AppendEmptyValue();
                return;
            }

            if (charValue.ToString() == Strings.Semicolon)
                throw new FormatException("Cannot convert value, don`t use semicolon (;) on value!");

            sbStringBuilder.AppendValue(charValue.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public object Deserialize(Type type, string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return char.Parse(value);
        }
    }
}
