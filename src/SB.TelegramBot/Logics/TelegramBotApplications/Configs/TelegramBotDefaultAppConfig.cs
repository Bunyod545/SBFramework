using SB.TelegramBot.Logics.TelegramBotDIContainers;
using SB.TelegramBot.Services;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotDefaultAppConfig : TelegramBotAppConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        public TelegramBotDefaultAppConfig(string token)
        {
            Token = token;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public override void RegisterServices(ITelegramBotServicesCollection services)
        {
            services.AddScoped<ITelegramBotCommandFactoryInitializer, TelegramBotCommandFactoryInitializer>();
            services.AddScoped<ITelegramBotUserService, TelegramBotUserService>();
            services.AddScoped<ITelegramBotMessageService, TelegramBotMessageService>();
            services.AddScoped<ITelegramBotCallbackQueryService, TelegramBotCallbackQueryService>();
            services.AddScoped<ITelegramBotCommandActivator, TelegramBotCommandActivator>();
            services.AddScoped<ITelegramBotUnknownMessageService, TelegramBotUnknownMessageService>();
            services.AddScoped<ITelegramBotMessageHandler, TelegramBotMessageHandler>();
            services.AddScoped<ITelegramBotCallbackQueryHandler, TelegramBotCallbackQueryHandler>();
        }
    }
}