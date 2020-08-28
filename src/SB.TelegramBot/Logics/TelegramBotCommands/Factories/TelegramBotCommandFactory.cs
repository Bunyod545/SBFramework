﻿using SB.TelegramBot.Logics.TelegramBotCommands.Attributes;
using SB.TelegramBot.Logics.TelegramBotCommands.CommandTypes;
using SB.TelegramBot.Logics.TelegramBotCommands.Enums;
using SB.TelegramBot.Logics.TelegramBotCommands.Factories.Models;
using SB.TelegramBot.Logics.TelegramBotDIContainers;
using SB.TelegramBot.Services;
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
        private static List<TelegramBotCommandInfo> Infos;

        /// <summary>
        /// 
        /// </summary>
        static TelegramBotCommandFactory()
        {
            Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Initialize()
        {
            Infos = new List<TelegramBotCommandInfo>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(s => s.GetTypes());

            var interfaceType = typeof(ITelegramBotCommand);
            var commandTypes = types.Where(w => w.IsAssignableFrom(interfaceType)).ToList();
            commandTypes.ForEach(InitializeInfo);

            var initializer = TelegramBotServicesContainer.GetService<ITelegramBotCommandFactoryInitializer>();
            initializer.Initialize(new List<TelegramBotCommandInfo>(Infos));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandClrType"></param>
        private static void InitializeInfo(Type commandClrType)
        {
            if (commandClrType.IsAbstract || commandClrType.IsInterface)
                return;

            var attr = commandClrType.GetCustomAttribute<TelegramBotCommandAttribute>();
            if (attr == null)
                return;

            var info = new TelegramBotCommandInfo();
            info.ClrType = commandClrType;
            info.CommandType = attr.Type;
            info.CommandId = attr.Id;

            Infos.Add(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ITelegramBotCommand GetCommand(string name)
        {
            var info = Infos.FirstOrDefault(s => s.CommandName.GetName() == name);
            return InternalGetCommand(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandId"></param>
        /// <returns></returns>
        public static ITelegramBotCommand GetCommand(int commandId)
        {
            var info = Infos.FirstOrDefault(s => s.CommandId == commandId);
            return InternalGetCommand(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ITelegramBotCommand GetPublicOrInternalCommand(string name)
        {
            var info = Infos.FirstOrDefault(s => (s.CommandType == TelegramBotCommandType.PublicCommand ||
                                                  s.CommandType == TelegramBotCommandType.InternalCommand) &&
                                                  s.CommandName.GetName() == name);

            return InternalGetCommand(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandId"></param>
        /// <returns></returns>
        public static ITelegramBotCommand GetPublicOrInternalCommand(int commandId)
        {
            var info = Infos.FirstOrDefault(s => (s.CommandType == TelegramBotCommandType.PublicCommand ||
                                                  s.CommandType == TelegramBotCommandType.InternalCommand) &&
                                                  s.CommandId == commandId);

            return InternalGetCommand(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ITelegramBotCommand GetPublicCommand(string name)
        {
            var info = Infos.FirstOrDefault(s => s.CommandType == TelegramBotCommandType.PublicCommand &&
                                                s.CommandName.GetName() == name);

            return InternalGetCommand(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandId"></param>
        /// <returns></returns>
        public static ITelegramBotCommand GetPublicCommand(int commandId)
        {
            var info = Infos.FirstOrDefault(s => s.CommandType == TelegramBotCommandType.PublicCommand &&
                                                s.CommandId == commandId);

            return InternalGetCommand(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ITelegramBotCommand GetCallbackCommand(string name)
        {
            var info = Infos.FirstOrDefault(s => s.CommandType == TelegramBotCommandType.CallbackCommand &&
                                                   s.CommandName.GetName() == name);

            return InternalGetCommand(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandId"></param>
        /// <returns></returns>
        public static ITelegramBotCommand GetCallbackCommand(int commandId)
        {
            var info = Infos.FirstOrDefault(s => s.CommandType == TelegramBotCommandType.CallbackCommand &&
                                                   s.CommandId == commandId);

            return InternalGetCommand(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ITelegramBotCommand GetInternalCommand(string name)
        {
            var info = Infos.FirstOrDefault(s => s.CommandType == TelegramBotCommandType.InternalCommand &&
                                                s.CommandName.GetName() == name);

            return InternalGetCommand(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandId"></param>
        /// <returns></returns>
        public static ITelegramBotCommand GetInternalCommand(int commandId)
        {
            var info = Infos.FirstOrDefault(s => s.CommandType == TelegramBotCommandType.InternalCommand &&
                                                s.CommandId == commandId);

            return InternalGetCommand(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private static ITelegramBotCommand InternalGetCommand(TelegramBotCommandInfo info)
        {
            if (info == null)
                return null;

            var activator = TelegramBotServicesContainer.GetService<ITelegramBotCommandActivator>();
            return activator.ActivateCommand(info.ClrType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<TelegramBotCommandInfo> GetCommands()
        {
            return new List<TelegramBotCommandInfo>(Infos);
        }
    }
}
