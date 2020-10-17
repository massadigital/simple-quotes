using System;
using System.Collections.Generic;

namespace SimpleQuotes.Domain.Model.Entity
{
    public partial class Quote
    {
        public long QuoteId { get; set; }
        public long QuoteLeadId { get; set; }
        public long QuoteProductId { get; set; }
        public DateTime QuoteFrom { get; set; }
        public DateTime QuoteUntil { get; set; }
        public decimal QuoteQuantity { get; set; }
        public string QuoteRemmarks { get; set; }

        public virtual Lead QuoteLead { get; set; }
        public virtual Product QuoteProduct { get; set; }
    }
}
