using System.Threading;
using Telegram.Bot.Types;

namespace SB.TelegramBot.Logics.TelegramBotCallbackQueries
{
    /// <summary>
    /// 
    /// </summary>
    public static class TelegramBotCallbackQueryManager
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly static AsyncLocal<CallbackQuery> CallbackQuery = new AsyncLocal<CallbackQuery>();
    }
}
