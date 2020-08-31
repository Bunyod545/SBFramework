using System;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TelegramBotCommandNameAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type CommandNameType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandNameType"></param>
        public TelegramBotCommandNameAttribute(Type commandNameType)
        {
            CommandNameType = commandNameType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public TelegramBotCommandNameAttribute(string name)
        {
            Language = string.Empty;
            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language"></param>
        /// <param name="name"></param>
        public TelegramBotCommandNameAttribute(string language, string name)
        {
            Language = language;
            Name = name;
        }
    }
}
