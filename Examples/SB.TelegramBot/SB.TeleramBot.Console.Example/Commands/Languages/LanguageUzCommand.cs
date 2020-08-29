using SB.TelegramBot;
using SB.TeleramBot.Example.Resources.Messages;

namespace SB.TeleramBot.Example.Commands
{
    /// <summary>
    /// 
    /// </summary>
    [TelegramBotCommandName("O`zbek tilini tanlash")]
    public class LanguageUzCommand : TelegramBotPublicCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Execute()
        {
            UserService.SetCurrentUserLanguage("uz-Latn-UZ");
            MessageService.SendText(TelegramBotMessages.UserSuccessfulyRegistered);
        }
    }
}
