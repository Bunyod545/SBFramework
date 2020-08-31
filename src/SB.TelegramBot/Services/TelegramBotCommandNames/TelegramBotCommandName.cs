using SB.TelegramBot.Logics.TelegramBotCommands.Factories.Models;
using SB.TelegramBot.Logics.TelegramBotDIContainers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SB.TelegramBot.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotCommandName : ITelegramBotCommandName
    {
        /// <summary>
        /// 
        /// </summary>
        public TelegramBotCommandInfo Info { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> Names { get; }

        /// <summary>
        /// 
        /// </summary>
        public PropertyInfo ResourceProperty { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public TelegramBotCommandName()
        {
            Names = new Dictionary<string, string>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public void Initialize(TelegramBotCommandInfo info)
        {
            Info = info;
            if (InitializeWithAttributes())
                return;

            InitializeWithResource();
        }

        /// <summary>
        /// 
        /// </summary>
        private bool InitializeWithAttributes()
        {
            var attrs = Info.ClrType.GetCustomAttributes(typeof(TelegramBotCommandNameAttribute), true);
            var attrsList = attrs.Cast<TelegramBotCommandNameAttribute>().ToList();
            attrsList.ForEach(InitializeName);

            return Names.Count > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandName"></param>
        /// <param name="attr"></param>
        private void InitializeName(TelegramBotCommandNameAttribute attr)
        {
            if (!string.IsNullOrEmpty(attr.Name))
                Names.Add(attr.Language, attr.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeWithResource()
        {
            var assembly = Info.ClrType.Assembly;
            var synonymsResx = assembly.GetTypes().FirstOrDefault(f => f.Name == "TelegramBotCommandsSynonyms");
            if (synonymsResx == null)
                return;

            if (synonymsResx.GetCustomAttribute<CompilerGeneratedAttribute>() == null)
                return;

            var props = synonymsResx.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (props.Length == 0)
                return;

            ResourceProperty = props.FirstOrDefault(f => f.PropertyType == typeof(string) && f.Name == Info.CommandClrName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsEqualName(string name)
        {
            return GetName() == name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            if (Names.Count > 0)
                return GetNameWithAttribute();

            if (ResourceProperty != null)
                return (string)ResourceProperty.GetValue(null, null);

            return Info.CommandClrName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetNameWithAttribute()
        {
            var userService = TelegramBotServicesContainer.GetService<ITelegramBotUserService>();
            var currentUser = userService.GetCurrentUserInfo();
            if (string.IsNullOrEmpty(currentUser?.Language))
                return Names.FirstOrDefault().Value;

            if (Names.ContainsKey(currentUser.Language))
                return Names[currentUser.Language];

            return Names.FirstOrDefault().Value;
        }
    }
}
