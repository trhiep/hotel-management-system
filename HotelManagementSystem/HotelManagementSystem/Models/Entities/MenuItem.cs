using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            MenuBookings = new HashSet<MenuBooking>();
        }

        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public string ItemName { get; set; } = null!;
        public float Price { get; set; }
        public bool IsAvaliable { get; set; }
        public string? Description { get; set; }

        public virtual MenuCategory Category { get; set; } = null!;
        public virtual ICollection<MenuBooking> MenuBookings { get; set; }
    }
}
