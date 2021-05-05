namespace SB.Auto.DependenyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public class TransientServiceAttribute : ServiceAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public TransientServiceAttribute()
        {
            LifeCycle = ServiceLifeCycle.Transient;
        }
    }
}
