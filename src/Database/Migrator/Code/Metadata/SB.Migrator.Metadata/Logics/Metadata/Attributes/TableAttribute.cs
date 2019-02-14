using System;

namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TableAttribute()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public TableAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="schema"></param>
        public TableAttribute(string name, string schema)
        {
            Name = name;
            Schema = schema;
        }
    }
}
