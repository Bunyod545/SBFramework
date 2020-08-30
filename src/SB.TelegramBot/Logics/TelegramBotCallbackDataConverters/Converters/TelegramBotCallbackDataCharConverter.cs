using System;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotCallbackDataCharConverter : ITelegramBotCallbackDataConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sbStringBuilder"></param>
        /// <param name="value"></param>
        public void Serialize(TelegramBotCallbackDataStringBuilder sbStringBuilder, object value)
        {
            var charValue = value as char?;
            if (charValue == null)
            {
                sbStringBuilder.AppendEmptyValue();
                return;
            }

            if (charValue.ToString() == ";")
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
