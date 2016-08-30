﻿using System.Data.Entity.ModelConfiguration;
using WebAPI.Domain.Entities;

namespace WebAPI.Infra.Repo.DataContext.EntityConfig
{
    public class SubsidiaryConfig : EntityTypeConfiguration<Subsidiary>
    {
        public SubsidiaryConfig()
        {
            HasKey(p => p.SubsidiaryId);

            Property(p => p.CurrenciesAccepted).IsOptional().HasMaxLength(5);
            Property(p => p.ContactName).HasMaxLength(30);
            Property(p => p.Email).IsRequired().HasMaxLength(100);
            Property(p => p.OpeningHours).HasMaxLength(50);
            Property(p => p.PriceRange).IsRequired();
            Property(p => p.PriceRange).IsOptional().HasMaxLength(4);
            Property(p => p.Telephone).IsRequired().HasMaxLength(15);
        }
    }
}
