﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicationDb
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarRentalDBEntities : DbContext
    {
        public CarRentalDBEntities()
            : base("name=CarRentalDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarOwner> CarOwners { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<RentalAgreement> RentalAgreements { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
    }
}
