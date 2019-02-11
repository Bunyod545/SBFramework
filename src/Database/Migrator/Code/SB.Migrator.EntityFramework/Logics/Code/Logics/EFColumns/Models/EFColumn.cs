using System.Reflection;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class EFColumn
    {
        /// <summary>
        /// 
        /// </summary>
        public EFTableInfo Table { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PropertyInfo Property { get; set; }
    }
}
