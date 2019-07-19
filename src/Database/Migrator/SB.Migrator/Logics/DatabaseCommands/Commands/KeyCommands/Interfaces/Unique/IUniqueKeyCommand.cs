using SB.Migrator.Models.Tables.Constraints;
using SB.Migrator.Models.Tables.Keys;

namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUniqueKeyCommand : IDatabaseCommand
    {
        /// <summary>
        /// 
        /// </summary>
        UniqueKeyInfo UniqueKey { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uniqueKey"></param>
        void SetUniqueKey(UniqueKeyInfo uniqueKey);
    }
}
