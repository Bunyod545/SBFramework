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
        TelegramBotUserInfo RegisterUser();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        TelegramBotUserInfo GetUserInfo(long chatId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        TelegramBotUserInfo GetCurrentUserInfo();
    }
}
