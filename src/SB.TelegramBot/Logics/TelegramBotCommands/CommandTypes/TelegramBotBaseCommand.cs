using SB.TelegramBot.Logics.TelegramBotClients;
using Telegram.Bot;

namespace SB.TelegramBot.Logics.TelegramBotCommands
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
        public abstract void Execute();
    }
}
