namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITelegramBotCommandService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        long GetCommandId();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        TelegramBotCommandType GetCommandType();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ITelegramBotCommandName GetCommandName();
    }
}
