using SB.TelegramBot.Logics.TelegramBotCommands.Enums;
using SB.TelegramBot.Logics.TelegramBotCommands.Factories.Interfaces;
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
        public int CommandId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TelegramBotCommandType CommandType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ITelegramBotCommandName CommandName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type ClrType { get; set; }
    }
}
