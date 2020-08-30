using System;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotCallbackDataBooleanConverter : ITelegramBotCallbackDataConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sbStringBuilder"></param>
        /// <param name="value"></param>
        public void Serialize(TelegramBotCallbackDataStringBuilder sbStringBuilder, object value)
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
