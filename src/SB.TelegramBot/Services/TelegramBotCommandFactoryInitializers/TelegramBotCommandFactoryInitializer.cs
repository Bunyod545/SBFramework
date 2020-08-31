using SB.TelegramBot.Databases;
using SB.TelegramBot.Databases.Tables;
using SB.TelegramBot.Logics.TelegramBotCommands.Factories.Models;
using SB.TelegramBot.Logics.TelegramBotDIContainers;
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

        /// <summary>
        /// 
        /// </summary>
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
            InitializeIdentifier(info);
            InitializeName(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        private void InitializeIdentifier(TelegramBotCommandInfo info)
        {
            var dbCommand = _dbCommands.FirstOrDefault(f => f.ClrName == info.ClrType.Name);
            if (dbCommand == null)
            {
                dbCommand = new TelegramBotDbCommand();
                dbCommand.ClrName = info.ClrType.Name;
                TelegramBotDb.Commands.Insert(dbCommand);
            }

            info.CommandId = dbCommand.Id;
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeName(TelegramBotCommandInfo info)
        {
            if (InitializeNameWithType(info))
                return;

            InitializeNameWithService(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private bool InitializeNameWithType(TelegramBotCommandInfo info)
        {
            var attrs = info.ClrType.GetCustomAttributes(typeof(TelegramBotCommandNameAttribute), false);
            if (attrs.Length != 1)
                return false;

            var attr = (TelegramBotCommandNameAttribute)attrs.FirstOrDefault();
            if (attr.CommandNameType == null)
                return false;

            var commandName = TelegramBotServicesContainer.CreateWithServices(attr.CommandNameType) as ITelegramBotCommandName;
            if (commandName == null)
                return false;

            info.CommandName = commandName;
            commandName.Initialize(info);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private void InitializeNameWithService(TelegramBotCommandInfo info)
        {
            if (!TelegramBotServicesContainer.IsRegistered<ITelegramBotCommandName>())
                return;

            var commandName = TelegramBotServicesContainer.GetService<ITelegramBotCommandName>();
            info.CommandName = commandName;
            commandName.Initialize(info);
        }
    }
}
