using SB.TelegramBot.Logics.TelegramBotCommands.Factories;
using Telegram.Bot.Types.ReplyMarkups;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public static class InlineKeyboardButtonExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="button"></param>
        public static void SetCommand<TCommand>(this InlineKeyboardButton button) where TCommand : ITelegramBotCommand
        {
            var commandInfo = TelegramBotCommandFactory.GetCommand(typeof(TCommand));
            if (commandInfo == null)
                return;

            button.CallbackData = $"{commandInfo.CommandId};" + button.CallbackData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="button"></param>
        public static void SetData(this InlineKeyboardButton button, object data)
        {
            var dataString = TelegramBotCallbackDataConverter.Serialize(data);
            button.CallbackData += dataString;
        }
    }
}
