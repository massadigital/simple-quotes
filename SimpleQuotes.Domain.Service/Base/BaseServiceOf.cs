using SimpleQuotes.Data.Contract.Repository;
using SimpleQuotes.Domain.Contract.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuotes.Domain.Service
{
    public abstract class BaseService<TModel, TKey> : IBaseService<TModel, TKey>
    {
        protected IBaseRepository<TModel, TKey> Repository { get; }

        public BaseService(IBaseRepository<TModel, TKey> repository)
        {
            Repository = repository;
        }

        public async Task<TKey> Create(TModel model)
        {
            var current = await Repository.Create();

            await Trim(model);

            await Merge(current, model);

            var validationErrors = await Validate(current);

            if (validationErrors.Any())
            {
                throw new AggregateException(validationErrors);
            }

            var result = await Repository.Insert(model);

            return result;
        }

        public async Task Destroy(TKey key)
        {
            var model = await Repository.Read(key);

            await Repository.Destroy(model);
        }

        public async Task<IEnumerable<TModel>> List(int page, int pageSize, string sort, string filter)
        {
            var result = await Repository.List(page, pageSize, sort, filter);

            return result;
        }

        public async Task<IQueryable<TModel>> Query(int page, int pageSize, string sort, string filter)
        {
            var result = await Repository.Query(page, pageSize, sort, filter);

            return result;
        }

        public async Task<TModel> Read(TKey key)
        {
            var result = await Repository.Read(key);

            return result;
        }

        public async Task Update(TKey key, TModel model)
        {
            var current = await Repository.Read(key);

            await Trim(model);

            await Merge(current, model);

            var validationErrors = await Validate(current);

            if (validationErrors.Any())
            {
                throw new AggregateException(validationErrors);
            }

            await Repository.Update(current);
        }

        protected abstract Task Trim(TModel model);

        protected abstract Task Merge(TModel to, TModel from);

        protected abstract Task<IEnumerable<ApplicationException>> Validate(TModel model);
    }
}
