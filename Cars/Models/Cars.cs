using System;
using System.Collections.Generic;

namespace Cars.Models
{
    public partial class Cars
    {
        public Cars()
        {
            Exchange = new HashSet<Exchange>();
            Rental = new HashSet<Rental>();
        }

        public int Id { get; set; }
        public int ModelId { get; set; }
        public decimal? State { get; set; }
        public string Photo { get; set; }

        public virtual CarModel Model { get; set; }
        public virtual ICollection<Exchange> Exchange { get; set; }
        public virtual ICollection<Rental> Rental { get; set; }
    }
}
