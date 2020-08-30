using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITelegramBotCallbackQueryService
    {
        /// <summary>
        /// 
        /// </summary>
        CallbackQuery CallbackQuery { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="replyMarkup"></param>
        void SendText(string text, IReplyMarkup replyMarkup = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetData<T>() where T : class, new();
    }
}
