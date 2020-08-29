using SB.TelegramBot.Logics.TelegramBotDIContainers;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotAppConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TelegramBotAppConfig()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        public TelegramBotAppConfig(string token)
        {
            Token = token;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public virtual void RegisterServices(ITelegramBotServicesCollection services)
        {

        }
    }
}
