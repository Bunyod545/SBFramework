using SB.TelegramBot.Logics.TelegramBotCommands.Factories;
using SB.TelegramBot.Logics.TelegramBotMessages;
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

            var command = TelegramBotCommandFactory.GetPublicCommand(e.Message.Text);
            if (command != null)
            {
                command.Execute();
                return;
            }
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
