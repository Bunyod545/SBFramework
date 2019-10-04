namespace SB.Common.Logics.Variables
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Variable<T> : Variable
    {
        /// <summary>
        /// 
        /// </summary>
        public T Value { get => (T)GetVariableValue(); set => SetValue(value); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(T value)
        {
            base.SetVariableValue(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        public static implicit operator T(Variable<T> variable)
        {
            return variable.Value;
        }
    }
}
