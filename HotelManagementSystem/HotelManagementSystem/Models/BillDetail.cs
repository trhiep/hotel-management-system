using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public partial class BillDetail
    {
        public int BillDetailId { get; set; }
        public int BookingId { get; set; }
        public string Title { get; set; } = null!;
        public float Price { get; set; }
        public string Note { get; set; } = null!;

        public virtual BookingBill Booking { get; set; } = null!;
    }
}
