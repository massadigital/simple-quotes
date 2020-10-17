using SimpleQuotes.Data.Contract.Repository;
using SimpleQuotes.Domain.Contract.Service;
using SimpleQuotes.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleQuotes.Domain.Service
{
    public class QuoteService : BaseService<Quote, long>, IQuoteService
    {
        protected IQuoteRepository QuoteRepository { get; }

        public QuoteService(IQuoteRepository quoteRepository) : base(quoteRepository)
        {
            QuoteRepository = quoteRepository;
        }

        protected override async Task Trim(Quote model)
        {
            await Task.Yield();

            model.QuoteRemmarks ??= string.Empty;
        }

        protected override async Task Merge(Quote to, Quote from)
        {
            await Task.Yield();

            to.QuoteUntil = from.QuoteUntil;

            to.QuoteFrom = from.QuoteFrom;

            to.QuoteRemmarks = from.QuoteRemmarks;

            to.QuoteQuantity = from.QuoteQuantity;

            to.QuoteProductId = from.QuoteProductId;

            to.QuoteLeadId = from.QuoteLeadId;
        }

        protected override async Task<IEnumerable<ApplicationException>> Validate(Quote model)
        {
            await Task.Yield();

            var result = new List<ApplicationException>();

            if (model.QuoteRemmarks.Length > 512)
            {
                result.Add(new ApplicationException("Observações deve ser menor que 512 caracteres"));
            }

            if (model.QuoteQuantity <= 0)
            {
                result.Add(new ApplicationException("Quantidade deve maior que 0"));
            }

            return result;
        }
    }
}
