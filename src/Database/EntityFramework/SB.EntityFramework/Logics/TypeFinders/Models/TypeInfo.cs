using System;
using SB.EntityFramework.Context.Tables;

namespace SB.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class TypeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type ClrType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clrType"></param>
        public TypeInfo(Type clrType)
        {
            ClrType = clrType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <param name="sbType"></param>
        /// <returns></returns>
        public static bool operator ==(SbType sbType, TypeInfo typeInfo)
        {
            return typeInfo == sbType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sbType"></param>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static bool operator !=(SbType sbType, TypeInfo typeInfo)
        {
            return !(sbType == typeInfo);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <param name="sbType"></param>
        /// <returns></returns>
        public static bool operator ==(TypeInfo typeInfo, SbType sbType)
        {
            if (typeInfo == null || sbType == null)
                return false;

            return typeInfo.Schema == sbType.Prefix &&
                   typeInfo.Name == sbType.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <param name="sbType"></param>
        /// <returns></returns>
        public static bool operator !=(TypeInfo typeInfo, SbType sbType)
        {
            return !(typeInfo == sbType);
        }
    }
}
