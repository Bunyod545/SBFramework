using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SB.Common.Logics.ObjectMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectMessagePropertyManager
    {
        /// <summary>
        /// 
        /// </summary>
        private List<IMessagePropertyBuilder> _builders;

        /// <summary>
        /// 
        /// </summary>
        public ObjectMessageBuilder Builder { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public ObjectMessagePropertyManager(ObjectMessageBuilder builder)
        {
            Builder = builder;
            InitializeBuilders();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeBuilders()
        {
            _builders = new List<IMessagePropertyBuilder>();
            _builders.Add(new StringMessagePropertyBuilder(Builder));
            _builders.Add(new ArrayMessagePropertyBuilder(Builder));
            _builders.Add(new ObjectMessagePropertyBuilder(Builder));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<PropertyInfo> GetProperties(object obj)
        {
            var builder = _builders.FirstOrDefault(f => f.IsCanWork(obj));
            return builder?.GetProperties(obj) ?? new List<PropertyInfo>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="messageProperty"></param>
        public void Build(object obj, ObjectMessageProperty messageProperty)
        {
            var builder = _builders.FirstOrDefault(f => f.IsCanWork(obj));
            builder?.Build(obj, messageProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="messageProperty"></param>
        public void BuildInnerProperties(object obj, ObjectMessageProperty messageProperty)
        {
            var builder = _builders.FirstOrDefault(f => f.IsCanWork(obj));
            builder?.BuildInnerProperties(obj, messageProperty);
        }
    }
}
