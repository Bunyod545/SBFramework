using SB.TelegramBot.Logics.TelegramBotDIContainers;
using System;

namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotCommandActivator : ITelegramBotCommandActivator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandClrType"></param>
        /// <returns></returns>
        public ITelegramBotCommand ActivateCommand(Type commandClrType)
        {
            return TelegramBotServicesContainer.CreateWithServices(commandClrType) as ITelegramBotCommand;
        }
    }
}
