using System;
using System.IO;
using System.Xml.Serialization;
using SB.Common.Helpers;

namespace SB.Common.Extensions.System
{
    /// <summary>
    /// 
    /// </summary>
    public static class XmlDeserializer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlFilePath"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string xmlFilePath)
        {
            try
            {
                return InternalDeserialize<T>(xmlFilePath);
            }
            catch (Exception e)
            {
                LogHelper.Error(e);
                return default(T);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlFilePath"></param>
        /// <returns></returns>
        private static T InternalDeserialize<T>(string xmlFilePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(xmlFilePath))
                return (T)serializer.Deserialize(reader);
        }
    }
}
