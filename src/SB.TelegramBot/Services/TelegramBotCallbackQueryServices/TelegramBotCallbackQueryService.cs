using SB.TelegramBot.Logics.TelegramBotCallbackQueries;
using SB.TelegramBot.Logics.TelegramBotClients;
using Telegram.Bot.Types;

namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotCallbackQueryService : ITelegramBotCallbackQueryService
    {
        /// <summary>
        /// 
        /// </summary>
        public CallbackQuery CallbackQuery => TelegramBotCallbackQueryManager.CallbackQuery.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void SendText(string text)
        {
            var client = TelegramBotClientManager.Client;
            client.SendTextMessageAsync(CallbackQuery.Message.Chat.Id, text);
        }
    }
}
