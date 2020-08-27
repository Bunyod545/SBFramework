using System;
using System.Collections.Generic;

namespace SB.Common.Logics.SbStringConverters.Converters
{
    /// <summary>
    /// 
    /// </summary>
    public static class SbStringConverterFactory
    {
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<Type, ISbStringConverter> _converters;

        /// <summary>
        /// 
        /// </summary>
        static SbStringConverterFactory()
        {
            _converters = new Dictionary<Type, ISbStringConverter>();
            AddOrUpdateConverter<byte, SbStringNumberConverter>();
            AddOrUpdateConverter<byte?, SbStringNumberConverter>();

            AddOrUpdateConverter<sbyte, SbStringNumberConverter>();
            AddOrUpdateConverter<sbyte?, SbStringNumberConverter>();

            AddOrUpdateConverter<short, SbStringNumberConverter>();
            AddOrUpdateConverter<short?, SbStringNumberConverter>();

            AddOrUpdateConverter<ushort, SbStringNumberConverter>();
            AddOrUpdateConverter<ushort?, SbStringNumberConverter>();

            AddOrUpdateConverter<int, SbStringNumberConverter>();
            AddOrUpdateConverter<int?, SbStringNumberConverter>();

            AddOrUpdateConverter<uint, SbStringNumberConverter>();
            AddOrUpdateConverter<uint?, SbStringNumberConverter>();

            AddOrUpdateConverter<long, SbStringNumberConverter>();
            AddOrUpdateConverter<long?, SbStringNumberConverter>();

            AddOrUpdateConverter<ulong, SbStringNumberConverter>();
            AddOrUpdateConverter<ulong?, SbStringNumberConverter>();

            AddOrUpdateConverter<float, SbStringNumberConverter>();
            AddOrUpdateConverter<float?, SbStringNumberConverter>();

            AddOrUpdateConverter<double, SbStringNumberConverter>();
            AddOrUpdateConverter<double?, SbStringNumberConverter>();

            AddOrUpdateConverter<decimal, SbStringNumberConverter>();
            AddOrUpdateConverter<decimal?, SbStringNumberConverter>();

            AddOrUpdateConverter<char, SbStringCharConverter>();
            AddOrUpdateConverter<char?, SbStringCharConverter>();

            AddOrUpdateConverter<bool, SbStringBooleanConverter>();
            AddOrUpdateConverter<bool?, SbStringBooleanConverter>();

            AddOrUpdateConverter<DateTime, SbStringDateTimeConverter>();
            AddOrUpdateConverter<DateTime?, SbStringDateTimeConverter>();

            AddOrUpdateConverter<object, SbStringObjectConverter>();
            AddOrUpdateConverter<string, SbStringTextConverter>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TConverter"></typeparam>
        /// <param name="type"></param>
        public static void AddOrUpdateConverter<TConvertValueType, TConverter>() where TConverter : ISbStringConverter, new()
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
        public static ISbStringConverter GetConverter(Type type)
        {
            if (!_converters.ContainsKey(type))
                throw new NotImplementedException($"Converter not implemented for '{type}' type!");

            return _converters[type];
        }
    }
}
