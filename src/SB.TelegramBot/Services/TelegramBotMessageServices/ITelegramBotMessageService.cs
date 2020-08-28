using Telegram.Bot.Types;

namespace SB.TelegramBot.Services.TelegramBotMessageServices
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
        void SendText(string text);
    }
}
