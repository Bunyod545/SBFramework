using System;

namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStringConvertable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string ConvertToString(object value);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="textValue"></param>
        /// <returns></returns>
        T ConvertToObject<T>(string textValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="convertType"></param>
        /// <param name="textValue"></param>
        object? ConvertToObject(Type convertType, string textValue);
    }
}