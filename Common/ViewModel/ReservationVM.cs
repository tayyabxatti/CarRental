using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class ReservationVM
    {
        public int Id { get; set; }
        public DateTime Modified_Time { get; set; }
        public DateTime Booking_Time { get; set; }
        public string Reserved_By { get; set; }
        public int Staff_Id { get; set; }
        public int Car_Id { get; set; }
        public int Client_Id { get; set; }
        public int Driver_Id { get; set; }
        public string Pick_Up_Address { get; set; }

    }
}
