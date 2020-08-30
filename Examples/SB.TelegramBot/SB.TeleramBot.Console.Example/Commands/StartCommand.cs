using SB.TelegramBot;
using SB.TeleramBot.Example.Commands.Languages.LanguageEnCommands.Models;
using SB.TeleramBot.Example.Resources.Messages;
using Telegram.Bot.Types.ReplyMarkups;

namespace SB.TeleramBot.Example.Commands
{
    /// <summary>
    /// 
    /// </summary>
    [TelegramBotCommandName("/start")]
    public class StartCommand : TelegramBotPublicCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Execute()
        {
            var buttons = new InlineKeyboardButton[3];
            buttons[0] = new InlineKeyboardButton();
            buttons[0].SetCommand<LanguageUzCommand>();
            buttons[0].Text = "LanguageUzCommand";

            buttons[1] = new InlineKeyboardButton();
            buttons[1].SetCommand<LanguageRuCommand>();
            buttons[1].Text = "LanguageRuCommand";

            buttons[2] = new InlineKeyboardButton();
            buttons[2].SetCommand<LanguageEnCommand>();
            buttons[2].SetData(new LanguageEnInfo("Test"));
            buttons[2].Text = "LanguageEnCommand";

            var buttonsMarkUp = new InlineKeyboardMarkup(buttons);
            MessageService.SendText(TelegramBotMessages.UserSuccessfulyRegistered, buttonsMarkUp);
        }
    }
}
