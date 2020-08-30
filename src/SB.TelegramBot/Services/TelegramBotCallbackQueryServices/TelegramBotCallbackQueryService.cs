using SB.TelegramBot.Logics.TelegramBotCallbackQueries;
using SB.TelegramBot.Logics.TelegramBotClients;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

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
        /// <param name="replyMarkup"></param>
        public void SendText(string text, IReplyMarkup replyMarkup = null)
        {
            var client = TelegramBotClientManager.Client;
            client.SendTextMessageAsync(CallbackQuery.Message.Chat.Id, text, replyMarkup: replyMarkup);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetData<T>() where T : class, new()
        {
            var data = CallbackQuery.Data;
            return TelegramBotCallbackDataConverter.Deserialize<T>(data);
        }
    }
}
