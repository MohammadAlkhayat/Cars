using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class DataContext:DbContext 
    {
      
        public DataContext(DbContextOptions<DataContext>options):base (options)
        {

        }
        public  DbSet<Agent> Agent { get; set; }
        public  DbSet<CarModel> CarModel { get; set; }
        public  DbSet<Cars> Cars { get; set; }
        public  DbSet<Exchange> Exchange { get; set; }
        public  DbSet<Guarantee> Guarantee { get; set; }
        public  DbSet<Rental> Rental { get; set; }



    }
}
