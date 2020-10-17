using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuotes.Data.Contract.Repository
{
    public interface IBaseRepository<TModel,TKey>
    {
        Task<TModel> Create();
        Task<TKey> Insert(TModel model);
        Task<TModel> Read(TKey key);
        Task Update(TModel model);
        Task Destroy(TModel model);
        Task<IQueryable<TModel>> Query(int page, int pageSize, string sort, string filter);
        Task<IEnumerable<TModel>> List(int page, int pageSize, string sort, string filter);
    }
}
