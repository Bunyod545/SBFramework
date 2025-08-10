using System;
using System.Collections.Generic;

namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConstantSet<T> : ConstantSet
    {
        /// <summary>
        /// 
        /// </summary>
        public ConstantValueInfo<T> Value
        {
            get => GetConstantValue<T>();
            set => SetValue(value.Value);
        }

        /// <summary>
        /// Add non periodic value
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        public void SetValue(T value)
        {
            if (value is null)
                return;

            SetConstantValue(value);
        }

        /// <summary>
        /// Add non periodic value
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        public void SetValueId(long value)
        {
            SetConstantValue(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        public void SetValueId(long value, DateTime moment)
        {
            SetPeriodicValue(value, moment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="moment"></param>
        public void SetValueId(long id, long value, DateTime moment)
        {
            SetPeriodicValue(id, value, moment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T GetValue()
        {
            return GetConstantValue<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ConstantValueInfo<T>> GetValues()
        {
            return GetConstantValues<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueId"></param>
        public void DeleteValue(long valueId)
        {
            DeleteConstantValue(valueId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override ConstantSet Clone(object context)
        {
            var clone = new ConstantSet<T>();
            clone.Name = Name;
            clone.PropertyInfo = PropertyInfo;
            clone.ValueType = ValueType;
            clone.DefaultValue = DefaultValue;

            return clone;
        }
    }
}