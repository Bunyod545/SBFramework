using Microsoft.EntityFrameworkCore;
using SB.Common.Logics.Application;
using SB.Common.Logics.Business;

namespace SB.EntityFramework.Context
{
    /// <summary>
    /// 
    /// </summary>
    public class EFContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public static ISBDatabase SbDatabase { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public const string DefaultSchema = "dbo";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <returns></returns>
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            BeforeSubmit();
            var result = base.SaveChanges(acceptAllChangesOnSuccess);
            AfterSubmit();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void BeforeSubmit()
        {
            this.ModifiedObjects().ForEach(InnerBeforeSubmit);
            this.AddedObjects().ForEach(InnerBeforeSubmit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void InnerBeforeSubmit(object obj)
        {
            if (obj is IBeforeSubmitable submitable)
                submitable.BeforeSubmit();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void AfterSubmit()
        {
            this.ModifiedObjects().ForEach(InnerAfterSubmit);
            this.AddedObjects().ForEach(InnerAfterSubmit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void InnerAfterSubmit(object obj)
        {
            if (obj is IAfterSubmitable submitable)
                submitable.AfterSubmit();
        }
    }
}
