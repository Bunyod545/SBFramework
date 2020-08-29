using SB.TelegramBot.Databases.Tables;
using SB.TelegramBot.Helpers;
using SB.TelegramBot.Logics.TelegramBotCommands.Factories;
using SB.TelegramBot.Logics.TelegramBotDIContainers;
using SB.TelegramBot.Logics.TelegramBotMessages;
using System.Globalization;
using Telegram.Bot.Args;

namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotMessageHandler : ITelegramBotMessageHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Handle(object sender, MessageEventArgs e)
        {
            TelegramBotMessageManager.Message.Value = e.Message;

            var userService = TelegramBotServicesContainer.GetService<ITelegramBotUserService>();
            var currentUser = userService.GetCurrentUserInfo();

            if (currentUser == null)
                currentUser = userService.RegisterUser();

            TelegramBotLanguageHelper.InitializeCulture(currentUser.Language);
            if (!string.IsNullOrEmpty(currentUser.CurrentCommandClrName))
            {
                var currentCommand = TelegramBotCommandFactory.GetPublicOrInternalCommand(currentUser.CurrentCommandClrName);
                currentCommand?.Execute();
                return;
            }

            var command = TelegramBotCommandFactory.GetPublicCommand(e.Message.Text);
            if (command != null)
            {
                command.Execute();
                return;
            }

            var unknownMessageService = TelegramBotServicesContainer.GetService<ITelegramBotUnknownMessageService>();
            unknownMessageService.Execute();
        }
    }
}
