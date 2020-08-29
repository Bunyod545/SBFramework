using SB.TelegramBot.Logics.TelegramBotCommands.Factories;
using SB.TelegramBot.Logics.TelegramBotCommands.Factories.Models;

namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotCommandService : ITelegramBotCommandService
    {
        /// <summary>
        /// 
        /// </summary>
        public ITelegramBotCommand Command { get; }

        /// <summary>
        /// 
        /// </summary>
        public TelegramBotCommandInfo Info { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        public TelegramBotCommandService(ITelegramBotCommand command)
        {
            Command = command;
            Info = TelegramBotCommandFactory.GetCommand(command.GetType());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long GetCommandId()
        {
            return Info.CommandId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TelegramBotCommandType GetCommandType()
        {
            return Info.CommandType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ITelegramBotCommandName GetCommandName()
        {
            return Info.CommandName;
        }
    }
}
