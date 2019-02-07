using System.Collections.Generic;
using System.Linq;
using SB.EntityFramework.Context.Tables;
using SB.EntityFramework.SqlServer.Context;
using SBCommon.Logics.Metadata;

namespace SB.EntityFramework.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlSBTypesInitializers : ISBTypesInitializer
    {
        /// <summary>
        /// 
        /// </summary>
        public List<TypeInfo> TypeInfos { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<SbType> SbTypes { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public SqlServerContext Context { get; }

        /// <summary>
        /// 
        /// </summary>
        public SqlSBTypesInitializers()
        {
            Context = new SqlServerContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public SqlSBTypesInitializers(SqlServerContext context)
        {
            Context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SBTypeInfo> GetTypeInfos()
        {
            SbTypes = Context.SbTypes.ToList();
            TypeInfos = TableFinder.GetTypeInfos();
            MigrateTypes();

            return TypeInfos.Select(GetTypeInfo).Where(w => w != null).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public SBTypeInfo GetTypeInfo(TypeInfo typeInfo)
        {
            var sbType = SbTypes.FirstOrDefault(typeInfo.IsEqual);
            return sbType == null ? null : new SBTypeInfo(sbType.Id, typeInfo.ClrType);
        }

        /// <summary>
        /// 
        /// </summary>
        public void MigrateTypes()
        {
            TypeInfos.ForEach(MigrateType);
            Context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeInfo"></param>
        public void MigrateType(TypeInfo typeInfo)
        {
            var sbType = SbTypes.FirstOrDefault(typeInfo.IsEqual);
            if (sbType != null)
                return;

            sbType = new SbType();
            sbType.Name = typeInfo.Name;
            sbType.Prefix = typeInfo.Schema;

            Context.Add(sbType);
            SbTypes.Add(sbType);
        }
    }
}
