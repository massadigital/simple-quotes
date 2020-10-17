using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleQuotes.Data.Entity.Abstraction.Configuration;
using SimpleQuotes.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleQuotes.Data.Entity.Abstraction.Context
{
    public abstract partial class SimpleQuotesContext : DbContext
    {
        public virtual DbSet<Lead> Lead { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Quote> Quote { get; set; }
        public virtual DbSet<Quoted> Quoted { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LeadConfiguration());

            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfiguration(new QuoteConfiguration());

            modelBuilder.ApplyConfiguration(new QuotedConfiguration());

            ModelCreating(modelBuilder);
        }
        protected abstract void ModelCreating(ModelBuilder modelBuilder);
    }
}
