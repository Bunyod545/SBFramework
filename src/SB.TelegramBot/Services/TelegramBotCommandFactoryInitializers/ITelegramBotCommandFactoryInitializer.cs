using SB.TelegramBot.Logics.TelegramBotCommands.Factories.Models;
using System.Collections.Generic;

namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITelegramBotCommandFactoryInitializer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="infos"></param>
        void Initialize(List<TelegramBotCommandInfo> infos);
    }
}
