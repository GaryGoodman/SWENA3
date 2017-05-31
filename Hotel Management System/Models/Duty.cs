using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hotel_Management_System.Models
{
    public class Duty
    {
        [Key]
        public long Duty_ID { get; set; }
        public string Duty_Name { get; set; }
        public long Staff_ID { get; set; }
    }

    public class DutyDBContext : DbContext
    {
        public DbSet<Duty> Duties { get; set; }
    }
}