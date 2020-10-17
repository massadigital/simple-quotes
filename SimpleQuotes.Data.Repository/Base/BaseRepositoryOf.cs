using Microsoft.EntityFrameworkCore;
using SimpleQuotes.Data.Contract.Repository;
using SimpleQuotes.Data.Entity.Abstraction.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuotes.Data.Repository
{
    public abstract class BaseRepository<TModel, TKey> : IBaseRepository<TModel, TKey> where TModel : class, new()
    {
        protected SimpleQuotesContext Context { get; }

        private readonly ParameterExpression ParamExpression = Expression.Parameter(typeof(TModel), $"model{typeof(TModel).Name}");

        public BaseRepository(SimpleQuotesContext context)
        {
            Context = context;
        }

        protected void DefaultSort(ref IQueryable<TModel> models)
        {
            var SortExpression = Expression.Lambda<Func<TModel, object>>(
                Expression.Convert(Expression.Property(ParamExpression, Context.GetKeyName<TModel>()), typeof(object)),
                ParamExpression
            );

            models = models.OrderBy(SortExpression);
        }

        public async Task<TModel> Create()
        {
            await Task.Yield();

            var result = new TModel();

            Context.Add(result);

            return result;
        }

        public async Task<TKey> Insert(TModel model)
        {
            Context.Add(model);

            await Context.SaveChangesAsync();

            var result = Context.GetKey<TModel, TKey>(model);

            return result;
        }

        public async Task Destroy(TModel model)
        {
            Context.Remove(model);

            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> List(int page, int pageSize, string sort, string filter)
        {
            var query = await Query(page, pageSize, sort, filter);

            return await query.ToListAsync();
        }

        public async Task<IQueryable<TModel>> Query(int page, int pageSize, string sort, string filter)
        {
            await Task.Yield();

            var query = Context.Set<TModel>().AsQueryable();

            DefaultSort(ref query);

            query = query.Skip(pageSize * (page - 1)).Take(pageSize);

            return query;
        }

        public async Task<TModel> Read(TKey key)
        {
            var result = await Context.FindAsync<TModel>(key);

            return result;
        }

        public async Task Update(TModel model)
        {
            Context.Update(model);

            await Context.SaveChangesAsync();
        }
    }
}
