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
        Variable Variable { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool IsCanConvert(object value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        object Convert(object value);
    }
}