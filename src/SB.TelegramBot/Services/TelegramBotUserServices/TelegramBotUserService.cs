namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotUserService : ITelegramBotUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TelegramBotUserInfo RegisterUser()
        {
            return new TelegramBotUserInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TelegramBotUserInfo GetCurrentUserInfo()
        {
            return new TelegramBotUserInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        public TelegramBotUserInfo GetUserInfo(long chatId)
        {
            return new TelegramBotUserInfo();
        }
    }
}
