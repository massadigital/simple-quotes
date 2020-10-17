using SimpleQuotes.Domain.Model.Entity;

namespace SimpleQuotes.Data.Contract.Repository
{
    public interface IQuoteRepository : IBaseRepository<Quote, long>
    {
    }
}
