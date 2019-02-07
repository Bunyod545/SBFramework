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
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsEqual(SbType type)
        {
            if (type == null)
                return false;

            return Schema == type.Prefix &&
                   Name == type.Name;
        }
    }
}
