using System;
using Telegram.Bot;

namespace SB.TelegramBot.Logics.TelegramBotClients
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TelegramBotClientManager
    {
        /// <summary>
        /// 
        /// </summary>
        public static string Token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static TelegramBotClient Client { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public static void Initialize()
        {
            Client = new TelegramBotClient(Token);

            var name = Client.GetMeAsync().Result.Username;
            Console.WriteLine($"Telegram bot name: {name}");

            Client.OnMessage += Client_OnMessage;
            Client.OnCallbackQuery += Client_OnCallbackQuery;

            Client.StartReceiving();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Dispose()
        {
            Client.StopReceiving();
            Client = null;
        }
    }
}
