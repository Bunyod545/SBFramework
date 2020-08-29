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
        public TelegramBotClient Client { get; }

        /// <summary>
        /// 
        /// </summary>
        public ITelegramBotUserService UserService { get; }

        /// <summary>
        /// 
        /// </summary>
        public ITelegramBotCommandService CommandService { get; }

        /// <summary>
        /// 
        /// </summary>
        protected TelegramBotBaseCommand()
        {
            Client = TelegramBotClientManager.Client;
            UserService = TelegramBotServicesContainer.GetService<ITelegramBotUserService>();
            CommandService = new TelegramBotCommandService(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract void Execute();
    }
}
