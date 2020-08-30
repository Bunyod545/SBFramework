using SB.TelegramBot.Helpers;
using SB.TelegramBot.Logics.TelegramBotCallbackQueries;
using SB.TelegramBot.Logics.TelegramBotCommands.Factories;
using SB.TelegramBot.Logics.TelegramBotDIContainers;
using SB.TelegramBot.Logics.TelegramBotMessages;
using Telegram.Bot.Args;

namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotCallbackQueryHandler : ITelegramBotCallbackQueryHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Handle(object sender, CallbackQueryEventArgs e)
        {
            TelegramBotMessageManager.Message.Value = e.CallbackQuery.Message;

            var userService = TelegramBotServicesContainer.GetService<ITelegramBotUserService>();
            var currentUser = userService.GetCurrentUserInfo();

            if (currentUser == null)
                currentUser = userService.RegisterUser();

            TelegramBotLanguageHelper.InitializeCulture(currentUser.Language);
            var commandId = GetCommandId(e.CallbackQuery.Data);
            if (commandId == null)
                return;

            var command = TelegramBotCommandFactory.GetCallbackCommand(commandId.Value);
            if (command == null)
                return;

            e.CallbackQuery.Data = RemoveCommandId(e.CallbackQuery.Data);
            TelegramBotCallbackQueryManager.CallbackQuery.Value = e.CallbackQuery;
            command.Execute();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private long? GetCommandId(string data)
        {
            if (string.IsNullOrEmpty(data))
                return null;

            var datas = data.Split(';');
            if (datas.Length == 0)
                return null;

            var firstData = datas[0];
            return long.TryParse(firstData, out var id) ? id : (long?)null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string RemoveCommandId(string data)
        {
            var index = data.IndexOf(';');
            return data.Substring(index + 1);
        }
    }
}
