﻿using SB.TelegramBot.Logics.TelegramBotDIContainers;
using SB.TelegramBot.Services;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    [TelegramBotCommand(TelegramBotCommandType.InternalCommand)]
    public abstract class TelegramBotInternalCommand : TelegramBotBaseCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public ITelegramBotMessageService MessageService = TelegramBotServicesContainer.GetService<ITelegramBotMessageService>();
    }
}
