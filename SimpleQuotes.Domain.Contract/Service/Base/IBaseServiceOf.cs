using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleQuotes.Domain.Contract.Service
{
    public interface IBaseService<TModel,TKey>
    {
        Task<TKey> Create(TModel model);
        Task<TModel> Read(TKey key);
        Task Update(TKey key, TModel model);
        Task Destroy(TKey key);
        Task<IQueryable<TModel>> Query(int page, int pageSize, string sort, string filter);
        Task<IEnumerable<TModel>> List(int page, int pageSize, string sort, string filter);
    }
}
