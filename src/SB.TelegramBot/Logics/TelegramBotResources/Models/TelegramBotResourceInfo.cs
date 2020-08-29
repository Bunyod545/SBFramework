using System.Reflection;
using System.Resources;

namespace SB.TelegramBot.Logics.TelegramBotResources.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotResourceInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Assembly Assembly { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ResourceManager Manager { get; set; }
    }
}
