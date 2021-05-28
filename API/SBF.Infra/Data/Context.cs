using Microsoft.EntityFrameworkCore;
using SBF.Domain.Entity;
using SBF.Infra.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBF.Infra.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
