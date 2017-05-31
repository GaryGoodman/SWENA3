using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Hotel_Management_System.Models
{
    public class Room
    {
        [Key]
        public long Room_ID { get; set; }
        public int Room_No { get; set; }
        public short Room_Level { get; set; }
        public string Room_Type { get; set; }
        public float Room_Rate { get; set; }
        public Boolean Room_Status { get; set; }
    }

    public class RoomDBContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
    }
}