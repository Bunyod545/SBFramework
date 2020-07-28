using System.Collections.Generic;
using SB.Migrator.Models.Scripts;

namespace SB.Migrator.Logics.Scripts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IActualizationScriptsManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ScriptInfo> GetBeforeActualizationScripts();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ScriptInfo> GetAfterActualizationScripts();
    }
}
