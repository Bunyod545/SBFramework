using SB.Migrator.Models.Scripts;

namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public interface IScriptCommand : IDatabaseCommand
    {
        /// <summary>
        /// 
        /// </summary>
        ScriptInfo ScriptInfo { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scriptInfo"></param>
        void SetScript(ScriptInfo scriptInfo);
    }
}
