namespace SB.Auto.DependenyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public class SingletonServiceAttribute : ServiceAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public SingletonServiceAttribute()
        {
            LifeCycle = ServiceLifeCycle.Singleton;
        }
    }
}
