namespace SB.Migrator
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MigrateManager
    {
        /// <summary>
        /// 
        /// </summary>
        public event MigrateBeginHandler MigrateBegin;

        /// <summary>
        /// 
        /// </summary>
        public event MigrateEndHandler MigrateEnd;

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnMigrateBegin()
        {
            MigrateBegin?.Invoke(this);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnMigrateEnd()
        {
            MigrateEnd?.Invoke(this);
        }
    }
}
