using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Model
{
    class Car
    {
        
        public string Make { get; set; }
        public string RegistrationNo { get; set; }
        public Driver driver { set; get; }
        public Company company { set; get; }
        public string FuelState { get; set; }
        public double KmOut { get; set; }
        public double KmIn { get; set; }
        public double TotalKm { get; set; }
        public double KmBill { get; set; }
        public DateTime TimeOut { get; set; }
        public DateTime TImeIn { get; set; }
        public double TimeBill { get; set; }
        public DateTime TotalTime { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime DateIn { get; set; }


    }
}
