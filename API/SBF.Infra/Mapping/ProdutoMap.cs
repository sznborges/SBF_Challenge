using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBF.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBF.Infra.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.Property(x => x.Descricao).IsRequired();
        }
    }
}
