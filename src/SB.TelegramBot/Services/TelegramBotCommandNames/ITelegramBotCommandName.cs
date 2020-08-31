using SB.TelegramBot.Logics.TelegramBotCommands.Factories.Models;

namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITelegramBotCommandName
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        void Initialize(TelegramBotCommandInfo info);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool IsEqualName(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetName();
    }
}
