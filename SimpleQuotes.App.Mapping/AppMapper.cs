using AutoMapper;
using SimpleQuotes.App.Contract.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuotes.App.Mapping
{
    public class AppMapper : IAppMapper
    {
        protected IMapper Mapper { get; }

        public AppMapper(IMapper mapper)
        {
            Mapper = mapper;
        }

        public async Task<TDestination> Map<TSource, TDestination>(TSource from)
        {
            await Task.Yield();

            return Mapper.Map<TDestination>(from);
        }

        public async Task<TDestination> Map<TDestination>(object from)
        {
            await Task.Yield();

            return Mapper.Map<TDestination>(from);
        }
    }
}
