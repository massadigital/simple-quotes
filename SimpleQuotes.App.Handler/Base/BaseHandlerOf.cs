using SimpleQuotes.App.Contract.Handler;
using SimpleQuotes.App.Contract.Mapping;
using SimpleQuotes.Domain.Contract.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuotes.App.Handler
{
    public class BaseHandler<TModel, TTargetModel, TKey> : IBaseHandler<TModel, TKey>
    {
        protected IBaseService<TTargetModel, TKey> Service { get; }
        protected IAppMapper AppMapper { get; }

        public BaseHandler(IAppMapper appMapper, IBaseService<TTargetModel, TKey> service)
        {
            AppMapper = appMapper;

            Service = service;
        }

        public async Task<TKey> Create(TModel model)
        {
            var targetModel = await AppMapper.Map<TTargetModel>(model);

            var result = await Service.Create(targetModel);

            return result;
        }

        public async Task<TModel> Read(TKey key)
        {
            var targetResult = await Service.Read(key);

            var result = await AppMapper.Map<TModel>(targetResult);

            return result;
        }

        public async Task Update(TKey key, TModel model)
        {
            var targetModel = await AppMapper.Map<TTargetModel>(model);

            await Service.Update(key, targetModel);
        }

        public async Task Destroy(TKey key)
        {
            await Service.Destroy(key);
        }

        public async Task<IEnumerable<TModel>> List(int page, int pageSize, string sort, string filter)
        {
            var targetResult = await Service.List(page, pageSize, sort, filter);

            var result = await AppMapper.Map<IEnumerable<TModel>>(targetResult);

            return result;
        }
    }
}
