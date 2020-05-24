using SB.Migrator.Logics.DatabaseCommands;

namespace SB.Migrator.Logics.DatabaseCommandServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDatabaseCommandsService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        void Register<TCommand>() where TCommand : class, IDatabaseCommand;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        void UnRegister<TCommand>() where TCommand : class, IDatabaseCommand;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        TCommand GetCommand<TCommand>() where TCommand : class, IDatabaseCommand;

        /// <summary>
        /// 
        /// </summary>
        void Clear();
    }
}