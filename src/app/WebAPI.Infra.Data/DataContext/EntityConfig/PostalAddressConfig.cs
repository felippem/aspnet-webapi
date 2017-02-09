using System.Data.Entity.ModelConfiguration;
using WebAPI.Domain.Entities;

namespace WebAPI.Infra.Data.DataContext.EntityConfig
{
    public class PostalAddressConfig : EntityTypeConfiguration<PostalAddress>
    {
        public PostalAddressConfig()
        {
            HasKey(p => p.PostalAddressId);

            Property(p => p.StreetAddress).IsRequired().HasMaxLength(100);
            Property(p => p.Number).IsRequired();
            Property(p => p.Complement).IsOptional().HasMaxLength(100);
            Property(p => p.Country).IsRequired().HasMaxLength(50);
            Property(p => p.GeoCoordinates).IsOptional();
            Property(p => p.Locality).IsRequired().HasMaxLength(50);
            Property(p => p.PostalCode).IsOptional();
            Property(p => p.Region).IsOptional();
        }
    }
}
