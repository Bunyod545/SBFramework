using System;

namespace SB.CodeMigration
{
    /// <summary>
    /// 
    /// </summary>
    public class CodeMigrationDefaultOptions : ICodeMigrationOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public ICodeMigrationActivator Activator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICodeMigrationLogger Logger { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type AttributeType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CodeMigrationDefaultOptions()
        {
            Activator = new CodeMigrationDefaultActivator();
            Logger = new CodeMigrationDefaultLogger();
            AttributeType = typeof(CodeMigrationAttribute);
        }
    }
}