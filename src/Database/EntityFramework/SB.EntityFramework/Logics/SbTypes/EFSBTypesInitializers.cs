using System.Collections.Generic;
using System.Linq;
using SB.EntityFramework.Context.Tables;
using SBCommon.Logics.Metadata;

namespace SB.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public class EFSBTypesInitializers : ISBTypesInitializer
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
        public SBSystemContext Context { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EFSBTypesInitializers(SBSystemContext context)
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
            TypeInfos = TableFinder.InitalizeTypeInfos();
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

            sbType = new SbType
            {
                Name = typeInfo.Name,
                Prefix = typeInfo.Schema
            };

            Context.Add(sbType);
            SbTypes.Add(sbType);
        }
    }
}
