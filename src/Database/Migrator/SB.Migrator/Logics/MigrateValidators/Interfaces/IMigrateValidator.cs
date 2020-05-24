namespace SB.Migrator
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMigrateValidator
    {
        /// <summary>
        /// 
        /// </summary>
        void Valid();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsActual();
    }
}
