using System.Data.Entity.ModelConfiguration;
using WebAPI.Core.Model.Agregates;

namespace WebAPI.Data.DataContext.EntityConfig
{
    public class EstablishmentConfig : EntityTypeConfiguration<Establishment>
    {
        public EstablishmentConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.AlternateName).IsRequired().HasMaxLength(100);
            Property(p => p.CurrenciesAccepted).IsOptional().HasMaxLength(5);
            Property(p => p.ContactName).HasMaxLength(30);
            Property(p => p.Email).IsRequired().HasMaxLength(100);
            Property(p => p.LegalName).IsRequired().HasMaxLength(100);
            Property(p => p.OpeningHours).HasMaxLength(50);
            Property(p => p.PriceRange).IsRequired();
            Property(p => p.PriceRange).IsOptional().HasMaxLength(4);
            Property(p => p.Telephone).IsRequired().HasMaxLength(15);

            HasOptional(x => x.PostalAddress)
                .WithOptionalPrincipal(x => x.Establishment)
                .Map(x => x.MapKey("EstablishmentId"))
                .WillCascadeOnDelete(false);

            HasMany(x => x.Subsidiaries)
                .WithRequired(x => x.Establishment)
                .HasForeignKey(x => x.EstablishmentId)
                .WillCascadeOnDelete(false);
        }
    }
}
