//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRent
{
    using System;
    using System.Collections.Generic;
    
    public partial class RentalAgreement
    {
        public int RentalAgreementId { get; set; }
        public string AcutalItinerary { get; set; }
        public Nullable<int> ReservationId { get; set; }
        public Nullable<int> HPkr { get; set; }
        public Nullable<int> KPkr { get; set; }
        public Nullable<int> DPkr { get; set; }
        public Nullable<int> TollTaxCharges { get; set; }
        public Nullable<int> GST { get; set; }
        public Nullable<int> DriverCharges { get; set; }
        public Nullable<int> TotalCharges { get; set; }
        public string AgreementClosed { get; set; }
        public Nullable<int> AgreementFuel { get; set; }
        public Nullable<int> PrePaymen { get; set; }
        public Nullable<int> AmountDue { get; set; }
    
        public virtual Reservation Reservation { get; set; }
    }
}
