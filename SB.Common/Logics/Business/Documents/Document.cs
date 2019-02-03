﻿using System;

namespace SBCommon.Logics.Business.Documents
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Document : SBObject, IDocument
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected DateTime PeriodicDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual void BeforeSubmit()
        {

        }
    }
}
