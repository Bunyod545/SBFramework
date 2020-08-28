using SB.TelegramBot.Logics.TelegramBotCommands.Factories;
using SB.TelegramBot.Logics.TelegramBotDIContainers;
using SB.TelegramBot.Logics.TelegramBotMessages;
using SB.TelegramBot.Services;
using Telegram.Bot.Args;

namespace SB.TelegramBot.Logics.TelegramBotClients
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TelegramBotClientManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Client_OnMessage(object sender, MessageEventArgs e)
        {
            TelegramBotMessageManager.Message.Value = e.Message;

            var userService = TelegramBotServicesContainer.GetService<ITelegramBotUserService>();
            var currentUser = userService.GetUserInfo(e.Message.Chat.Id);
            if (currentUser == null)
            {
                userService.RegisterUser();
                return;
            }

            if (currentUser.CurrentCommandId.HasValue)
            {
                var currentCommand = TelegramBotCommandFactory.GetPublicOrInternalCommand(currentUser.CurrentCommandId.Value);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        private static void FirstInitializeUser(MessageEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        private static void ExecuteInternalCommand()
        {
        }
    }
}
