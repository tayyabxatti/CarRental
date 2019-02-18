using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Model
{
    class Reservation
    {
        public string RentingStation { set; get; }
        public DateTime BookedAt { get; set; }
        public Car car { get; set; }
        public string CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public Client Clients { get; set; }
        public bool MethodOfPayment { get; set; }
        public string BillingAddress { get; set; }
        public string Source { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public string StaffName { get; set; }
    }
}
