using System.Collections.Generic;
using SB.Common.Test.Logics.Metadata.Tables;
using SB.Common.Logics.Metadata;
using SB.Common.Test.Logics.Constants.Models;
using SB.Common.Logics.Metadata.SBTypes.Initializers;
using SB.Common.Logics.Metadata.SBTypes;
using System.Linq;

namespace SB.Common.Test.Logics.Metadata.Initializers
{
    /// <summary>
    /// 
    /// </summary>
    public class SBTypeTestInitializer : BaseSBTypesInitializer
    {
        /// <summary>
        /// 
        /// </summary>
        private static long MaxId = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override List<SBTypeInfo> GetDbTypeInfos()
        {
            var dbTypes = new List<SBTypeInfo>();
            dbTypes.Add(new SBTypeInfo(1, SBPrimitiveTypes.String));

            MaxId = dbTypes.Max(m => m.TypeId);
            return dbTypes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newTypes"></param>
        protected override void SubmitNewTypes(List<SBTypeInfo> newTypes)
        {
            newTypes.ForEach(newType => newType.TypeId = ++MaxId);
        }
    }
}
