using SB.TelegramBot.Logics.TelegramBotCommands.Enums;
using System;

namespace SB.TelegramBot.Logics.TelegramBotCommands.Factories.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotCommandInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public TelegramBotCommandType CommandType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type ClrType { get; set; }
    }
}
