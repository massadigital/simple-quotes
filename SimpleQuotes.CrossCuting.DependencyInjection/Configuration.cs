using Microsoft.Extensions.DependencyInjection;
using SimpleQuotes.App.Contract.Handler;
using SimpleQuotes.App.Contract.Mapping;
using SimpleQuotes.App.Handler;
using SimpleQuotes.App.Mapping;
using SimpleQuotes.Data.Contract.Repository;
using SimpleQuotes.Data.Entity.Abstraction.Context;
using SimpleQuotes.Data.Entity.MySql.Pomelo.Context;
using SimpleQuotes.Data.Repository;
using SimpleQuotes.Domain.Contract.Service;
using SimpleQuotes.Domain.Service;
using System;

namespace SimpleQuotes.CrossCuting.DependencyInjection
{
    public class Configuration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            ConfigureApp(services);
            ConfigureDomain(services);
            ConfigureData(services);
            ConfigureDataEntity(services);
        }

        protected static void ConfigureApp(IServiceCollection services)
        {
            App.Mapping.DependencyInjection.ConfigureMapper(services);

            services.AddSingleton<IAppMapper, AppMapper>();

            services.AddScoped<ILeadHandler, LeadHandler>();
        }

        protected static void ConfigureDomain(IServiceCollection services)
        {
            services.AddScoped<ILeadService, LeadService>();
        }

        protected static void ConfigureData(IServiceCollection services)
        {
            services.AddScoped<ILeadRepository, LeadRepository>();
        }

        protected static void ConfigureDataEntity(IServiceCollection services)
        {
            services.AddScoped<SimpleQuotesContext, SimpleQuotesContextMysql>();
        }
    }
}
