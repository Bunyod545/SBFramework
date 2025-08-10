using System;
using System.Collections.Generic;
using System.Reflection;

namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ConstantSet
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PropertyInfo PropertyInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type ValueType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object DefaultValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IConstantValueGetter ConstantValueGetter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IConstantValueSetter ConstantValueSetter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IConstantValueConverter ConstantValueConverter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IConstantRepository ConstantRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected ConstantSet()
        {
            ConstantValueGetter = new DefaultConstantValueGetter(this);
            ConstantValueSetter = new DefaultConstantValueSetter(this);
            ConstantValueConverter = new DefaultConstantValueConverter(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual T GetConstantValue<T>()
        {
            if (ConstantValueGetter == null)
                throw new NotImplementedException(nameof(ConstantValueGetter));

            return ConstantValueGetter.GetConstantValue<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual List<ConstantValueInfo<T>> GetConstantValues<T>()
        {
            if (ConstantValueGetter == null)
                throw new NotImplementedException(nameof(ConstantValueGetter));

            return ConstantValueGetter.GetConstantValues<T>();
        }

        /// <summary>
        /// Add or update primitive value
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        public virtual void SetConstantValue<T>(T value)
        {
            if (ConstantValueSetter is null)
                throw new NotImplementedException(nameof(ConstantValueSetter));

            ConstantValueSetter.SetConstantValue(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="moment"></param>
        /// <typeparam name="T"></typeparam>
        protected virtual void SetPeriodicValue<T>(T value, DateTime? moment)
        {
            if (ConstantValueSetter is null)
                throw new NotImplementedException(nameof(ConstantValueSetter));

            ConstantValueSetter.SetPeriodicValue(value, moment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="moment"></param>
        /// <typeparam name="T"></typeparam>
        protected virtual void SetPeriodicValue<T>(long id, T value, DateTime? moment)
        {
            if (ConstantValueSetter is null)
                throw new NotImplementedException(nameof(ConstantValueSetter));

            ConstantValueSetter.SetPeriodicValue(id, value, moment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueId"></param>
        protected void DeleteConstantValue(long valueId)
        {
            if (ConstantValueSetter is null)
                throw new NotImplementedException(nameof(ConstantValueSetter));

            ConstantValueSetter.DeleteConstantValue(valueId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract ConstantSet Clone(object context);
    }
}