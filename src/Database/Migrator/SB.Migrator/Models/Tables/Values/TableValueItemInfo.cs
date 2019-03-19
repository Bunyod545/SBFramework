using SB.Migrator.Models.Column;

namespace SB.Migrator.Models.Tables.Values
{
    /// <summary>
    /// 
    /// </summary>
    public class TableValueItemInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public ColumnInfo Column { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Column?.Name} = {Value}";
        }
    }
}
