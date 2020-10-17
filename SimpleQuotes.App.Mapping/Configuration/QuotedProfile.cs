using AutoMapper;
using SimpleQuotes.App.Model;
using DomainModel = SimpleQuotes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleQuotes.App.Model.Entity;

namespace SimpleQuotes.App.Mapping.Configuration
{
    public class QuotedProfile : Profile
    {
        public QuotedProfile()
        {
            CreateMap<DomainModel.Entity.Quoted, Quoted>()
                .ForMember(destination => destination.Id, options => options.MapFrom(source => source.QuotedId))
                .ForMember(destination => destination.Until, options => options.MapFrom(source => source.QuotedUntil))
                .ForMember(destination => destination.From, options => options.MapFrom(source => source.QuotedFrom))
                .ForMember(destination => destination.UnitPrice, options => options.MapFrom(source => source.QuotedUnitPrice))
                .ForMember(destination => destination.Remmarks, options => options.MapFrom(source => source.QuotedRemmarks))
                .ForMember(destination => destination.QuoteId, options => options.MapFrom(source => source.QuotedQuoteId))
                .ForMember(destination => destination.Quote, options => options.MapFrom(source => source.QuotedQuote))
                .ReverseMap();
        }
    }
}
