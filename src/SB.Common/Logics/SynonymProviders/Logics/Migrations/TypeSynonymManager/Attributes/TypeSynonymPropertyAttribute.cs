using System;

namespace SB.Common.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class TypeSynonymPropertyAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public TypeSynonymPropertyAttribute(string name)
        {
            Name = name;
        }
    }
}
