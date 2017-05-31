using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class Staff
    {
        [Key]
        public long Staff_ID { get; set; }
        public string Staff_Name { get; set; }
        public DateTime DoB { get; set; }
        public int Bank_Acc { get; set; }
        public string Street_Add { get; set; }
        public int Block_No { get; set; }
        public int Postal_Code { get; set; }
        public string Country { get; set; }
        public int Phone_No { get; set; }
    }

    public class StaffDBContext : DbContext
    {
        public DbSet<Staff> Staffs { get; set; }
    }
}