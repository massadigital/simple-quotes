using SimpleQuotes.Data.Contract.Repository;
using SimpleQuotes.Data.Entity.Abstraction.Context;
using SimpleQuotes.Domain.Model.Entity;

namespace SimpleQuotes.Data.Repository
{
    public class QuotedRepository : BaseRepository<Quoted, long>, IQuotedRepository
    {
        public QuotedRepository(SimpleQuotesContext context) : base(context)
        {
        }
    }
}
