using System;

namespace SB.Common.Logics.Variables
{
    /// <summary>
    /// 
    /// </summary>
    public class StringConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertToString(object value)
        {
            return value == null ? string.Empty : value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="textValue"></param>
        /// <returns></returns>
        public static T ConvertToObject<T>(string textValue)
        {
            return (T)Convert.ChangeType(textValue, typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="convertType"></param>
        /// <param name="textValue"></param>
        /// <returns></returns>
        public static object ConvertToObject(Type convertType, string textValue)
        {
            return Convert.ChangeType(textValue, convertType);
        }
    }
}
