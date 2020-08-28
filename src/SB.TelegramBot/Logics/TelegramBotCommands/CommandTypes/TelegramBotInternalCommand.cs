using SB.TelegramBot.Logics.TelegramBotDIContainers;
using SB.TelegramBot.Services;

namespace SB.TelegramBot.Logics.TelegramBotCommands.CommandTypes
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TelegramBotInternalCommand : TelegramBotBaseCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public ITelegramBotMessageService MessageService = TelegramBotServicesContainer.GetService<ITelegramBotMessageService>();
    }
}
