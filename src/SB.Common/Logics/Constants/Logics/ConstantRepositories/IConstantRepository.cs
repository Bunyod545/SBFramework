using SB.Common.Logics.Business;
using System;

namespace SB.Common
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConstantRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ConstantInfo GetConstant(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="constantId"></param>
        /// <returns></returns>
        ConstantValueInfo GetConstantValue(long constantId);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="constantId"></param>
        /// <returns></returns>
        ConstantValueInfo GetConstantValue(string constantName);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="constantId"></param>
        /// <returns></returns>
        ConstantValueInfo AddConstantValue(ConstantValueInfo info);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constantValue"></param>
        void RemoveConstantValue(ConstantValueInfo constantValue);
        
        /// <summary>
        ///     
        /// </summary>
        /// <param name="constant"></param>
        void AddConstant(ConstantInfo constant);

        /// <summary>
        /// 
        /// </summary>
        void SubmitChanges();

        /// <summary>
        /// 
        /// </summary>
        void Dispose();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="valueType"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetEntity<T>(Type valueType, long id);
    }
}
