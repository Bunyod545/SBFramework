using SB.Common.Logics.Business;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SB.Common.Logics.Constants.Logics.ConstantRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public class MemoryConstantRepository : IConstantRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public static long MaxId = 1;

        /// <summary>
        /// 
        /// </summary>
        private static List<ConstantValueInfo> _constantValues = new List<ConstantValueInfo>();

        /// <summary>
        /// 
        /// </summary>
        private static List<ConstantInfo> _constantInfos = new List<ConstantInfo>();

        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<Type, List<IIdentified>> Entities = new Dictionary<Type, List<IIdentified>>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constant"></param>
        public void AddConstant(ConstantInfo constant)
        {
            _constantInfos.Add(constant);
            constant.Id = MaxId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public ConstantValueInfo AddConstantValue(ConstantValueInfo info)
        {
            info.Id = MaxId++;
            _constantValues.Add(info);
            return info;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ConstantInfo GetConstant(string name)
        {
            return _constantInfos.FirstOrDefault(x => x.Name == name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constantId"></param>
        /// <returns></returns>
        public ConstantValueInfo GetConstantValue(long constantId)
        {
            return _constantValues.FirstOrDefault(x => x.Id == constantId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constantName"></param>
        /// <returns></returns>
        public ConstantValueInfo GetConstantValue(string constantName)
        {
            var values = _constantValues.Where(w => w.Constant.Name == constantName).ToList();
            return values.OrderByDescending(d => d.Moment).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constantValue"></param>
        public void RemoveConstantValue(ConstantValueInfo constantValue)
        {
            var constant = _constantValues.FirstOrDefault(x => x.Id == constantValue.Id);
            if (constant != null)
                _constantValues.Remove(constant);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SubmitChanges()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="valueType"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetEntity<T>(Type valueType, long id)
        {
            if (!Entities.ContainsKey(valueType))
                return default;

            var entities = Entities[valueType];
            var value = entities.FirstOrDefault(x => x.Id == id);

            return value != null ? (T)value : default;
        }
    }
}
