using System;
using System.Collections.Generic;

namespace Cars.Models
{
    public partial class Rental
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int AgentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Notes { get; set; }
        public int Price { get; set; }
        public int Tax { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual Cars Car { get; set; }
    }
}
