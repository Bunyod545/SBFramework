using System;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITelegramBotCallbackDataConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sbStringBuilder"></param>
        /// <param name="value"></param>
        void Serialize(TelegramBotCallbackDataStringBuilder sbStringBuilder, object value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        object Deserialize(Type type, string value);
    }
}
