using SimpleQuotes.Domain.Model.Entity;

namespace SimpleQuotes.Data.Contract.Repository
{
    public interface IProductRepository : IBaseRepository<Product, long>
    {
    }
}
