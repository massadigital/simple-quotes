using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SimpleQuotes.App.Mapping.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleQuotes.App.Mapping
{
    public class DependencyInjection
    {
        public static void ConfigureMapper(IServiceCollection services)
        {
            services.AddAutoMapper(new Type[] {
                typeof(LeadProfile),
                typeof(ProductProfile),
                typeof(QuoteProfile),
                typeof(QuotedProfile),
            });
        }
    }
}
