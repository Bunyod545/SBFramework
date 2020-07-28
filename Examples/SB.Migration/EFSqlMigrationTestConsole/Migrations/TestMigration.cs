using SB.Migrator.EntityFramework.Logics;

namespace EFSqlMigrationTestConsole.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    public class TestMigration : EfDbCodeMigration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void BeforeActualization()
        {
            var table = CreateTable("Test");
            table.Column<int>("Id").PrimaryKey();
            table.Column<string>("Name").IsNullable();
        }
    }
}
