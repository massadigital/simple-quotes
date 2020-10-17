using SimpleQuotes.Data.Contract.Repository;
using SimpleQuotes.Data.Entity.Abstraction.Context;
using SimpleQuotes.Domain.Model.Entity;

namespace SimpleQuotes.Data.Repository
{
    public class LeadRepository : BaseRepository<Lead, long>, ILeadRepository
    {
        public LeadRepository(SimpleQuotesContext context) : base(context) 
        { 
        }
    }
}
