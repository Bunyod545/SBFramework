using LiteDB;
using SB.TelegramBot.Databases.Tables;

namespace SB.TelegramBot.Databases
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotDb
    {
        /// <summary>
        /// 
        /// </summary>
        public const string DatabaseFileName = "TelegramBot.db";

        /// <summary>
        /// 
        /// </summary>
        public static LiteDatabase Database { get; }

        /// <summary>
        /// 
        /// </summary>
        public static ILiteCollection<TelegramBotDbUser> Users { get; }

        /// <summary>
        /// 
        /// </summary>
        public static ILiteCollection<TelegramBotDbCommand> Commands { get; }

        /// <summary>
        /// 
        /// </summary>
        static TelegramBotDb()
        {
            Database = new LiteDatabase(DatabaseFileName);
            Users = Database.GetCollection<TelegramBotDbUser>(nameof(Users));
            Commands = Database.GetCollection<TelegramBotDbCommand>(nameof(Commands));
        }
    }
}
