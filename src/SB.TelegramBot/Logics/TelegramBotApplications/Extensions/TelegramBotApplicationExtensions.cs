using SB.TelegramBot.Logics.TelegramBotCommands.Factories;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public static class TelegramBotApplicationExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void IgnoreCommand<T>(this TelegramBotApplication app) where T : ITelegramBotCommand
        {
            TelegramBotCommandFactory.IgnoreCommand<T>();
        }
    }
}
