using System;
using System.Collections.Generic;

namespace SimpleQuotes.Entity
{
    public partial class Quote
    {
        public Quote()
        {
            Quoted = new HashSet<Quoted>();
        }

        public long QuoteId { get; set; }
        public long QuoteLeadId { get; set; }
        public long QuoteProductId { get; set; }
        public DateTime QuoteFrom { get; set; }
        public DateTime QuoteUntil { get; set; }
        public decimal QuoteQuantity { get; set; }

        public virtual Lead QuoteLead { get; set; }
        public virtual Product QuoteProduct { get; set; }
        public virtual ICollection<Quoted> Quoted { get; set; }
    }
}
