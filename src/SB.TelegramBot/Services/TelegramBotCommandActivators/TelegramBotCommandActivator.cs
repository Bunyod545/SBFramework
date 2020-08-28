using SB.TelegramBot.Logics.TelegramBotCommands;
using SB.TelegramBot.Logics.TelegramBotDIContainers;
using System;
using System.Linq;

namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotCommandActivator : ITelegramBotCommandActivator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandClrType"></param>
        /// <returns></returns>
        public ITelegramBotCommand ActivateCommand(Type commandClrType)
        {
            var ctors = commandClrType.GetConstructors();
            if (ctors.Length == 0)
                throw new Exception($"Cannot find any public constructor for {commandClrType}");

            if (ctors.Length > 1)
                throw new Exception($"More public constructors for {commandClrType}");

            var ctor = ctors.FirstOrDefault();
            var ctorParamsInfos = ctor.GetParameters();

            var ctorParams = new object[ctorParamsInfos.Length];
            for (int index = 0; index < ctorParamsInfos.Length; index++)
            {
                var ctorParamInfo = ctorParamsInfos[index];
                ctorParams[index] = TelegramBotServicesContainer.GetService(ctorParamInfo.ParameterType);
            }

            return Activator.CreateInstance(commandClrType, ctorParams) as ITelegramBotCommand;
        }
    }
}
