using SimpleQuotes.Data.Contract.Repository;
using SimpleQuotes.Domain.Contract.Service;
using SimpleQuotes.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleQuotes.Domain.Service
{
    public class QuotedService : BaseService<Quoted, long>, IQuotedService
    {
        protected IQuotedRepository QuotedRepository { get; }

        public QuotedService(IQuotedRepository quotedRepository) : base(quotedRepository)
        {
            QuotedRepository = quotedRepository;
        }

        protected override async Task Trim(Quoted model)
        {
            await Task.Yield();

            model.QuotedRemmarks ??= string.Empty;
        }

        protected override async Task Merge(Quoted to, Quoted from)
        {
            await Task.Yield();

            to.QuotedUntil = from.QuotedUntil;

            to.QuotedFrom = from.QuotedFrom;

            to.QuotedRemmarks = from.QuotedRemmarks;

            to.QuotedUnitPrice = from.QuotedUnitPrice;

            to.QuotedQuoteId = from.QuotedQuoteId;
        }

        protected override async Task<IEnumerable<ApplicationException>> Validate(Quoted model)
        {
            await Task.Yield();

            var result = new List<ApplicationException>();

            if (model.QuotedRemmarks.Length > 512)
            {
                result.Add(new ApplicationException("Observações deve ser menor que 512 caracteres"));
            }

            if (model.QuotedUnitPrice <= 0)
            {
                result.Add(new ApplicationException("Preço deve maior que 0"));
            }

            return result;
        }
    }
}
