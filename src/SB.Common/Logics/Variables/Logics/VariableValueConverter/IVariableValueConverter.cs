namespace SB.Common.Logics.Variables.Logics.ValueConverter
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVariableValueConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool IsCanConvert(Variable variable, object value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        object Convert(Variable variable, object value);
    }
}