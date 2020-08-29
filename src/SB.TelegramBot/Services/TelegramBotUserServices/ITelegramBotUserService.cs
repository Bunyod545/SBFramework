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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language"></param>
        void SetCurrentUserLanguage(string language);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        void SetCurrentUserCurrentCommand<TCommand>() where TCommand : ITelegramBotCommand;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        void ClearCurrentUserCurrentCommand();
    }
}
