using SB.TelegramBot;
using SB.TeleramBot.Example.Resources.Messages;

namespace SB.TeleramBot.Example.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class LanguageUzCommand : TelegramBotCallbackCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Execute()
        {
            UserService.SetCurrentUserLanguage("uz-Latn-UZ");
            CallbackQueryService.SendText(TelegramBotMessages.UserSuccessfulyRegistered);
        }
    }
}
