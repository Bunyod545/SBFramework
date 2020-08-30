using SB.TelegramBot;
using SB.TeleramBot.Example.Resources.Messages;

namespace SB.TeleramBot.Example.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class LanguageRuCommand : TelegramBotCallbackCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Execute()
        {
            UserService.SetCurrentUserLanguage("ru-RU");
            CallbackQueryService.SendText(TelegramBotMessages.UserSuccessfulyRegistered);
        }
    }
}
