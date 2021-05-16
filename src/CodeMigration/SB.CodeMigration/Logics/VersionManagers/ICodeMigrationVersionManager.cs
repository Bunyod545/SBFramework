using System;

namespace SB.CodeMigration
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICodeMigrationVersionManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Version GetVersion();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
        void SetVersion(Version version);
    }
}
