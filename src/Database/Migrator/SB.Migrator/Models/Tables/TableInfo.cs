using System.Collections.Generic;
using System.Linq;
using SB.Migrator.Models.Column;
using SB.Migrator.Models.Tables.Constraints;

namespace SB.Migrator.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TableInfo
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
        public List<ColumnInfo> Columns { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PrimaryKeyInfo PrimaryKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ForeignKeyInfo> ForeignKeys { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TableInfo()
        {
            Columns = new List<ColumnInfo>();
            ForeignKeys = new List<ForeignKeyInfo>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ColumnInfo GetColumn(string name)
        {
            return Columns.FirstOrDefault(f => f.Name == name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[{Schema}].[{Name}]";
        }
    }
}
