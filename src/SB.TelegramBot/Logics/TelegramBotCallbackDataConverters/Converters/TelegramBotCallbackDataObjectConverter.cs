using System;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotCallbackDataObjectConverter : ITelegramBotCallbackDataConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sbStringBuilder"></param>
        /// <param name="value"></param>
        public void Serialize(TelegramBotCallbackDataStringBuilder sbStringBuilder, object value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public object Deserialize(Type type, string value)
        {
            throw new NotImplementedException();
        }
    }
}
