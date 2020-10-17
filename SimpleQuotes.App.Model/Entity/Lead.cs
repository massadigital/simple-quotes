using System.Collections.Generic;

namespace SimpleQuotes.App.Model.Entity
{
    public class Lead
    {
        public Lead()
        {
            Quotes = new HashSet<Quote>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
