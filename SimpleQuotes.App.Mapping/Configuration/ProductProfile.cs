using AutoMapper;
using SimpleQuotes.App.Model;
using DomainModel = SimpleQuotes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleQuotes.App.Model.Entity;

namespace SimpleQuotes.App.Mapping.Configuration
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<DomainModel.Entity.Product, Product>()
                .ForMember(destination => destination.Id, options => options.MapFrom(source => source.ProductId))
                .ForMember(destination => destination.Name, options => options.MapFrom(source => source.ProductName))
                .ForMember(destination => destination.Sku, options => options.MapFrom(source => source.ProductSku))
                .ForMember(destination => destination.Price, options => options.MapFrom(source => source.ProductPrice))
                .ReverseMap();
        }
    }
}
