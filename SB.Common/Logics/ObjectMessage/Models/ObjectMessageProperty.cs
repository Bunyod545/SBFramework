using SBCommon.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB.Common.Logics.ObjectMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectMessageProperty
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ObjectMessagePropertyInfo> Properties { get; }

        /// <summary>
        /// 
        /// </summary>
        public ObjectMessageProperty()
        {
            Properties = new List<ObjectMessagePropertyInfo>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="obj"></param>
        public void Add(string property, object obj)
        {
            Properties.Add(new ObjectMessagePropertyInfo(obj, property));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="obj"></param>
        public void AddToStartArgsIndex(int index, object obj)
        {
            var sb = new StringBuilder();
            sb.Append(Strings.LSquareBracket);
            sb.Append(index);
            sb.Append(Strings.RSquareBracket);

            Properties.Insert(0, new ObjectMessagePropertyInfo(obj, sb.ToString()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="obj"></param>
        public void AddIndex(int index, object obj)
        {
            var sb = new StringBuilder();
            sb.Append(Strings.LSquareBracket);
            sb.Append(index);
            sb.Append(Strings.RSquareBracket);

            Properties.Add(new ObjectMessagePropertyInfo(obj, sb.ToString()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="property"></param>
        public void ReplaceLast(object obj, string property)
        {
            var last = Properties.LastOrDefault(l => l.PropertyObject == obj);
            if (last != null)
                Properties.Remove(last);

            Properties.Add(new ObjectMessagePropertyInfo(obj, property));
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            Properties.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(Strings.Point, Properties.Select(s => s.PropertyName));
        }
    }
}
