using System;
using System.Collections.Generic;

namespace SimpleQuotes.Domain.Model.Entity
{
    public partial class Product
    {
        public long ProductId { get; set; }
        public string ProductSku { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
