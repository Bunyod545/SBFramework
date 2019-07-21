using System;
using System.Collections.Generic;

namespace SB.Migrator.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITableFinder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Type> GetContextTypes();
    }
}