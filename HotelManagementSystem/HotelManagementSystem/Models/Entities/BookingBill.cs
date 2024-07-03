using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Entities
{
    public partial class BookingBill
    {
        public BookingBill()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int BookingId { get; set; }
        public int Total { get; set; }
        public bool IsPaid { get; set; }

        public virtual RoomBooking Booking { get; set; } = null!;
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
