namespace SB.Common.Logics.Variables.Logics.VariableValue
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVariableValueSetter
    {
        /// <summary>
        /// 
        /// </summary>
        Variable Variable { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        void SetVariableValue(object value);
    }
}
