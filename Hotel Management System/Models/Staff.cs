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
    
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            this.Cleanings = new HashSet<Cleaning>();
        }
    
        public string staff_id { get; set; }
        public string staff_name { get; set; }
        public string DoB { get; set; }
        public string bank_acc { get; set; }
        public string street_add { get; set; }
        public string block_no { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string phone_no { get; set; }
        public string duty_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cleaning> Cleanings { get; set; }
        public virtual Duty Duty { get; set; }
    }
}
