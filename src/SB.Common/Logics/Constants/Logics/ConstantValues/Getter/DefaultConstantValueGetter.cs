using SB.Common.Logics.Business;
using SB.Common.Logics.Metadata;
using System;
using System.Collections.Generic;

namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultConstantValueGetter : IConstantValueGetter
    {
        /// <summary>
        /// 
        /// </summary>
        public ConstantSet Constant { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public Type ValueType => Constant.ValueType;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constant"></param>
        public DefaultConstantValueGetter(ConstantSet constant)
        {
            Constant = constant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T GetConstantValue<T>()
        {
            var dbType = SBType.GetType(ValueType);
            if (dbType is null)
                return GetNullValueOrDefault<T>();

            var constantValue = Constant
                .ConstantRepository
                .GetConstantValue(Constant.Name);

            if (constantValue is null)
                return GetNullValueOrDefault<T>();

            if (!dbType.IsPrimitive)
            {
                return GetEntity<T>(constantValue.Value);
            }

            var value = Constant.ConstantValueConverter.Convert(constantValue.Value);
            if (value is null)
                return default;

            return (T)value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual T GetNullValueOrDefault<T>()
        {
            if (ValueType == Constant.DefaultValue?.GetType())
                return (T)Constant.DefaultValue;

            if (ValueType.IsNullable())
                return default;

            if (ValueType.IsValueType)
                return (T)Activator.CreateInstance(ValueType);

            return default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private T GetEntity<T>(string value)
        {
            var isParsed = long.TryParse(value, out var id);
            if (!isParsed)
                return default;

            return Constant.ConstantRepository.GetEntity<T>(ValueType, id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<ConstantValueInfo<T>> GetConstantValues<T>()
        {
            var res = new List<ConstantValueInfo<T>>();
            var dbType = SBType.GetType(ValueType);
            if (dbType is null)
                return res;

            var constantValues = Constant.GetConstantValues<T>();
            constantValues.ForEach(s => InitConstantValue(s, res, dbType));
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constantValue"></param>
        /// <param name="res"></param>
        /// <param name="dbType"></param>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        private void InitConstantValue<T>(ConstantValueInfo<T> constantValue, List<ConstantValueInfo<T>> res, SBType dbType)
        {
            var constantInfo = new ConstantValueInfo<T>();
            constantInfo.Id = constantValue.Id;
            constantInfo.Moment = constantValue.Moment;

            if (!dbType.IsPrimitive)
            {
                constantInfo.Value = GetEntity<T>("");
                res.Add(constantInfo);
                return;
            }

            if (Constant.ConstantValueConverter.IsCanConvert(constantValue.Value))
                constantInfo.Value = (T)Constant.ConstantValueConverter.Convert(constantValue.Value);

            res.Add(constantInfo);
        }
    }
}