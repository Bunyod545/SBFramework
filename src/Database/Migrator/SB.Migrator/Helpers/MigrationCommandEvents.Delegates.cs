using SB.Migrator.Models;

namespace SB.Migrator.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tableInfo"></param>
    public delegate void TableCommandHandler(TableInfo tableInfo);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tableInfo"></param>
    public delegate void ColumnCommandHandler(TableInfo tableInfo);

    /// <summary>
    /// 
    /// </summary>
    public static partial class MigrationCommandEvents
    {

    }
}
