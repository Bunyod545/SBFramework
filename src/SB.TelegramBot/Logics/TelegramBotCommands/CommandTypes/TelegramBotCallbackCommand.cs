using SB.TelegramBot.Logics.TelegramBotDIContainers;
using SB.TelegramBot.Services;

namespace SB.TelegramBot.Logics.TelegramBotCommands
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TelegramBotCallbackCommand : TelegramBotBaseCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public ITelegramBotCallbackQueryService MessageService = TelegramBotServicesContainer.GetService<ITelegramBotCallbackQueryService>();
    }
}
