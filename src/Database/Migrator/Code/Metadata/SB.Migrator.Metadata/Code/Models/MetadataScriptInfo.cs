using SB.Migrator.Metadata.Logics.Metadata.Models;
using SB.Migrator.Models.Scripts;

namespace SB.Migrator.Metadata.Logics.Code.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MetadataScriptInfo : ScriptInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public ScriptMetadata ScriptMetadata { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scriptMetadata"></param>
        public MetadataScriptInfo(ScriptMetadata scriptMetadata)
        {
            ScriptMetadata = scriptMetadata;
            ScriptText = scriptMetadata.ScriptText;
            MigrateName = scriptMetadata.MigrateName;
            Version = scriptMetadata.Version;
        }
    }
}
