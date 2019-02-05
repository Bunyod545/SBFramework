using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SB.Common.Logics.ObjectMessage
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class DefaulMessagePropertyBuilder : IMessagePropertyBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        public ObjectMessageBuilder Builder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ObjectMessagePropertyManager PropertyManager => Builder?.PropertyManager;

        /// <summary>
        /// 
        /// </summary>
        public ObjectMessageReplaceHelper ReplaceHelper => Builder?.ReplaceHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected DefaulMessagePropertyBuilder(ObjectMessageBuilder builder)
        {
            Builder = builder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public abstract bool IsCanWork(object obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual List<PropertyInfo> GetProperties(object obj)
        {
            return new List<PropertyInfo>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="messageProperty"></param>
        public virtual void Build(object obj, ObjectMessageProperty messageProperty)
        {
            ReplaceHelper.Replace(messageProperty, obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="messageProperty"></param>
        public virtual void BuildInnerProperties(object obj, ObjectMessageProperty messageProperty)
        {
            if (Builder.CirculationObjects.Any(a => ReferenceEquals(a, obj)))
                return;

            var props = PropertyManager.GetProperties(obj);
            props.ForEach(f => BuildInnerProperty(obj, f, messageProperty));

            if(props.Any())
                Builder.CirculationObjects.Add(obj);

            if(!props.Any())
                BuildWithOutProperty(obj, messageProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="property"></param>
        /// <param name="info"></param>
        public virtual void BuildInnerProperty(object obj, PropertyInfo property, ObjectMessageProperty info)
        {
            info.ReplaceLast(obj, property.Name);

            var propValue = property.GetValue(obj);
            ReplaceHelper.Replace(info, propValue);
            BuildInnerProperties(propValue, info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="messageProperty"></param>
        public virtual void BuildWithOutProperty(object obj, ObjectMessageProperty messageProperty)
        {
            ReplaceHelper.Replace(messageProperty, obj);
        }
    }
}
