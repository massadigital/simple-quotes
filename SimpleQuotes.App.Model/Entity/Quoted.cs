using System;

namespace SimpleQuotes.App.Model.Entity
{
    public partial class Quoted
    {
        public long Id { get; set; }
        public long QuoteId { get; set; }
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public decimal UnitPrice { get; set; }
        public string Remmarks { get; set; }

        public virtual Quote Quote { get; set; }
    }
}
