using System.Threading;
using Telegram.Bot.Types;

namespace SB.TelegramBot.Logics.TelegramBotMessages
{
    /// <summary>
    /// 
    /// </summary>
    public static class TelegramBotMessageManager
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly static AsyncLocal<Message> Message = new AsyncLocal<Message>();
    }
}