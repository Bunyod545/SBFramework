using System;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotCallbackDataTextConverter : ITelegramBotCallbackDataConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sbStringBuilder"></param>
        /// <param name="value"></param>
        public void Serialize(TelegramBotCallbackDataStringBuilder sbStringBuilder, object value)
        {
            var textValue = value as string;
            if (string.IsNullOrEmpty(textValue))
            {
                sbStringBuilder.AppendEmptyValue();
                return;
            }

            if (textValue.Contains(";"))
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
