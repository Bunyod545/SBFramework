namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotUserInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public long ChatId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CurrentCommandClrName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TelegramBotUserInfo()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatId"></param>
        public TelegramBotUserInfo(long chatId)
        {
            ChatId = chatId;
        }
    }
}
