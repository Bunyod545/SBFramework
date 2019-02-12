using SB.Migrator.Models.Tables.Constraints;

namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public interface IForeignKeyCommand : IDatabaseCommand
    {
        /// <summary>
        /// 
        /// </summary>
        ForeignKeyInfo ForeignKey { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="foreignKey"></param>
        void SetForeignKey(ForeignKeyInfo foreignKey);
    }
}
