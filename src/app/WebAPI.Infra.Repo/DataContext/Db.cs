﻿using MySql.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using WebAPI.Domain.Entities;
using WebAPI.Infra.Repo.DataContext.EntityConfig;

namespace WebAPI.Infra.Repo.DataContext
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Db : DbContext
    {
        public Db(string connectionString)
        {
        }

        public Db() : base("ConnectionString")
        {
        }

        #region Behaviors

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
               .Configure(p => p.HasColumnType("varchar").HasMaxLength(80));

            this.SetConfigEntities(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                IEnumerable<string> errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                string fullErrorMessage = string.Join("; ", errorMessages);

                throw new DbEntityValidationException(string.Format("{0} Validation errors: {1}", ex.Message, fullErrorMessage),
                    ex.EntityValidationErrors);
            }
        }

        #endregion

        #region Methods

        protected void SetConfigEntities(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EstablishmentConfig());
            modelBuilder.Configurations.Add(new PostalAddressConfig());

            modelBuilder
                .Entity<Establishment>()
                .HasOptional(p => p.PostalAddress)
                .WithOptionalDependent(p => p.Establishment)
                .Map(m =>
                {
                    m.MapKey("PostalAddressId");
                });
        }

        #endregion
    }
}
