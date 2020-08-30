using SB.TelegramBot;
using SB.TeleramBot.Example.Commands.Languages.LanguageEnCommands.Models;
using SB.TeleramBot.Example.Resources.Messages;

namespace SB.TeleramBot.Example.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class LanguageEnCommand : TelegramBotCallbackCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Execute()
        {
            var data = CallbackQueryService.GetData<LanguageEnInfo>();

            UserService.SetCurrentUserLanguage("en");
            CallbackQueryService.SendText(TelegramBotMessages.UserSuccessfulyRegistered);
        }
    }
}
