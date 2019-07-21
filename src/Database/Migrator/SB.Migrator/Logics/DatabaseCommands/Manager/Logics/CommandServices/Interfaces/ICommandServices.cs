namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICommandServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TCommand"></typeparam>
        void Add<T, TCommand>() where T : IDatabaseCommand where TCommand : IDatabaseCommand, T;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Remove<T>() where T : IDatabaseCommand;

        /// <summary>
        /// 
        /// </summary>
        void ResetServices();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetCommand<T>() where T : class, IDatabaseCommand;
    }
}