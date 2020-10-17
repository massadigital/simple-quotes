using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuotes.App.Contract.Handler
{
    public interface IBaseHandler<TModel, TKey>
    {
        Task<TKey> Create(TModel model);
        Task<TModel> Read(TKey key);
        Task Update(TKey key, TModel model);
        Task Destroy(TKey key);
        Task<IEnumerable<TModel>> List(int page, int pageSize, string sort, string filter);
    }
}
