namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITelegramBotUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chat"></param>
        void RegisterUser();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        TelegramBotUserInfo GetUserInfo(long chatId);
    }
}
