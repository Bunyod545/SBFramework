﻿using System.ComponentModel.DataAnnotations.Schema;
using SB.EntityFramework.Context;
using SB.EntityFramework.Context.Tables;
using SB.Common.Logics.Business;

namespace SB.EntityFramework.Test.Logics.SbTypes
{
    /// <summary>
    /// 
    /// </summary>
    [Table(TableName, Schema = EFContext.DefaultSchema)]
    public class Employee : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public const string TableName = "Employees";

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