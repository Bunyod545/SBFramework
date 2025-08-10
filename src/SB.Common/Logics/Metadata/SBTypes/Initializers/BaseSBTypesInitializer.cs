using System.Collections.Generic;
using System.Linq;

namespace SB.Common.Logics.Metadata.SBTypes.Initializers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseSBTypesInitializer : ISBTypesInitializer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual List<SBTypeInfo> GetTypeInfos()
        {
            var dbTypes = GetDbTypeInfos();
            var finder = GetTypesFinder();
            var codeTypes = finder.Find();
            var newTypes = Merge(codeTypes, dbTypes);

            SubmitNewTypes(newTypes);
            return codeTypes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeTypes"></param>
        /// <param name="dbTypes"></param>
        /// <returns></returns>
        protected virtual List<SBTypeInfo> Merge(List<SBTypeInfo> codeTypes, List<SBTypeInfo> dbTypes)
        {
            return codeTypes.Where(w => CheckAndFill(w, dbTypes)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeType"></param>
        /// <param name="dbTypes"></param>
        /// <returns></returns>
        private bool CheckAndFill(SBTypeInfo codeType, List<SBTypeInfo> dbTypes)
        {
            var dbType = dbTypes.FirstOrDefault(f => f.Name == codeType.Name);
            if (dbType == null)
                return true;

            codeType.TypeId = dbType.TypeId;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract List<SBTypeInfo> GetDbTypeInfos();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newTypes"></param>
        /// <returns></returns>
        protected abstract void SubmitNewTypes(List<SBTypeInfo> newTypes);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual ISBTypesFinder GetTypesFinder()
        {
            return new DefaultSBTypesFinder();
        }
    }
}
