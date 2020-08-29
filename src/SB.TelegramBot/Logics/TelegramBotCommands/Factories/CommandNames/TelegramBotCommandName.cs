using SB.TelegramBot.Logics.TelegramBotCommands.Factories.Models;
using SB.TelegramBot.Logics.TelegramBotDIContainers;
using SB.TelegramBot.Services;
using System.Collections.Generic;
using System.Linq;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotCommandName : ITelegramBotCommandName
    {
        /// <summary>
        /// 
        /// </summary>
        public TelegramBotCommandInfo Info { get; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> Names { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public TelegramBotCommandName(TelegramBotCommandInfo info)
        {
            Info = info;
            Names = new Dictionary<string, string>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language"></param>
        /// <param name="name"></param>
        public void AddName(string language, string name)
        {
            Names.Add(language, name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            var userService = TelegramBotServicesContainer.GetService<ITelegramBotUserService>();
            var currentUser = userService.GetCurrentUserInfo();
            if (string.IsNullOrEmpty(currentUser?.Language))
                return GetDefaultName();

            if (Names.ContainsKey(currentUser.Language))
                return Names[currentUser.Language];

            return GetDefaultName();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetDefaultName()
        {
            if (Names.Count > 0)
                return Names.FirstOrDefault().Value;

            return Info.CommandClrName;
        }
    }
}
