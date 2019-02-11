using SB.Migrator.Models.Column;

namespace SB.Migrator.Models.Tables.Constraints
{
    /// <summary>
    /// 
    /// </summary>
    public class PrimaryKeyInfo : KeyInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public ColumnInfo PrimaryColumn { get; set; }
    }
}
