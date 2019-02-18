using CarRent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.ViewModel
{
    class RentViewModel
    {
        RentDb _db = new RentDb();
        public RentViewModel()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            
        }
        public IList<Client> Clients { set; get; }
        public IList<Car> Cars { get; set; }
        public IList<Company> Companies { get; set; }
        public IList<Driver> Drivers { get; set; }
        public IList<RentalAgreement> RentalAgreements { get; set; }
        public IList<Reservation> Reservations { get; set; }
        public IList<BasicCharges> BasicCharges { get; set; }

    }
}
