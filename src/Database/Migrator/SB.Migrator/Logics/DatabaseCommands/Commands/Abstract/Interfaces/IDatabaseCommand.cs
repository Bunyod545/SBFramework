namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDatabaseCommand
    {
        /// <summary>
        /// 
        /// </summary>
        int Order { get; }

        /// <summary>
        /// 
        /// </summary>
        string CommandText { get; }

        /// <summary>
        /// 
        /// </summary>
        void BuildCommandText();

        /// <summary>
        /// 
        /// </summary>
        void Execute();
    }
}
