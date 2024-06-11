using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Models
{
    public partial class RoomBooking
    {
        public int BookingId { get; set; }
        public string CustomerPhoneNumber { get; set; } = null!;
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int BookStatusId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual BookingStatus BookStatus { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual HotelRoom Room { get; set; } = null!;
        public virtual BookingBill? BookingBill { get; set; }
    }
}
