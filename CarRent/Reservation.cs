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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Reservation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reservation()
        {
            this.RentalAgreements = new HashSet<RentalAgreement>();
        }
        [Key]
        public int ReservationId { get; set; }
        public string RentingStation { get; set; }
        public Nullable<System.DateTime> CheckOut { get; set; }
        public string MethodOfPayment { get; set; }
        public string BillingAddress { get; set; }
        public string Source { get; set; }
        public Nullable<System.DateTime> ReservationDateTime { get; set; }
        public string StaffName { get; set; }
        public Nullable<System.DateTime> BookedAt { get; set; }
        public Nullable<int> CarId { get; set; }
        public string ClientName { get; set; }
        public string ClientFlightNo { get; set; }
        public string ClientPickUpAddress { get; set; }
        public string ClientContactNo { get; set; }
    
        public virtual Car Car { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RentalAgreement> RentalAgreements { get; set; }
    }
}
