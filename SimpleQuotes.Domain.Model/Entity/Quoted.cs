using System;
using System.Collections.Generic;

namespace SimpleQuotes.Domain.Model.Entity
{
    public partial class Quoted
    {
        public long QuotedId { get; set; }
        public long QuotedQuoteId { get; set; }
        public DateTime QuotedFrom { get; set; }
        public DateTime QuotedUntil { get; set; }
        public decimal QuotedUnitPrice { get; set; }
        public string QuotedRemmarks { get; set; }

        public virtual Quote QuotedQuote { get; set; }
    }
}
