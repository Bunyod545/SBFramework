using System;

namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConstantValueSetter
    {
        /// <summary>
        /// 
        /// </summary>
        ConstantSet Constant { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        void SetConstantValue<T>(T value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="moment"></param>
        /// <typeparam name="T"></typeparam>
        void SetPeriodicValue<T>(T value, DateTime? moment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="moment"></param>
        /// <typeparam name="T"></typeparam>
        void SetPeriodicValue<T>(long id, T value, DateTime? moment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueId"></param>
        void DeleteConstantValue(long valueId);
    }
}