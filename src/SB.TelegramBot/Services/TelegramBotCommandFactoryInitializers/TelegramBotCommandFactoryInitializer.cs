using SB.TelegramBot.Databases;
using SB.TelegramBot.Databases.Tables;
using SB.TelegramBot.Logics.TelegramBotCommands.Factories.Models;
using System.Collections.Generic;
using System.Linq;

namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotCommandFactoryInitializer : ITelegramBotCommandFactoryInitializer
    {
        /// <summary>
        /// 
        /// </summary>
        private List<TelegramBotDbCommand> _dbCommands;

        public TelegramBotCommandFactoryInitializer()
        {
            _dbCommands = TelegramBotDb.Commands.FindAll().ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="infos"></param>
        public void Initialize(List<TelegramBotCommandInfo> infos)
        {
            infos.ForEach(InitializeInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        private void InitializeInfo(TelegramBotCommandInfo info)
        {
            var commandName = new TelegramBotCommandName(info);
            var attrs = info.ClrType.GetCustomAttributes(typeof(TelegramBotCommandNameAttribute), false);
            attrs.ToList().ForEach(f => InitializeName(commandName, f));

            info.CommandName = commandName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandName"></param>
        /// <param name="attr"></param>
        private void InitializeName(TelegramBotCommandName commandName, object attrObj)
        {
            var attr = (TelegramBotCommandNameAttribute)attrObj;
            commandName.AddName(attr.Language, attr.Name);
        }
    }
}
