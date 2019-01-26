using System;
using System.Collections.Generic;
using System.Text;

namespace SBCommon.Logics.Business.Entitys
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Entity : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual long TypeId { get; }
    }
}
