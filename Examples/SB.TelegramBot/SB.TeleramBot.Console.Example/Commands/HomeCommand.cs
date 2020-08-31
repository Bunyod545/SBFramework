using SB.TelegramBot;
using Telegram.Bot.Types.ReplyMarkups;

namespace SB.TeleramBot.Example.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeCommand : TelegramBotPublicCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Execute()
        {
            var rkm = new ReplyKeyboardMarkup();
            rkm.ResizeKeyboard = true;
            rkm.Keyboard = new KeyboardButton[][]
            {
                new KeyboardButton[] { new KeyboardButton("O`zbek tilini tanlash") },
                new KeyboardButton[] { new KeyboardButton("Choose English language") },
                new KeyboardButton[] { new KeyboardButton("Выбрать русский язык") }
            };

            Client.SendTextMessageAsync(MessageService.Message.Chat.Id, "Text", replyMarkup: rkm);
        }
    }
}
