using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITelegramBotMessageService
    {
        /// <summary>
        /// 
        /// </summary>
        Message Message { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="replyMarkup"></param>
        void SendText(string text, IReplyMarkup replyMarkup = null);
    }
}
