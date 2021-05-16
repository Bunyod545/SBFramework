using System;

namespace SB.CodeMigration
{
    /// <summary>
    /// 
    /// </summary>
    public class CodeMigrationDefaultActivator : ICodeMigrationActivator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="migratorType"></param>
        /// <returns></returns>
        public ICodeMigrator Activate(Type migratorType)
        {
            return (ICodeMigrator)Activator.CreateInstance(migratorType);
        }
    }
}
