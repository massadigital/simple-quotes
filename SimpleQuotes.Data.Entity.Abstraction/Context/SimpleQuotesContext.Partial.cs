using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;
using SimpleQuotes.Data.Entity.Abstraction.Configuration;
using SimpleQuotes.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleQuotes.Data.Entity.Abstraction.Context
{
    public abstract partial class SimpleQuotesContext : DbContext
    {
        protected string ConnectionString { get; }

        public SimpleQuotesContext()
        {
        }

        public SimpleQuotesContext(IConfiguration configuration)
            : base()
        {
            ConnectionString = configuration.GetConnectionString("SimpleQuotes");
        }

        protected SimpleQuotesContext(DbContextOptions<SimpleQuotesContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                Configure(optionsBuilder);
            }
        }

        public TKey GetKey<TModel, TKey>(TModel model)
        {
            var result = Model.FindEntityType(typeof(TModel)).FindPrimaryKey().Properties.First().PropertyInfo.GetValue(model);

            return (TKey)result;
        }

        public string GetKeyName<TModel>()
        {
            var result = Model.FindEntityType(typeof(TModel)).FindPrimaryKey().Properties.First().PropertyInfo.Name;

            return result;
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            int result;

            try
            {
                result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }

            return result;
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await SaveChangesAsync(true, cancellationToken);
        }

        protected abstract void Configure(DbContextOptionsBuilder optionsBuilder);
    }
}
