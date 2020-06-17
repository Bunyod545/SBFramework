namespace SB.Common.Logics.Variables
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseVariableContext
    {
        /// <summary>
        /// 
        /// </summary>
        protected BaseVariableContext()
        {
            VariableManager.Initialize(this);
        }
    }
}
