using SB.Migrator.Models.Tables.Constraints;

namespace SB.Migrator.Logics.DatabaseCommands
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DatabaseCommandManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="primaryKey"></param>
        protected virtual void CreatePrimaryKey(PrimaryKeyInfo primaryKey)
        {
            PrimaryKeyCommand<ICreatePrimaryKeyCommand>(primaryKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="primaryKey"></param>
        protected virtual void DropPrimaryKey(PrimaryKeyInfo primaryKey)
        {
            PrimaryKeyCommand<IDropPrimaryKeyCommand>(primaryKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryKey"></param>
        protected virtual T PrimaryKeyCommand<T>(PrimaryKeyInfo primaryKey) where T : class, IPrimaryKeyCommand
        {
            var service = CommandServices.GetCommand<T>();
            if (service == null)
                return null;

            service.SetPrimaryKey(primaryKey);
            Commands.Add(service);
            return service;
        }
    }
}
