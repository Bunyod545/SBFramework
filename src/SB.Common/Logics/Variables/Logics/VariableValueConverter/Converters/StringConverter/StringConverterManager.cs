using System;
using System.Linq;
using System.Reflection;

namespace SB.Common.Logics.Variables
{
    /// <summary>
    /// 
    /// </summary>
    public class StringConverterManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertToString(object value)
        {
            if (value == null)
                return string.Empty;

            var type = value.GetType();
            var attr = type.GetCustomAttribute<StringConverterAttribute>();
            if (attr != null)
                return attr.ConvertToString(value);

            if (value is IStringConvertable convertable)
                return convertable.ConvertToString(value);

            return StringConverter.ConvertToString(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="textValue"></param>
        /// <returns></returns>
        public static T ConvertToObject<T>(string textValue)
        {
            var interfaceType = typeof(IStringConvertable);
            var typeInterfaces = typeof(T).GetInterfaces();

            var attr = typeof(T).GetCustomAttribute<StringConverterAttribute>();
            if (attr != null)
                return attr.ConvertToObject<T>(textValue);

            if (typeInterfaces.All(a => a != interfaceType))
                return StringConverter.ConvertToObject<T>(textValue);

            if (!(Activator.CreateInstance(typeof(T)) is IStringConvertable convertable))
                return default(T);

            return convertable.ConvertToObject<T>(textValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="convertType"></param>
        /// <param name="textValue"></param>
        /// <returns></returns>
        public static object ConvertToObject(Type convertType, string textValue)
        {
            var interfaceType = typeof(IStringConvertable);
            var typeInterfaces = convertType.GetInterfaces();

            var attr = convertType.GetCustomAttribute<StringConverterAttribute>();
            if (attr != null)
                return attr.ConvertToObject(convertType, textValue);

            if (typeInterfaces.All(a => a != interfaceType))
                return StringConverter.ConvertToObject(convertType, textValue);

            if (!(Activator.CreateInstance(convertType) is IStringConvertable convertable))
                return null;

            return convertable.ConvertToObject(convertType, textValue);
        }
    }
}
