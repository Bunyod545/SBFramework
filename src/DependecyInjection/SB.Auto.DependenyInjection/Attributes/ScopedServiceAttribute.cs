namespace SB.Auto.DependenyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public class ScopedServiceAttribute : ServiceAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public ScopedServiceAttribute()
        {
            LifeCycle = ServiceLifeCycle.Scoped;
        }
    }
}
