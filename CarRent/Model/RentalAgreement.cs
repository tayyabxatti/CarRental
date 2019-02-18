using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Model
{
    class RentalAgreement
    {
        public Car Car { get; set; }
        public Reservation Reservation { get; set; }
        public string AcutalItinerary { get; set; }
        public BasicCharges BasicCharges { get; set; }
    }
}
