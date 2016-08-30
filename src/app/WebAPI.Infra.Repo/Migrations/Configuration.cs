using MySql.Data.Entity;
using System.Data.Entity.Migrations;
using WebAPI.Infra.Repo.DataContext;

namespace WebAPI.Infra.Repo.Migrations
{
    public class Configuration : DbMigrationsConfiguration<Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;

            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
        }
    }
}
