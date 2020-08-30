using SB.TelegramBot.Logics.TelegramBotClients;
using SB.TelegramBot.Logics.TelegramBotMessages;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotMessageService : ITelegramBotMessageService
    {
        /// <summary>
        /// 
        /// </summary>
        public Message Message => TelegramBotMessageManager.Message.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="replyMarkup"></param>
        public void SendText(string text, IReplyMarkup replyMarkup = null)
        {
            var client = TelegramBotClientManager.Client;
            client.SendTextMessageAsync(Message.Chat.Id, text, replyMarkup: replyMarkup);
        }
    }
}
