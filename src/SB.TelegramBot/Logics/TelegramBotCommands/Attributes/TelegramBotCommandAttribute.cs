using System;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TelegramBotCommandAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public TelegramBotCommandType Type { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public TelegramBotCommandAttribute(TelegramBotCommandType type)
        {
            Type = type;
        }
    }
}
