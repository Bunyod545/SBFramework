using SB.Migrator.Models.Tables.Keys;

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
        /// <param name="uniqueKey"></param>
        protected virtual void CreateUniqueKey(UniqueKeyInfo uniqueKey)
        {
            UniqueKeyCommand<ICreateUniqueKeyCommand>(uniqueKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uniqueKey"></param>
        protected virtual void DropForeignKey(UniqueKeyInfo uniqueKey)
        {
            UniqueKeyCommand<IDropUniqueKeyCommand>(uniqueKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="foreignKey"></param>
        protected virtual T UniqueKeyCommand<T>(UniqueKeyInfo foreignKey) where T : class, IUniqueKeyCommand
        {
            var service = CommandServices.GetCommand<T>();
            if (service == null)
                return null;

            service.SetUniqueKey(foreignKey);
            Commands.Add(service);
            return service;
        }
    }
}
