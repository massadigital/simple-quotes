using AutoMapper;
using SimpleQuotes.App.Model;
using DomainModel = SimpleQuotes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleQuotes.App.Model.Entity;

namespace SimpleQuotes.App.Mapping.Configuration
{
    public class LeadProfile : Profile
    {
        public LeadProfile()
        {
            CreateMap<DomainModel.Entity.Lead, Lead>()
                .ForMember(destination => destination.Id, options => options.MapFrom(source => source.LeadId))
                .ForMember(destination => destination.Name, options => options.MapFrom(source => source.LeadName))
                .ForMember(destination => destination.Email, options => options.MapFrom(source => source.LeadEmail))
                .ReverseMap();
        }
    }
}
