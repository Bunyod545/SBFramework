using System;

namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public static string DefaultSchema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }

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
        public TableAttribute(string name) : this(name, DefaultSchema)
        {
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
