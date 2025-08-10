using System;

namespace SB.Common.Logics.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class SBTypeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public long TypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type ClrType { get; set; }

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
        public bool IsPrimitive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SBTypeInfo()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="clrType"></param>
        public SBTypeInfo(long typeId, Type clrType)
        {
            TypeId = typeId;
            ClrType = clrType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clrType"></param>
        /// <param name="name"></param>
        public SBTypeInfo(Type clrType, string name)
        {
            ClrType = clrType;
            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="name"></param>
        public SBTypeInfo(long typeId, string name)
        {
            TypeId = typeId;
            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{TypeId} - {Name}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clrType"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SBTypeInfo CreatePrimitiveType(Type clrType, string name)
        {
            var info = new SBTypeInfo(clrType, name);
            info.IsPrimitive = true;

            return info;
        }
    }
}
