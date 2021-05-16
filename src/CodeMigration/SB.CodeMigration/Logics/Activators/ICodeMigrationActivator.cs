using System;

namespace SB.CodeMigration
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICodeMigrationActivator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="migratorType"></param>
        /// <returns></returns>
        ICodeMigrator Activate(Type migratorType);
    }
}
