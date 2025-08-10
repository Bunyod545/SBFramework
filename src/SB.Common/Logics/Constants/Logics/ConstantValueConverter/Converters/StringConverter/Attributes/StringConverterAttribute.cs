
using System;

namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class StringConverterAttribute : Attribute, IStringConvertable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual string ConvertToString(object value)
        {
            return StringConverter.ConvertToString(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="textValue"></param>
        /// <returns></returns>
        public virtual T ConvertToObject<T>(string textValue)
        {
            return (T)Convert.ChangeType(textValue, typeof(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="convertType"></param>
        /// <param name="textValue"></param>
        /// <returns></returns>
        public virtual object? ConvertToObject(Type convertType, string textValue)
        {
            return null;
        }
    }
}