using SB.TelegramBot;
using SB.TeleramBot.Example.Resources.Messages;

namespace SB.TeleramBot.Example.Commands
{
    /// <summary>
    /// 
    /// </summary>
    [TelegramBotCommandName("Выбрать русский язык")]
    public class LanguageRuCommand : TelegramBotPublicCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Execute()
        {
            UserService.SetCurrentUserLanguage("ru-RU");
            MessageService.SendText(TelegramBotMessages.UserSuccessfulyRegistered);
        }
    }
}
