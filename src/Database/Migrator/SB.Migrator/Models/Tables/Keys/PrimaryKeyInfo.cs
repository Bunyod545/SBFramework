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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{PrimaryColumn} {Name}";
        }
    }
}
