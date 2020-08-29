namespace SB.TelegramBot.Databases.Tables
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotDbUser
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

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
        public string CurrentCommand { get; set; }
    }
}
