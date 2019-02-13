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
        /// <param name="foreignKey"></param>
        protected virtual void CreateForeignKey(ForeignKeyInfo foreignKey)
        {
            ForeignKeyCommand<ICreateForeignKeyCommand>(foreignKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="foreignKey"></param>
        protected virtual void DropForeignKey(ForeignKeyInfo foreignKey)
        {
            ForeignKeyCommand<IDropForeignKeyCommand>(foreignKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="foreignKey"></param>
        protected virtual void ForeignKeyCommand<T>(ForeignKeyInfo foreignKey) where T : class, IForeignKeyCommand
        {
            var service = CommandServices.GetCommand<T>();
            if (service == null)
                return;

            service.SetForeignKey(foreignKey);
            service.BuildCommandText();
            Commands.Add(service);
        }
    }
}
