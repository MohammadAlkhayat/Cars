using System;
using System.Collections.Generic;

namespace Cars.Models
{
    public partial class CarModel
    {
        public CarModel()
        {
            Cars = new HashSet<Cars>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int EnginePower { get; set; }
        public int? Fuel { get; set; }

        public virtual ICollection<Cars> Cars { get; set; }
    }
}
