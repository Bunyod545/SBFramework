namespace SB.Common.Logics.Variables.Logics.VariableValue
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVariableValueGetter
    {
        /// <summary>
        /// 
        /// </summary>
        Variable Variable { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        object GetVariableValue();
    }
}