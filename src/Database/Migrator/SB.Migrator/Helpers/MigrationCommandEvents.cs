using SB.Migrator.Models;

namespace SB.Migrator.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class MigrationCommandEvents
    {
        /// <summary>
        /// 
        /// </summary>
        public static event TableCommandHandler TableCreated;

        /// <summary>
        /// 
        /// </summary>
        public static event TableCommandHandler TableDroped;

        /// <summary>
        /// 
        /// </summary>
        public static event TableCommandHandler TableRenamed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableInfo"></param>
        public static void TableCreatedInvoke(TableInfo tableInfo)
        {
            TableCreated?.Invoke(tableInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableInfo"></param>
        public static void TableDropedInvoke(TableInfo tableInfo)
        {
            TableDroped?.Invoke(tableInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableInfo"></param>
        public static void TableRenamedInvoke(TableInfo tableInfo)
        {
            TableRenamed?.Invoke(tableInfo);
        }
    }
}
