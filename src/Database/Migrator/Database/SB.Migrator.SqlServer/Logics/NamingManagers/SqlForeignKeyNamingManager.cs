using SB.Migrator.Logics.NamingManagers;
using SB.Migrator.Models.Tables.Constraints;

namespace SB.Migrator.SqlServer.Logics.NamingManagers
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlForeignKeyNamingManager : IForeignKeyNamingManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="foreignKey"></param>
        public void Correct(ForeignKeyInfo foreignKey)
        {
            foreignKey.Name = string.IsNullOrEmpty(foreignKey.Name)
                ? $"FK_{foreignKey.Table.Name}_{foreignKey.ReferenceTable.Name}_{foreignKey.Column.Name}"
                : foreignKey.Name;
        }
    }
}
