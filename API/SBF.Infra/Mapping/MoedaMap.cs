using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBF.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBF.Infra.Mapping
{
    public class MoedaMap : IEntityTypeConfiguration<Moeda>
    {
        public void Configure(EntityTypeBuilder<Moeda> builder)
        {
            builder.ToTable("Moeda");
            builder.Property(x => x.Sigla).IsRequired();
        }
    }
}
