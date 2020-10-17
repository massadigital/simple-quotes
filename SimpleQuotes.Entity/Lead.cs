using System;
using System.Collections.Generic;

namespace SimpleQuotes.Entity
{
    public partial class Lead
    {
        public Lead()
        {
            Quote = new HashSet<Quote>();
        }

        public long LeadId { get; set; }
        public string LeadName { get; set; }
        public string LeadEmail { get; set; }

        public virtual ICollection<Quote> Quote { get; set; }
    }
}
