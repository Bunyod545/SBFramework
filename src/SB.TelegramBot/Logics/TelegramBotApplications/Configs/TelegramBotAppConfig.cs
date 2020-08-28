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
        /// <param name="services"></param>
        public virtual void RegisterServices(ITelegramBotServicesCollection services)
        {

        }
    }
}
