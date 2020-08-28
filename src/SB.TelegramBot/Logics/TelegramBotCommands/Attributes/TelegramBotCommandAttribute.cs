using SB.TelegramBot.Logics.TelegramBotCommands.Enums;
using System;

namespace SB.TelegramBot.Logics.TelegramBotCommands.Attributes
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
        public int Id { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public TelegramBotCommandType Type { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public TelegramBotCommandAttribute(int id, TelegramBotCommandType type)
        {
            Id = id;
            Type = type;
        }
    }
}
