using System;
using System.Collections.Generic;

namespace SB.TelegramBot
{
    /// <summary>
    /// 
    /// </summary>
    public static class TelegramBotCallbackDataConverterFactory
    {
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<Type, ITelegramBotCallbackDataConverter> _converters;

        /// <summary>
        /// 
        /// </summary>
        static TelegramBotCallbackDataConverterFactory()
        {
            _converters = new Dictionary<Type, ITelegramBotCallbackDataConverter>();
            AddOrUpdateConverter<byte, TelegramBotCallbackDataNumberConverter>();
            AddOrUpdateConverter<byte?, TelegramBotCallbackDataNumberConverter>();

            AddOrUpdateConverter<sbyte, TelegramBotCallbackDataNumberConverter>();
            AddOrUpdateConverter<sbyte?, TelegramBotCallbackDataNumberConverter>();

            AddOrUpdateConverter<short, TelegramBotCallbackDataNumberConverter>();
            AddOrUpdateConverter<short?, TelegramBotCallbackDataNumberConverter>();

            AddOrUpdateConverter<ushort, TelegramBotCallbackDataNumberConverter>();
            AddOrUpdateConverter<ushort?, TelegramBotCallbackDataNumberConverter>();

            AddOrUpdateConverter<int, TelegramBotCallbackDataNumberConverter>();
            AddOrUpdateConverter<int?, TelegramBotCallbackDataNumberConverter>();

            AddOrUpdateConverter<uint, TelegramBotCallbackDataNumberConverter>();
            AddOrUpdateConverter<uint?, TelegramBotCallbackDataNumberConverter>();

            AddOrUpdateConverter<long, TelegramBotCallbackDataNumberConverter>();
            AddOrUpdateConverter<long?, TelegramBotCallbackDataNumberConverter>();

            AddOrUpdateConverter<ulong, TelegramBotCallbackDataNumberConverter>();
            AddOrUpdateConverter<ulong?, TelegramBotCallbackDataNumberConverter>();

            AddOrUpdateConverter<float, TelegramBotCallbackDataNumberConverter>();
            AddOrUpdateConverter<float?, TelegramBotCallbackDataNumberConverter>();

            AddOrUpdateConverter<double, TelegramBotCallbackDataNumberConverter>();
            AddOrUpdateConverter<double?, TelegramBotCallbackDataNumberConverter>();

            AddOrUpdateConverter<decimal, TelegramBotCallbackDataNumberConverter>();
            AddOrUpdateConverter<decimal?, TelegramBotCallbackDataNumberConverter>();

            AddOrUpdateConverter<char, TelegramBotCallbackDataCharConverter>();
            AddOrUpdateConverter<char?, TelegramBotCallbackDataCharConverter>();

            AddOrUpdateConverter<bool, TelegramBotCallbackDataBooleanConverter>();
            AddOrUpdateConverter<bool?, TelegramBotCallbackDataBooleanConverter>();

            AddOrUpdateConverter<DateTime, TelegramBotCallbackDataDateTimeConverter>();
            AddOrUpdateConverter<DateTime?, TelegramBotCallbackDataDateTimeConverter>();

            AddOrUpdateConverter<object, TelegramBotCallbackDataObjectConverter>();
            AddOrUpdateConverter<string, TelegramBotCallbackDataTextConverter>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TConverter"></typeparam>
        /// <param name="type"></param>
        public static void AddOrUpdateConverter<TConvertValueType, TConverter>() where TConverter : ITelegramBotCallbackDataConverter, new()
        {
            var type = typeof(TConvertValueType);
            if (_converters.ContainsKey(type))
            {
                _converters[type] = new TConverter();
                return;
            }

            _converters.Add(type, new TConverter());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ITelegramBotCallbackDataConverter GetConverter(Type type)
        {
            if (!_converters.ContainsKey(type))
                throw new NotImplementedException($"Converter not implemented for '{type}' type!");

            return _converters[type];
        }
    }
}
