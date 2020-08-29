using SB.TelegramBot.Logics.TelegramBotClients;
using SB.TelegramBot.Logics.TelegramBotDIContainers;
using SB.TelegramBot.Services;
using Telegram.Bot;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TelegramBotBaseCommand : ITelegramBotCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public TelegramBotClient Client => TelegramBotClientManager.Client;

        /// <summary>
        /// 
        /// </summary>
        public ITelegramBotUserService UserService = TelegramBotServicesContainer.GetService<ITelegramBotUserService>();

        /// <summary>
        /// 
        /// </summary>
        public abstract void Execute();
    }
}
