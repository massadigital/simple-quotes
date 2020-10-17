using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuotes.App.Contract.Mapping
{
    public interface IAppMapper
    {
        Task<TDestination> Map<TSource, TDestination>(TSource from);
        Task<TDestination> Map<TDestination>(object from);
    }
}
