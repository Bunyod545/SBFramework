using SB.TelegramBot.Logics.TelegramBotClients;
using SB.TelegramBot.Logics.TelegramBotDIContainers;
using System;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotApplication : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public const string Version = "1.0.0.0";

        /// <summary>
        /// 
        /// </summary>
        public TelegramBotAppConfig AppConfig { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appConfig"></param>
        public TelegramBotApplication(TelegramBotAppConfig appConfig)
        {
            AppConfig = appConfig;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        public TelegramBotApplication(string token)
        {
            AppConfig = new TelegramBotDefaultAppConfig(token);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Run()
        {
            TelegramBotClientManager.Token = AppConfig.Token;

            AppConfig.RegisterServices(new TelegramBotServicesCollection());
            TelegramBotServicesContainer.Initialize();
            TelegramBotClientManager.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Dispose()
        {
            TelegramBotServicesContainer.Dispose();
            TelegramBotServicesContainer.Dispose();
            TelegramBotClientManager.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static TelegramBotApplication Run(string token)
        {
            var telegramBotApp = new TelegramBotApplication(token);
            telegramBotApp.Run();

            return telegramBotApp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appConfig"></param>
        /// <returns></returns>
        public static TelegramBotApplication Run(TelegramBotAppConfig appConfig)
        {
            var telegramBotApp = new TelegramBotApplication(appConfig);
            telegramBotApp.Run();

            return telegramBotApp;
        }
    }
}
