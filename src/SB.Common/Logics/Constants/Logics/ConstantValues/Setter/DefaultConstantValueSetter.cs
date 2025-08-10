using SB.Common.Logics.Business;
using SB.Common.Logics.Metadata;
using System;
using System.Data;

namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultConstantValueSetter : IConstantValueSetter
    {
        /// <summary>
        /// 
        /// </summary>
        public ConstantSet Constant { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constant"></param>
        public DefaultConstantValueSetter(ConstantSet constant)
        {
            Constant = constant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        public void SetConstantValue<T>(T value)
        {
            var dbType = GetDbType();
            var constant = GetOrCreateConstant(dbType);
            SubmitNonPeriodicValue(value, constant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="moment"></param>
        /// <param name="id"></param>
        /// <typeparam name="T"></typeparam>
        public void SetPeriodicValue<T>(T value, DateTime? moment)
        {
            var dbType = GetDbType();
            var constant = GetOrCreateConstant(dbType);

            if (value is IIdentified idValue)
                SubmitConstantValue(idValue.Id, constant, moment);

            SubmitConstantValue(value, constant, moment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="moment"></param>
        /// <param name="id"></param>
        /// <typeparam name="T"></typeparam>
        public void SetPeriodicValue<T>(long id, T value, DateTime? moment)
        {
            var dbType = GetDbType();
            var constant = GetOrCreateConstant(dbType);

            if (value is IIdentified idValue)
                SubmitConstantValue(idValue.Id, constant, moment, id);

            SubmitConstantValue(value, constant, moment, id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private SBType GetDbType()
        {
            return SBType.GetType(Constant.ValueType) ??
                   throw new ArgumentNullException(Constant.ValueType.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbType"></param>
        private ConstantInfo GetOrCreateConstant(SBType dbType)
        {
            var constant = Constant.ConstantRepository.GetConstant(Constant.Name);
            if (constant != null)
                return constant;

            constant = new ConstantInfo();
            constant.Name = Constant.Name;
            constant.Synonym = Constant.Name;
            constant.IsPrimitive = dbType.IsPrimitive;
            constant.TypeId = dbType.TypeId;

            Constant.ConstantRepository.AddConstant(constant);
            return constant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <param name="constant"></param>
        /// <typeparam name="T"></typeparam>
        private void SubmitConstantValue<T>(T value, ConstantInfo constant, DateTime? moment = null, long? id = null)
        {
            if (id > 0)
            {
                UpdateConstantValue(id, value, constant, moment);
                return;
            }

            AddConstantValue(value, constant, moment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="constant"></param>
        /// <typeparam name="T"></typeparam>
        private void SubmitNonPeriodicValue<T>(T value, ConstantInfo constant)
        {
            var entity = value as IIdentified;
            var constantValue = Constant.ConstantRepository.GetConstantValue(constant.Id);
            if (constantValue is null)
            {
                constantValue = new ConstantValueInfo();
                constantValue.Constant = constant;
                constantValue.Moment = DateTime.Now;

                Constant.ConstantRepository.AddConstantValue(constantValue);
            }

            constantValue.Value = entity is null ? value.ToString() : entity.Id.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="constant"></param>
        /// <param name="moment"></param>
        /// <typeparam name="T"></typeparam>
        private void AddConstantValue<T>(T value, ConstantInfo constant, DateTime? moment = null)
        {
            var constantValue = new ConstantValueInfo();
            constantValue.Constant = constant;
            constantValue.Moment = moment ?? DateTime.Now;
            constantValue.Value = value.ToString();

            Constant.ConstantRepository.AddConstantValue(constantValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <param name="constant"></param>
        /// <param name="moment"></param>
        /// <typeparam name="T"></typeparam>
        private void UpdateConstantValue<T>(long? id, T value, ConstantInfo constant, DateTime? moment = null)
        {
            var constantValue = Constant.ConstantRepository.GetConstantValue(id.GetValueOrDefault());
            if (constantValue is null)
                return;

            if (constantValue.Moment.Date == moment.GetValueOrDefault().Date &&
                constantValue.Value == value.ToString())
                return;

            constantValue.Value = value.ToString();
            constantValue.Moment = moment ?? DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueId"></param>
        public void DeleteConstantValue(long valueId)
        {
            var constantValue = Constant.ConstantRepository.GetConstantValue(valueId);
            if (constantValue is null)
                return;

            Constant.ConstantRepository.RemoveConstantValue(constantValue);
        }
    }
}