using SB.TelegramBot.Logics.TelegramBotCommands.CommandTypes;
using SB.TelegramBot.Logics.TelegramBotCommands.Enums;
using SB.TelegramBot.Logics.TelegramBotCommands.Factories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SB.TelegramBot.Logics.TelegramBotCommands.Factories
{
    /// <summary>
    /// 
    /// </summary>
    public static class TelegramBotCommandFactory
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly List<TelegramBotCommandInfo> Infos;

        /// <summary>
        /// 
        /// </summary>
        static TelegramBotCommandFactory()
        {
            Infos = new List<TelegramBotCommandInfo>();
            InitializeInfos();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void InitializeInfos()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();

            var interfaceType = typeof(ITelegramBotCommand);
            var commandTypes = types.Where(w => w.IsAssignableFrom(interfaceType)).ToList();
            commandTypes.ForEach(InitializeInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandClrType"></param>
        private static void InitializeInfo(Type commandClrType)
        {
            if (commandClrType.IsAbstract || commandClrType.IsInterface)
                return;

            var info = new TelegramBotCommandInfo();
            info.ClrType = commandClrType;
            info.CommandType = GetCommandType(commandClrType);

            Infos.Add(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandClrType"></param>
        /// <returns></returns>
        private static TelegramBotCommandType GetCommandType(Type commandClrType)
        {
            if (commandClrType.IsAssignableFrom(typeof(TelegramBotPublicCommand)))
                return TelegramBotCommandType.PublicCommand;

            if (commandClrType.IsAssignableFrom(typeof(TelegramBotInternalCommand)))
                return TelegramBotCommandType.InternalCommand;

            if (commandClrType.IsAssignableFrom(typeof(TelegramBotCallbackCommand)))
                return TelegramBotCommandType.CallbackCommand;

            return TelegramBotCommandType.Unknown;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ITelegramBotCommand GetCommand(string name)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ITelegramBotCommand GetPublicCommand(string name)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ITelegramBotCommand GetCallbackCommand(string name)
        {
            return null;
        }
    }
}
