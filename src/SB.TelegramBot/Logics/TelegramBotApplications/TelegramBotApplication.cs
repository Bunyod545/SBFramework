using SB.TelegramBot.Logics.TelegramBotClients;
using SB.TelegramBot.Logics.TelegramBotCommands.Factories;
using SB.TelegramBot.Logics.TelegramBotDIContainers;
using SB.TelegramBot.Services;
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
            AppConfig = new TelegramBotAppConfig(token);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Run()
        {
            TelegramBotClientManager.Token = AppConfig.Token;
            RegisterServices(new TelegramBotServicesCollection());

            TelegramBotServicesContainer.Initialize();
            TelegramBotCommandFactory.Initialize();
            AppConfig.Configure(this);

            TelegramBotClientManager.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        protected virtual void RegisterServices(ITelegramBotServicesCollection services)
        {
            services.AddTransient<ITelegramBotCommandName, TelegramBotCommandName>();
            services.AddScoped<ITelegramBotCommandFactoryInitializer, TelegramBotCommandFactoryInitializer>();
            services.AddScoped<ITelegramBotUserService, TelegramBotUserService>();
            services.AddScoped<ITelegramBotMessageService, TelegramBotMessageService>();
            services.AddScoped<ITelegramBotCallbackQueryService, TelegramBotCallbackQueryService>();
            services.AddScoped<ITelegramBotCommandActivator, TelegramBotCommandActivator>();
            services.AddScoped<ITelegramBotUnknownMessageService, TelegramBotUnknownMessageService>();

            services.AddScoped<ITelegramBotMessageHandler, TelegramBotMessageHandler>();
            services.AddScoped<ITelegramBotCallbackQueryHandler, TelegramBotCallbackQueryHandler>();
            services.AddScoped<ITelegramBotMessageEditedHandler, TelegramBotMessageEditedHandler>();
            services.AddScoped<ITelegramBotInlineQueryHandler, TelegramBotInlineQueryHandler>();

            AppConfig.RegisterServices(services);
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
