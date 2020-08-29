using SB.TelegramBot;
using SB.TeleramBot.Example.Resources.Messages;

namespace SB.TeleramBot.Example.Commands
{
    /// <summary>
    /// 
    /// </summary>
    [TelegramBotCommandName("Choose English language")]
    public class LanguageEnCommand : TelegramBotPublicCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Execute()
        {
            UserService.SetCurrentUserLanguage("en");
            MessageService.SendText(TelegramBotMessages.UserSuccessfulyRegistered);
        }
    }
}
