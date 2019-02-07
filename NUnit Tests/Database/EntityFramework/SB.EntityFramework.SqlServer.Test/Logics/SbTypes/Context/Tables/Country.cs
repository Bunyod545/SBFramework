﻿using System.ComponentModel.DataAnnotations.Schema;
using SB.EntityFramework.Context;
using SB.EntityFramework.Context.Tables;
using SBCommon.Logics.Business;

namespace SB.EntityFramework.SqlServer.Test.Logics.SbTypes
{
    /// <summary>
    /// 
    /// </summary>
    [Table(TableName, Schema = EFContext.DefaultSchema)]
    public class Country : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public const string TableName = "Countrys";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SbType GetSbType()
        {
            return new SbType()
            {
                Name = TableName,
                Prefix = EFContext.DefaultSchema
            };
        }
    }
}