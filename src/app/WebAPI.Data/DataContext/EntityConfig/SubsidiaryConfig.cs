using System.Data.Entity.ModelConfiguration;
using WebAPI.Core.Model.Agregates;

namespace WebAPI.Data.DataContext.EntityConfig
{
    public class SubsidiaryConfig : EntityTypeConfiguration<Subsidiary>
    {
        public SubsidiaryConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.CurrenciesAccepted).IsOptional().HasMaxLength(5);
            Property(p => p.ContactName).HasMaxLength(30);
            Property(p => p.Email).IsRequired().HasMaxLength(100);
            Property(p => p.OpeningHours).HasMaxLength(50);
            Property(p => p.PriceRange).IsRequired();
            Property(p => p.PriceRange).IsOptional().HasMaxLength(4);
            Property(p => p.Telephone).IsRequired().HasMaxLength(15);

            HasRequired(t => t.Establishment)
                .WithMany(c => c.Subsidiaries)
                .HasForeignKey(x => x.EstablishmentId)
                .WillCascadeOnDelete(false);

            HasOptional(x => x.PostalAddress)
                .WithOptionalPrincipal(x => x.Subsidiary)
                .Map(x => x.MapKey("SubsidiaryId"))
                .WillCascadeOnDelete(false);
        }
    }
}
