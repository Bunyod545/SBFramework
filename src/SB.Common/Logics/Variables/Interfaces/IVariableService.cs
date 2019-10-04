namespace SB.Common.Logics.Variables.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVariableService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        object GetVariableValue(Variable variable);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        void SetVariableValue(Variable variable, object value);
    }
}
