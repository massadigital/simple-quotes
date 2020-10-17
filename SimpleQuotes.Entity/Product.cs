using System;
using System.Collections.Generic;

namespace SimpleQuotes.Entity
{
    public partial class Product
    {
        public Product()
        {
            Quote = new HashSet<Quote>();
        }

        public long ProductId { get; set; }
        public string ProductSku { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public virtual ICollection<Quote> Quote { get; set; }
    }
}
