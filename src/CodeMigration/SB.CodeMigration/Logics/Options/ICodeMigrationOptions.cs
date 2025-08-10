using System;

namespace SB.CodeMigration
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICodeMigrationOptions
    {
        /// <summary>
        /// 
        /// </summary>
        ICodeMigrationActivator Activator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ICodeMigrationLogger Logger { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Type AttributeType { get; set; }
    }
}