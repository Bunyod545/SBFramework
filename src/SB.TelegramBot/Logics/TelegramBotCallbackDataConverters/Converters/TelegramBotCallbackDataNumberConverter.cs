using System;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotCallbackDataNumberConverter : ITelegramBotCallbackDataConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sbStringBuilder"></param>
        /// <param name="value"></param>
        public void Serialize(TelegramBotCallbackDataStringBuilder sbStringBuilder, object value)
        {
            sbStringBuilder.AppendValue(value?.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public object Deserialize(Type type, string value)
        {
            return Convert.ChangeType(value, type);
        }
    }
}
