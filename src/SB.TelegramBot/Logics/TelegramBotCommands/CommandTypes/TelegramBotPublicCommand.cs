using SB.TelegramBot.Logics.TelegramBotDIContainers;
using SB.TelegramBot.Services;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    [TelegramBotCommand(TelegramBotCommandType.PublicCommand)]
    public abstract class TelegramBotPublicCommand : TelegramBotBaseCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public ITelegramBotMessageService MessageService { get; }

        /// <summary>
        /// 
        /// </summary>
        public TelegramBotPublicCommand()
        {
            MessageService = TelegramBotServicesContainer.GetService<ITelegramBotMessageService>();
        }
    }
}
