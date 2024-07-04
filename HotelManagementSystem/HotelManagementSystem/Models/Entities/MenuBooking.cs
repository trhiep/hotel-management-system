using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public partial class MenuBooking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public bool IsDone { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual MenuItem Item { get; set; } = null!;
    }
}
