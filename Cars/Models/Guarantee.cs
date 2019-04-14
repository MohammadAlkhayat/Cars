using System;
using System.Collections.Generic;

namespace Cars.Models
{
    public partial class Guarantee
    {
        public Guarantee()
        {
            Exchange = new HashSet<Exchange>();
        }

        public int Id { get; set; }
        public DateTime FinishDate { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Exchange> Exchange { get; set; }
    }
}
