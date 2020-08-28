using Telegram.Bot.Types;

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
        void SendText(string text);
    }
}
