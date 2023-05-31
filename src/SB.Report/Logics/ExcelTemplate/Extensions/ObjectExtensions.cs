using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

namespace SB.Report.Logics.ExcelTemplate.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this object obj)
        {
            if (obj == null)
                return null;

            //DataContractJsonSerializer bf = new DataContractJsonSerializer(typeof(object));
            //var memStream = new MemoryStream();
            //bf.WriteObject(memStream, obj);
            //return memStream.ToArray();
            using (MemoryStream ms = new MemoryStream())
            {
                //byte[] bytes = BitConverter.GetBytes((dynamic)obj);
                //ms.Write(bytes, 0, bytes.Length);
                return ms.ToArray();
            }
        }
    }
}
