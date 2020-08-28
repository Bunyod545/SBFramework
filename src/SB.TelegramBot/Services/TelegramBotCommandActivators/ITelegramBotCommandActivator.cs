using SB.TelegramBot.Logics.TelegramBotCommands;
using System;

namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITelegramBotCommandActivator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandClrType"></param>
        /// <returns></returns>
        ITelegramBotCommand ActivateCommand(Type commandClrType);
    }
}
