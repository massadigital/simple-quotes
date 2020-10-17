using SimpleQuotes.Data.Contract.Repository;
using SimpleQuotes.Data.Entity.Abstraction.Context;
using SimpleQuotes.Domain.Model.Entity;

namespace SimpleQuotes.Data.Repository
{
    public class ProductRepository : BaseRepository<Product, long>, IProductRepository
    {
        public ProductRepository(SimpleQuotesContext context) : base(context)
        {
        }
    }
}
