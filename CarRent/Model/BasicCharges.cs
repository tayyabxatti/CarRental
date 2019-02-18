using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Model
{
    class BasicCharges
    {
        public double HPkr { get; set; }
        public double KPkr { get; set; }
        public double DPkr { get; set; }
        public double TollTaxCharges { get; set; }
        public double DamageIfAny { get; set; }
        public double GST { get; set; }
        public double DriverCharges { get; set; }
        public double TotalCharges { get; set; }
    }
}
