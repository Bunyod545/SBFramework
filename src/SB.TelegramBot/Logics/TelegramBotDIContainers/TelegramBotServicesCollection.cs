using System;

namespace SB.TelegramBot.Logics.TelegramBotDIContainers
{
    /// <summary>
    /// 
    /// </summary>
    public class TelegramBotServicesCollection : ITelegramBotServicesCollection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TImplement"></typeparam>
        public void AddScoped<TInterface, TImplement>() where TImplement : TInterface
        {
            TelegramBotServicesContainer.AddScoped<TInterface, TImplement>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TImplement"></typeparam>
        public void AddSingleton<TInterface, TImplement>() where TImplement : TInterface
        {
            TelegramBotServicesContainer.AddSingleton<TInterface, TImplement>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TImplement"></typeparam>
        public void AddTransient<TInterface, TImplement>() where TImplement : TInterface
        {
            TelegramBotServicesContainer.AddTransient<TInterface, TImplement>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        public TInterface GetService<TInterface>()
        {
            return TelegramBotServicesContainer.GetService<TInterface>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object GetService(Type type)
        {
            return TelegramBotServicesContainer.GetService(type);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            TelegramBotServicesContainer.Initialize();
        }
    }
}
