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
    
    public partial class Driver
    {
        public int DriverId { get; set; }
        public string DriverName { get; set; }
    
        public virtual Car Car { get; set; }
    }
}