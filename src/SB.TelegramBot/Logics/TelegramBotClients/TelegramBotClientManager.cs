using SB.TelegramBot.Logics.TelegramBotDIContainers;
using SB.TelegramBot.Services;
using System;
using Telegram.Bot;
using Telegram.Bot.Args;

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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Client_OnMessage(object sender, MessageEventArgs e)
        {
            var handler = TelegramBotServicesContainer.GetService<ITelegramBotMessageHandler>();
            handler.Handle(sender, e);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Client_OnCallbackQuery(object sender, CallbackQueryEventArgs e)
        {
            var handler = TelegramBotServicesContainer.GetService<ITelegramBotCallbackQueryHandler>();
            handler.Handle(sender, e);
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
