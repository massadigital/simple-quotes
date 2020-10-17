using SimpleQuotes.Data.Contract.Repository;
using SimpleQuotes.Domain.Contract.Service;
using SimpleQuotes.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleQuotes.Domain.Service
{
    public class LeadService : BaseService<Lead, long>, ILeadService
    {
        protected ILeadRepository LeadRepository { get; }

        public LeadService(ILeadRepository leadRepository) : base(leadRepository)
        {
            LeadRepository = leadRepository;
        }

        protected override async Task Trim(Lead model)
        {
            await Task.Yield();

            model.LeadName ??= string.Empty;

            model.LeadEmail ??= string.Empty;
        }

        protected override async Task Merge(Lead to, Lead from)
        {
            await Task.Yield();

            to.LeadName = from.LeadName;
        }

        protected override async Task<IEnumerable<ApplicationException>> Validate(Lead model)
        {
            await Task.Yield();

            var result = new List<ApplicationException>();

            if (model.LeadName.Length > 256)
            {
                result.Add(new ApplicationException("Nome deve ser menor que 256 caracteres"));
            }

            if (model.LeadName.Length < 2)
            {
                result.Add(new ApplicationException("Nome deve ser maior que 2 caracteres"));
            }

            try
            {
                new System.Net.Mail.MailAddress(model.LeadEmail);
            }
            catch
            {
                result.Add(new ApplicationException("Informe um email válido"));
            }

            return result;
        }
    }
}
