using SimpleQuotes.Data.Contract.Repository;
using SimpleQuotes.Data.Entity.Abstraction.Context;
using SimpleQuotes.Domain.Model.Entity;

namespace SimpleQuotes.Data.Repository
{
    public class QuoteRepository : BaseRepository<Quote, long>, IQuoteRepository
    {
        public QuoteRepository(SimpleQuotesContext context) : base(context)
        {
        }
    }
}
