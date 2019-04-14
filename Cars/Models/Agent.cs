using System;
using System.Collections.Generic;

namespace Cars.Models
{
    public partial class Agent
    {
        public Agent()
        {
            Exchange = new HashSet<Exchange>();
            Rental = new HashSet<Rental>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Identity { get; set; }
        public decimal? Type { get; set; }

        public virtual ICollection<Exchange> Exchange { get; set; }
        public virtual ICollection<Rental> Rental { get; set; }
    }
}
