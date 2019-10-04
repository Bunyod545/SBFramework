using SB.Common.Logics.Variables.Logics.ValueConverter;

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
        IVariableValueConverter ValueConverter { get; set; }

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