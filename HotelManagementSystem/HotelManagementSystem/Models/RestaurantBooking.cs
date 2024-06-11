using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public partial class RestaurantBooking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int TableId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual RestaurantTable Table { get; set; } = null!;
    }
}
