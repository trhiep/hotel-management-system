using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            MenuBookings = new HashSet<MenuBooking>();
            PromotionItems = new HashSet<PromotionItem>();
        }

        public int ItemId { get; set; }
        public int ItemName { get; set; }
        public decimal Price { get; set; }
        public bool IsAvaliable { get; set; }
        public string Description { get; set; } = null!;
        public int CategoryId { get; set; }

        public virtual MenuCategory Category { get; set; } = null!;
        public virtual ICollection<MenuBooking> MenuBookings { get; set; }
        public virtual ICollection<PromotionItem> PromotionItems { get; set; }
    }
}
