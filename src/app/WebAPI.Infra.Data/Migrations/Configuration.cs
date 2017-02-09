using MySql.Data.Entity;
using System.Data.Entity.Migrations;
using WebAPI.Infra.Data.DataContext;

namespace WebAPI.Infra.Data.Migrations
{
    public class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;

            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
        }
    }
}
