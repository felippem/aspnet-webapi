using MySql.Data.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebAPI.Data.DataContext.EntityConfig;

namespace WebAPI.Data.DataContext
{
    public class Context : DbContext
    {
        public Context() : base("ConnectionString")
        {
            base.Configuration.ValidateOnSaveEnabled = false;
            base.Configuration.LazyLoadingEnabled = true;
        }

        static Context()
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new EstablishmentConfig());
            modelBuilder.Configurations.Add(new PostalAddressConfig());
            modelBuilder.Configurations.Add(new SubsidiaryConfig());

            modelBuilder.Properties()
               .Where(p => p.Name == p.ReflectedType.Name + "Id")
               .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
               .Configure(p => p.HasColumnType("varchar").HasMaxLength(80));

            base.OnModelCreating(modelBuilder);
        }

        public bool TestConnection()
        {
            try
            {
                if (!this.Database.Exists())
                {
                    Console.WriteLine("A conexão com o banco de dados falhou.");
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
