using AutoMapper;
using SimpleQuotes.App.Model;
using DomainModel = SimpleQuotes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleQuotes.App.Model.Entity;

namespace SimpleQuotes.App.Mapping.Configuration
{
    public class QuoteProfile : Profile
    {
        public QuoteProfile()
        {
            CreateMap<DomainModel.Entity.Quote, Quote>()
                .ForMember(destination => destination.Id, options => options.MapFrom(source => source.QuoteId))
                .ForMember(destination => destination.Until, options => options.MapFrom(source => source.QuoteUntil))
                .ForMember(destination => destination.From, options => options.MapFrom(source => source.QuoteFrom))
                .ForMember(destination => destination.Quantity, options => options.MapFrom(source => source.QuoteQuantity))
                .ForMember(destination => destination.Remmarks, options => options.MapFrom(source => source.QuoteRemmarks))
                .ForMember(destination => destination.ProductId, options => options.MapFrom(source => source.QuoteProductId))
                .ForMember(destination => destination.Product, options => options.MapFrom(source => source.QuoteProduct))
                .ForMember(destination => destination.Lead, options => options.MapFrom(source => source.QuoteLead))
                .ReverseMap();
        }
    }
}
