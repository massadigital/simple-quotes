using System.Collections.Generic;

namespace SimpleQuotes.App.Model.Entity
{
    public class Product
    {
        public Product()
        {
            Quote = new HashSet<Quote>();
        }

        public long Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Quote> Quote { get; set; }
    }
}
