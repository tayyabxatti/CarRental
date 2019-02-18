using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Model
{
    class RentDb : DbContext
    {
        public RentDb() : base("name= DefaultConnection")
        {

        }
        public DbSet<BasicCharges> BasicCharges { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<RentalAgreement> RentalAgreements { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
