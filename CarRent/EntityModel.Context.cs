﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class carRentEntities : DbContext
    {
        public carRentEntities()
            : base("carRentEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BasicCharge> BasicCharges { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<RentalAgreement> RentalAgreements { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
    }
}
