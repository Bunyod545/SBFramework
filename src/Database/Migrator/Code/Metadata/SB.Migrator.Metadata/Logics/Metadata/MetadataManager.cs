using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SB.Common.Extensions;
using SB.Migrator.Metadata.Logics.Metadata.Models;

namespace SB.Migrator.Metadata
{
    /// <summary>
    /// 
    /// </summary>
    public class MetadataManager
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly List<TableMetadata> _tables;

        /// <summary>
        /// 
        /// </summary>
        public MigrateManager MigrateManager { get; }

        /// <summary>
        /// 
        /// </summary>
        public IMigrationsHistoryRepository HistoryRepository => MigrateManager?.MigrationsHistoryRepository;

        /// <summary>
        /// 
        /// </summary>
        public List<AssemblyMetadata> Assemblies { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrateManager"></param>
        public MetadataManager(MigrateManager migrateManager) : this()
        {
            MigrateManager = migrateManager;
            MigrateManager.MigrateBegin += manager => InitializeAssemblies();
        }

        /// <summary>
        /// 
        /// </summary>
        public MetadataManager()
        {
            _tables = new List<TableMetadata>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void InitializeAssemblies()
        {
            Assemblies = new List<AssemblyMetadata>();
            MetadataTablesHelper.Assemblies.ForEach(InitializeAssembly);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        private void InitializeAssembly(AssemblyMetadata assembly)
        {
            var history = HistoryRepository.GetMigrationHistory(assembly.MigrateName);
            if (history == null)
            {
                Assemblies.Add(assembly);
                return;
            }

            if (!Version.TryParse(history.Version, out var version))
                version = new Version();

            if (!Version.TryParse(history.Version2, out var version2))
                version2 = new Version();

            var migrateVersion = Version.Parse(assembly.MigrateVersion);
            if (migrateVersion > version || migrateVersion > version2)
                Assemblies.Add(assembly);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ScriptMetadata> GetBeforeActualizationScripts()
        {
            return Assemblies.SelectMany(GetBeforeActualizationScript).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private List<ScriptMetadata> GetBeforeActualizationScript(AssemblyMetadata assembly)
        {
            var history = HistoryRepository.GetMigrationHistory(assembly.MigrateName);
            if (history == null)
                return assembly.BeforeActualizationScripts;

            if (!Version.TryParse(history.Version, out var version))
                version = new Version();

            return assembly.BeforeActualizationScripts.ToList(w => w.Version > version);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ScriptMetadata> GetAfterActualizationScripts()
        {
            return Assemblies.SelectMany(GetAfterActualizationScript).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private List<ScriptMetadata> GetAfterActualizationScript(AssemblyMetadata assembly)
        {
            var history = HistoryRepository.GetMigrationHistory(assembly.MigrateName);
            if (history == null)
                return assembly.AfterActualizationScripts;

            if (!Version.TryParse(history.Version2, out var version2))
                version2 = new Version();

            return assembly.AfterActualizationScripts.ToList(w => w.Version > version2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TableMetadata> GetTables()
        {
            var types = Assemblies.SelectMany(s => s.Assembly.GetTypes());
            var tableTypes = types.ToList(w => w.IsHasAttribute<TableAttribute>());

            foreach (var tableType in tableTypes)
            {
                var metadata = GetTableMetadata(tableType);
                _tables.Add(metadata);
            }

            return _tables;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableType"></param>
        /// <returns></returns>
        public virtual TableMetadata GetTableMetadata(Type tableType)
        {
            var tableMetadata = _tables.FirstOrDefault(f => f.TableType == tableType);
            if (tableMetadata != null)
                return tableMetadata;

            if (tableType.IsEnum)
                return MetadataEnumTablesHelper.GetTableMetadata(tableType);

            return GetTable(tableType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableType"></param>
        /// <returns></returns>
        protected virtual TableMetadata GetTable(Type tableType)
        {
            var tableAttr = tableType.GetCustomAttribute<TableAttribute>();

            var tableMetadata = new TableMetadata();
            tableMetadata.TableType = tableType;
            tableMetadata.Name = tableAttr?.Name ?? tableType.Name;
            tableMetadata.Schema = tableAttr?.Schema;
            tableMetadata.Columns = GetColumns(tableMetadata);
            tableMetadata.PrimaryKey = GetPrimaryKey(tableMetadata);
            tableMetadata.ForeignKeys = GetForeignKeys(tableMetadata);

            return tableMetadata;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableMetadata"></param>
        /// <returns></returns>
        protected virtual List<ColumnMetadata> GetColumns(TableMetadata tableMetadata)
        {
            var props = tableMetadata.TableType.GetProperties();
            return props.Select(p => GetColumn(p, tableMetadata)).ToList(w => w != null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="tableMetadata"></param>
        /// <returns></returns>
        protected virtual ColumnMetadata GetColumn(PropertyInfo property, TableMetadata tableMetadata)
        {
            var propAttr = property.GetCustomAttribute<ColumnAttribute>();
            if (propAttr == null)
                return null;

            var columnMetadata = new ColumnMetadata();
            columnMetadata.Table = tableMetadata;
            columnMetadata.Property = property;
            columnMetadata.Name = propAttr.Name ?? property.Name;
            columnMetadata.Type = propAttr.Type;
            columnMetadata.IsAllowNull = ColumnIsAllowNull(propAttr, columnMetadata);
            columnMetadata.DefaultValue = propAttr.DefaultValue;

            return columnMetadata;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propAttr"></param>
        /// <param name="columnMetadata"></param>
        /// <returns></returns>
        protected virtual bool ColumnIsAllowNull(ColumnAttribute propAttr, ColumnMetadata columnMetadata)
        {
            if (propAttr.IsAllowNull.HasValue && propAttr.IsAllowNull.Value)
                return true;

            var type = columnMetadata.Property.PropertyType;
            return type.IsClass || type.IsNullable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableMetadata"></param>
        /// <returns></returns>
        protected virtual PrimaryKeyMetadata GetPrimaryKey(TableMetadata tableMetadata)
        {
            var column = tableMetadata.Columns.FirstOrDefault(f => f.Property.IsHasAttribute<PrimaryKeyAttribute>());
            if (column == null)
                return null;

            var attr = column.Property.GetCustomAttribute<PrimaryKeyAttribute>();
            var primaryKey = new PrimaryKeyMetadata();
            primaryKey.PrimaryColumn = column;
            primaryKey.Name = attr.Name;

            return primaryKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableMetadata"></param>
        /// <returns></returns>
        protected virtual List<ForeignKeyMetadata> GetForeignKeys(TableMetadata tableMetadata)
        {
            var columns = tableMetadata.Columns.ToList(f => f.Property.IsHasAttribute<ForeignKeyAttribute>());
            return columns.Select(GetForeignKey).ToList(w => w != null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnMetadata"></param>
        /// <returns></returns>
        protected virtual ForeignKeyMetadata GetForeignKey(ColumnMetadata columnMetadata)
        {
            var attr = columnMetadata.Property.GetCustomAttribute<ForeignKeyAttribute>();
            if (attr == null)
                return null;

            var foreignKey = new ForeignKeyMetadata();
            foreignKey.Column = columnMetadata;
            foreignKey.Name = attr.Name;
            foreignKey.Table = columnMetadata.Table;
            foreignKey.ReferencedTable = attr.ReferencedTable ?? columnMetadata.Property.PropertyType;
            foreignKey.ReferencedColumn = attr.ReferenceColumn;

            return foreignKey;
        }
    }
}
