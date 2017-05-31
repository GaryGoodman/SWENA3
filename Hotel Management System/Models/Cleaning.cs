using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Hotel_Management_System.Models
{
    public class Cleaning
    {
        [Key]
        public long Task_ID { get; set; }
        public long Room_ID { get; set; }
        public DateTime Task_Time { get; set; }
        public DateTime Task_Date { get; set; }
        public long Staff_ID { get; set; }
    }

    public class CleaningDBContext : DbContext
    {
        public DbSet<Cleaning> Cleanings { get; set; }
    }
}