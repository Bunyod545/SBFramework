using System.Collections.Generic;
using System.Reflection;

namespace SB.Common.Logics.ObjectMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectMessagePropertyBuilder : DefaulMessagePropertyBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public ObjectMessagePropertyBuilder(ObjectMessageBuilder builder) : base(builder)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool IsCanWork(object obj)
        {
            return obj != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override List<PropertyInfo> GetProperties(object obj)
        {
            return ObjectMessageBuildHelper.GetProperties(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="messageProperty"></param>
        public override void Build(object obj, ObjectMessageProperty messageProperty)
        {
            ReplaceHelper.Replace(messageProperty, obj);
            PropertyManager.BuildInnerProperties(obj, messageProperty);
        }
    }
}
