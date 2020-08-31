using SB.TelegramBot.Services;
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
        public string CommandClrName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long CommandId { get; set; }

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
