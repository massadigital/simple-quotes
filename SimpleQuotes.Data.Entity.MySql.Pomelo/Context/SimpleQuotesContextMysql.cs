using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleQuotes.Data.Entity.Abstraction.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleQuotes.Data.Entity.MySql.Pomelo.Context
{
    public class SimpleQuotesContextMysql : SimpleQuotesContext
    {
        public SimpleQuotesContextMysql(IConfiguration configuration) : base(configuration)
        {

        }
        protected override void Configure(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString);
        }

        protected override void ModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
