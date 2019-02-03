using SBCommon.Helpers;
using System;
using System.Collections;
using System.Text;

namespace SB.Common.Logics.ObjectMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class ArrayMessagePropertyBuilder : DefaulMessagePropertyBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public ArrayMessagePropertyBuilder(ObjectMessageBuilder builder) : base(builder)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool IsCanWork(object obj)
        {
            return obj != null && obj.GetType().IsArray || obj is IEnumerable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="messageProperty"></param>
        public override void Build(object obj, ObjectMessageProperty messageProperty)
        {
            if (obj is Array array)
                BuildArray(array.GetEnumerator(), messageProperty);

            if (obj is IEnumerable enumerable)
                BuildArray(enumerable.GetEnumerator(), messageProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerator"></param>
        /// <param name="messageProperty"></param>
        private void BuildArray(IEnumerator enumerator, ObjectMessageProperty messageProperty)
        {
            if (enumerator == null)
                return;

            var index = 0;
            while (enumerator.MoveNext())
                BuildArrayItem(enumerator, messageProperty, index++);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumerator"></param>
        /// <param name="messageProperty"></param>
        /// <param name="index"></param>
        private void BuildArrayItem(IEnumerator enumerator, ObjectMessageProperty messageProperty, int index)
        {
            var sb = new StringBuilder();
            sb.Append(Strings.LSquareBracket);
            sb.Append(index);
            sb.Append(Strings.RSquareBracket);

            messageProperty.ReplaceProperty(enumerator, sb.ToString());
            PropertyManager.BuildInnerProperties(enumerator.Current, messageProperty);
        }
    }
}
