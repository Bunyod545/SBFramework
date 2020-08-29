using SB.TelegramBot.Logics.TelegramBotDIContainers;
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
        public ITelegramBotCallbackQueryService MessageService { get; }

        /// <summary>
        /// 
        /// </summary>
        public TelegramBotCallbackCommand()
        {
            MessageService = TelegramBotServicesContainer.GetService<ITelegramBotCallbackQueryService>();
        }
    }
}
