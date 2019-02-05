using System.Collections.Generic;
using System.Reflection;

namespace SB.Common.Logics.ObjectMessage
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMessagePropertyBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        ObjectMessageBuilder Builder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool IsCanWork(object obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        List<PropertyInfo> GetProperties(object obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="messageProperty"></param>
        void Build(object obj, ObjectMessageProperty messageProperty);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="messageProperty"></param>
        void BuildInnerProperties(object obj, ObjectMessageProperty messageProperty);
    }
}