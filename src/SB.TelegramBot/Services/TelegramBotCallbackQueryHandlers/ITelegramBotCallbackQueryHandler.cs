using Telegram.Bot.Args;

namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITelegramBotCallbackQueryHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Handle(object sender, CallbackQueryEventArgs e);
    }
}
