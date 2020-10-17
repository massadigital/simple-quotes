using System;
using System.Collections.Generic;

namespace SimpleQuotes.Domain.Model.Entity
{
    public class Lead
    {
        public long LeadId { get; set; }
        public string LeadName { get; set; }
        public string LeadEmail { get; set; }
    }
}
