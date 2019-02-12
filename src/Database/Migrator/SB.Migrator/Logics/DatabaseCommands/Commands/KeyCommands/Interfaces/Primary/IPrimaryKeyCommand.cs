using SB.Migrator.Models.Tables.Constraints;

namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPrimaryKeyCommand : IDatabaseCommand
    {
        /// <summary>
        /// 
        /// </summary>
        PrimaryKeyInfo PrimaryKey { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="primaryKey"></param>
        void SetPrimaryKey(PrimaryKeyInfo primaryKey);
    }
}