//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GuestDetail
    {
        public string guest_id { get; set; }
        public string checkIn_time { get; set; }
        public string checkIn_date { get; set; }
        public string checkOut_time { get; set; }
        public string checkOut_date { get; set; }
        public string remarks { get; set; }
    
        public virtual Guest Guest { get; set; }
    }
}