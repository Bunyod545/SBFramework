﻿using SB.Common.Logics.Metadata;

namespace SB.Common.Logics.Business
{
    /// <summary>
    /// 
    /// </summary>
    [SBType(typeof(SBEntityType))]
    public abstract class Entity : SBObject, IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Name { get; set; }
    }
}
