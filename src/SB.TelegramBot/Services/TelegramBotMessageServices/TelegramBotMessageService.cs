using SB.TelegramBot.Logics.TelegramBotClients;
using SB.TelegramBot.Logics.TelegramBotMessages;
using Telegram.Bot.Types;

namespace SB.TelegramBot.Services.TelegramBotMessageServices
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
        public void SendText(string text)
        {
            var client = TelegramBotClientManager.Client;
            client.SendTextMessageAsync(Message.Chat.Id, text);
        }
    }
}
