using SimpleQuotes.App.Contract.Handler;
using SimpleQuotes.App.Model.Entity;
using DomainModel = SimpleQuotes.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleQuotes.Domain.Contract.Service;
using SimpleQuotes.App.Contract.Mapping;

namespace SimpleQuotes.App.Handler
{
    public class LeadHandler : BaseHandler<Lead, DomainModel.Lead, long>, ILeadHandler
    {
        public LeadHandler(IAppMapper appMapper, ILeadService leadService):base(appMapper,leadService)
        {

        }
    }
}
