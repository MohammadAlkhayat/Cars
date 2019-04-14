using System;
using System.Collections.Generic;

namespace Cars.Models
{
    public partial class Exchange
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int CarId { get; set; }
        public int GuaranteeId { get; set; }
        public decimal Type { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual Cars Car { get; set; }
        public virtual Guarantee Guarantee { get; set; }
    }
}
