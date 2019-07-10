using System;

namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Enum)]
    public class TableAttribute : System.ComponentModel.DataAnnotations.Schema.TableAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public static string DefaultSchema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TableAttribute() : base(null)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public TableAttribute(string name) : base(name)
        {
            Schema = DefaultSchema;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="schema"></param>
        public TableAttribute(string name, string schema) : base(name)
        {
            Schema = schema;
        }
    }
}
