using System;
using System.Collections.Generic;

namespace SimpleQuotes.App.Model.Entity
{
    public class Quote
    {
        public Quote()
        {
            Quoted = new HashSet<Quoted>();
        }

        public long Id { get; set; }
        public long LeadId { get; set; }
        public long ProductId { get; set; }
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public decimal Quantity { get; set; }
        public string Remmarks { get; set; }

        public virtual Lead Lead { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Quoted> Quoted { get; set; }
    }
}
