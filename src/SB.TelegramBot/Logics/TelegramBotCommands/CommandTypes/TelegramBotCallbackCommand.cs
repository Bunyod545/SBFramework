﻿using SB.TelegramBot.Logics.TelegramBotDIContainers;
using SB.TelegramBot.Services;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    [TelegramBotCommand(TelegramBotCommandType.CallbackCommand)]
    public abstract class TelegramBotCallbackCommand : TelegramBotBaseCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public ITelegramBotCallbackQueryService MessageService = TelegramBotServicesContainer.GetService<ITelegramBotCallbackQueryService>();
    }
}
